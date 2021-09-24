using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdftk_wrapper
{
    public struct PageRange
    {
        private static readonly char dash = '-';
        private static readonly char comma = ',';

        public uint Start { get; }
        public uint End { get; }
        public PageRange(uint start, uint end)
        {
            if (start < 1)
                throw new ArgumentException("Диапазон страниц не может начинаться с номера страницы меньшего 1", "start");
            if (end < start)
                throw new ArgumentException("Начало диапазона страниц не может быть меньше конца", "end");
            Start = start;
            End = end;
        }

        public PageRange(uint start)
        {
            if (start < 1)
                throw new ArgumentException("Диапазон страниц не может начинаться с номера страницы меньшего 1", "start");
            Start = End = start;
        }

        public uint Length => this.End - this.Start + 1;

        public override string ToString()
        {
            if (this.Length == 1)
                return this.Start.ToString();
            else
                return string.Join(dash, this.Start, this.End);
        }

        public static string ListToString(List<PageRange> l) => string.Join(' ', l);

        public static bool operator <(PageRange a, PageRange b)
        {
            return a.Start < b.Start;
        }

        public static bool operator >(PageRange a, PageRange b)
        {
            return a.Start > b.Start;
        }

        public int Distance(PageRange other)
        {
            if (this.Overlaps(other))
                return -1;
            if (this < other)
                return Convert.ToInt32(other.Start - this.End - 1);
            else
                return Convert.ToInt32(this.Start - other.End - 1);
        }

        public static List<PageRange> ParseAll(string pageRangesStr)
        {
            pageRangesStr = new string(pageRangesStr.Where(c => (char.IsDigit(c) || c == dash || c == comma)).ToArray());

            if (string.IsNullOrEmpty(pageRangesStr))
                throw new ArgumentException("Диапазонов не найдено", "pageRangeStr");

            string[] ranges = pageRangesStr.Split(comma);

            List<PageRange> res = new List<PageRange>();

            foreach (string rangeStr in ranges)
                res.Add(ParseOne(rangeStr));

            if (IsOverlapping(res))
                throw new ArgumentException("Некорректные диапазоны", "pageRangeStr");

            Sort(res);
            return res;
        }

        public static PageRange ParseOne(string pageRangeStr)
        {   
            string[] pages = pageRangeStr.Split(dash);

            if (pages.Length == 2)
                return new PageRange(uint.Parse(pages[0]), uint.Parse(pages[1]));
            else if (pages.Length == 1)
                return new PageRange(uint.Parse(pages[0]));
            else
                throw new ArgumentException("Не удалось корректно распознать диапазон страниц", "pageRangeStr");
        }

        public bool Overlaps(PageRange other)
        {
            // this     other
            //  []       ()
            // this.end overlaps with other.start
            //   [ (] )
            if (this.End >= other.Start && this.Start < other.End)
                return true;

            // this inside other
            // ([])
            if (this.Start >= other.Start && this.End <= other.End)
                return true;

            // this.start overlaps with other.end
            // ( [) ]
            if (this.Start <= other.End && this.End > other.End)
                return true;

            // other inside this
            // [ () ]
            if (this.Start <= other.Start && this.End >= other.End)
                return true;

            return false;
        }

        public static void Sort(List<PageRange> prList)
        {
            prList.Sort((x, y) => x.Start.CompareTo(y.Start));
        }

        public static bool IsOverlapping(List<PageRange> prList)
        {
            for (int i = 0; i < prList.Count; i++)
                for (int j = 0; j < prList.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (prList[i].Overlaps(prList[j]))
                        return true;
                }
            return false;
        }

        public List<PageRange> GetSinglePages()
        {
            List<PageRange> res = new List<PageRange>();
            if (this.Length == 1)
                res.Add(this);
            else
                for (uint i = this.Start; i <= this.End; i++)
                    res.Add(new PageRange(i));
            return res;
        }

        public static List<PageRange> GetSinglePagesFromList(List<PageRange> inList)
        {
            HashSet<PageRange> res = new HashSet<PageRange>();
            foreach (PageRange pr in inList)
                foreach (PageRange prinner in pr.GetSinglePages())
                    res.Add(prinner);
            List<PageRange> resList = res.ToList<PageRange>();
            Sort(resList);
            return resList;
        }

        public PageRange Collapse(PageRange other)
        {
            return new PageRange(this.Start < other.Start ? this.Start : other.Start, this.End > other.End ? this.End : other.End);
        }

        public static List<PageRange> CollapseFromSinglePages(List<PageRange> inList)
        {
            if (inList.Count <= 1)
                return inList;

            List<PageRange> res = new List<PageRange>();
            res.Add(inList[0]);
            inList.RemoveAt(0);

            while (inList.Count > 0)
            {
                PageRange one = inList[0];
                PageRange two = res[res.Count - 1];
                if (one.Distance(two) == 0)
                    res[res.Count - 1] = one.Collapse(two);
                else
                    res.Add(one);
                inList.RemoveAt(0);
            }
            return res;
        }

        public static List<PageRange> GetCatListFromToRemoveList(List<PageRange> toRemove, uint lastPage)
        {
            HashSet<PageRange> allpages = new HashSet<PageRange>(new PageRange(1, lastPage).GetSinglePages());
            HashSet<PageRange> toRemoveSet = new HashSet<PageRange>(PageRange.GetSinglePagesFromList(toRemove));
            allpages.ExceptWith(toRemoveSet);
            List<PageRange> res = allpages.ToList<PageRange>();
            Sort(res);
            return PageRange.CollapseFromSinglePages(res);
        }
    }
}
