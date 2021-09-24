using Microsoft.VisualStudio.TestTools.UnitTesting;
using pdftk_wrapper;
using System;
using System.Collections.Generic;

namespace pdfk_wrapperTests
{
    [TestClass]
    public class PageRangeTests
    {
        [TestMethod]
        public void PageRange_2ParameterConstructorTests()
        {
            uint st = 3;
            uint en = 3;
            PageRange actual = new PageRange(st, en);

            Assert.AreEqual(actual.Start, st);
            Assert.AreEqual(actual.End, en);

            st = 5;
            en = 10;
            actual = new PageRange(st, en);

            Assert.AreEqual(actual.Start, st);
            Assert.AreEqual(actual.End, en);

            st = 11;
            en = 10;
            Assert.ThrowsException<ArgumentException>(() => new PageRange(st, en));

            st = 0;
            en = 1;
            Assert.ThrowsException<ArgumentException>(() => new PageRange(st, en));

            st = 1;
            en = 0;
            Assert.ThrowsException<ArgumentException>(() => new PageRange(st, en));
        }


        [TestMethod]
        public void PageRange_1ParameterConstructorTests()
        {
            uint st = 3;
            PageRange actual = new PageRange(st);

            Assert.AreEqual(actual.Start, st);
            Assert.AreEqual(actual.End, st);

            st = 0;
            Assert.ThrowsException<ArgumentException>(() => new PageRange(st));
        }

        [TestMethod]
        public void PageRange_LengthTests()
        {
            PageRange pr = new PageRange(7);
            Assert.AreEqual(pr.Length, 1u);

            pr = new PageRange(1, 2);
            Assert.AreEqual(pr.Length, 2u);

            pr = new PageRange(4, 10);
            Assert.AreEqual(pr.Length, 7u);
        }

        [TestMethod]
        public void PageRange_DistanceTests()
        {
            PageRange one = new PageRange(1);
            PageRange two = new PageRange(2);
            Assert.AreEqual(one.Distance(two), 0);
            Assert.AreEqual(two.Distance(one), 0);

            one = new PageRange(1);
            two = new PageRange(3);
            Assert.AreEqual(one.Distance(two), 1);
            Assert.AreEqual(two.Distance(one), 1);

            one = new PageRange(1, 4);
            two = new PageRange(3, 5);
            Assert.AreEqual(one.Distance(two), -1);
            Assert.AreEqual(two.Distance(one), -1);

            one = new PageRange(1, 5);
            two = new PageRange(8, 10);
            Assert.AreEqual(one.Distance(two), 2);
            Assert.AreEqual(two.Distance(one), 2);
        }


        [TestMethod]
        public void PageRange_OverlapsTests()
        {
            // no overlap
            PageRange one = new PageRange(3, 5);
            PageRange two = new PageRange(8, 11);
            Assert.AreEqual(one.Overlaps(two), false);

            one = new PageRange(6, 8);
            two = new PageRange(1, 3);
            Assert.AreEqual(one.Overlaps(two), false);

            one = new PageRange(6, 8);
            two = new PageRange(9, 10);
            Assert.AreEqual(one.Overlaps(two), false);

            one = new PageRange(6, 8);
            two = new PageRange(3, 5);
            Assert.AreEqual(one.Overlaps(two), false);

            // one.end overlaps two.start
            one = new PageRange(4, 7);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(4, 5);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            // one in two
            one = new PageRange(5, 10);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(8, 9);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(5, 11);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(9, 11);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            // two.end overlaps one.start
            one = new PageRange(11, 11);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(11, 13);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(10, 12);
            two = new PageRange(5, 11);
            Assert.AreEqual(one.Overlaps(two), true);

            // two in one
            one = new PageRange(3, 9);
            two = new PageRange(4, 6);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(3, 9);
            two = new PageRange(3, 9);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(3, 9);
            two = new PageRange(5, 9);
            Assert.AreEqual(one.Overlaps(two), true);

            one = new PageRange(3, 9);
            two = new PageRange(3, 7);
            Assert.AreEqual(one.Overlaps(two), true);
        }

        [TestMethod]
        public void PageRange_SortTests()
        {
            List<PageRange> actual = new List<PageRange>();
            actual.Add(new PageRange(1));
            actual.Add(new PageRange(3, 4));
            actual.Add(new PageRange(5, 5));
            actual.Add(new PageRange(7, 9));

            List<PageRange> expected = new List<PageRange>(actual);
            PageRange.Sort(actual);            
            CollectionAssert.AreEqual(actual, expected);


            actual = new List<PageRange>();
            actual.Add(new PageRange(3, 4));
            actual.Add(new PageRange(7, 9));
            actual.Add(new PageRange(5, 5));
            actual.Add(new PageRange(1));


            expected = new List<PageRange>();
            expected.Add(new PageRange(1));
            expected.Add(new PageRange(3, 4));
            expected.Add(new PageRange(5, 5));
            expected.Add(new PageRange(7, 9));

            PageRange.Sort(actual);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PageRange_IsOverlappingTests()
        {
            List<PageRange> arg = new List<PageRange>();
            arg.Add(new PageRange(1));
            arg.Add(new PageRange(3, 4));
            arg.Add(new PageRange(5, 5));
            arg.Add(new PageRange(7, 9));
            Assert.AreEqual(PageRange.IsOverlapping(arg), false);

            arg = new List<PageRange>();
            arg.Add(new PageRange(3, 5));
            arg.Add(new PageRange(5, 5));
            arg.Add(new PageRange(7, 9));
            Assert.AreEqual(PageRange.IsOverlapping(arg), true);

            arg = new List<PageRange>();
            arg.Add(new PageRange(3, 10));
            arg.Add(new PageRange(5, 7));
            Assert.AreEqual(PageRange.IsOverlapping(arg), true);
        }



        [TestMethod]
        public void PageRange_ParseOneTests()
        {
            string range = "1-2";
            PageRange actual = PageRange.ParseOne(range);
            PageRange expected = new PageRange(1, 2);
            Assert.AreEqual(actual, expected);

            range = "7-7";
            actual = PageRange.ParseOne(range);
            expected = new PageRange(7);
            Assert.AreEqual(actual, expected);

            range = "9";
            actual = PageRange.ParseOne(range);
            expected = new PageRange(9);
            Assert.AreEqual(actual, expected);


            range = "9-8";
            Assert.ThrowsException<ArgumentException>(() => PageRange.ParseOne(range));

            range = "0";
            Assert.ThrowsException<ArgumentException>(() => PageRange.ParseOne(range));

            range = "-1";
            Assert.ThrowsException<FormatException>(() => PageRange.ParseOne(range));

            range = "1-";
            Assert.ThrowsException<FormatException>(() => PageRange.ParseOne(range));

            range = "abc";
            Assert.ThrowsException<FormatException>(() => PageRange.ParseOne(range));

            range = "";
            Assert.ThrowsException<FormatException>(() => PageRange.ParseOne(range));

            range = "10--11";
            Assert.ThrowsException<ArgumentException>(() => PageRange.ParseOne(range));

            range = "-";
            Assert.ThrowsException<FormatException>(() => PageRange.ParseOne(range));
        }

        [TestMethod]
        public void PageRange_ParseAllTest1()
        {
            string range = "1-2";
            List<PageRange> actual = PageRange.ParseAll(range);
            List<PageRange> expected = new List<PageRange>();
            expected.Add(new PageRange(1, 2));
            Assert.AreEqual(actual.Count, expected.Count);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PageRange_ParseAllTest2()
        {
            string range = "1-2, 5-6, 9-12";
            List<PageRange> actual = PageRange.ParseAll(range);
            List<PageRange> expected = new List<PageRange>();
            expected.Add(new PageRange(1, 2));
            expected.Add(new PageRange(5, 6));
            expected.Add(new PageRange(9, 12));
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(3, actual.Count);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PageRange_ParseAllTest3()
        {
            string range = "5-6, 1-2, 9-12";
            List<PageRange> actual = PageRange.ParseAll(range);
            List<PageRange> expected = new List<PageRange>();
            expected.Add(new PageRange(1, 2));
            expected.Add(new PageRange(5, 6));
            expected.Add(new PageRange(9, 12));
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(3, actual.Count);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PageRange_GetSinglePagesTests()
        {
            PageRange pr = new PageRange(1);
            List<PageRange> expected = new List<PageRange>();
            expected.Add(pr);
            List<PageRange> actual = pr.GetSinglePages();
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(1, actual.Count);
            CollectionAssert.AreEqual(actual, expected);

            pr = new PageRange(1, 2);
            expected = new List<PageRange>();
            expected.Add(new PageRange(1));
            expected.Add(new PageRange(2));
            actual = pr.GetSinglePages();
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(2, actual.Count);
            CollectionAssert.AreEqual(actual, expected);


            pr = new PageRange(7, 13);
            expected = new List<PageRange>();
            for (uint i = 7; i <= 13; i++)
                expected.Add(new PageRange(i));
            actual = pr.GetSinglePages();
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(7, actual.Count);
            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        public void PageRange_GetSinglePagesFromListTests()
        {
            List<PageRange> expected = new List<PageRange>();
            expected.Add(new PageRange(1));
            List<PageRange> actual = PageRange.GetSinglePagesFromList(expected);
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(1, actual.Count);
            CollectionAssert.AreEqual(actual, expected);


            expected = new List<PageRange>();
            expected.Add(new PageRange(1));
            expected.Add(new PageRange(2));
            actual = PageRange.GetSinglePagesFromList(expected);
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(2, actual.Count);
            CollectionAssert.AreEqual(actual, expected);


            List<PageRange> arg = new List<PageRange>();
            arg.Add(new PageRange(5, 7));
            arg.Add(new PageRange(8, 10));
            arg.Add(new PageRange(11, 16));

            expected = new List<PageRange>();
            for (uint i = 5; i <= 16; i++)
                expected.Add(new PageRange(i));
            actual = PageRange.GetSinglePagesFromList(arg);
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(12, actual.Count);
            CollectionAssert.AreEqual(actual, expected);


            arg = new List<PageRange>();
            arg.Add(new PageRange(5, 9));
            arg.Add(new PageRange(7, 10));
            arg.Add(new PageRange(9, 16));

            expected = new List<PageRange>();
            for (uint i = 5; i <= 16; i++)
                expected.Add(new PageRange(i));
            actual = PageRange.GetSinglePagesFromList(arg);
            Assert.AreEqual(actual.Count, expected.Count);
            Assert.AreEqual(12, actual.Count);
            CollectionAssert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void PageRange_CollapseTests()
        {
            PageRange one = new PageRange(1, 2);
            PageRange two = new PageRange(2, 3);
            PageRange expected = new PageRange(1, 3);
            Assert.AreEqual(one.Collapse(two), expected);


            one = new PageRange(2, 3);
            two = new PageRange(1, 2);
            expected = new PageRange(1, 3);
            Assert.AreEqual(one.Collapse(two), expected);


            one = new PageRange(6, 12);
            two = new PageRange(13, 15);
            expected = new PageRange(6, 15);
            Assert.AreEqual(one.Collapse(two), expected);

            one = new PageRange(2, 3);
            two = new PageRange(1, 2);
            expected = new PageRange(1, 3);
            Assert.AreEqual(one.Collapse(two), expected);


            one = new PageRange(5);
            two = new PageRange(6);
            expected = new PageRange(5, 6);
            Assert.AreEqual(one.Collapse(two), expected);
        }

        [TestMethod]
        public void PageRange_LesserOperatorTests()
        {
            PageRange one = new PageRange(1, 2);
            PageRange two = new PageRange(2, 3);
            Assert.AreEqual(one < two, true);


            one = new PageRange(1);
            two = new PageRange(2);
            Assert.AreEqual(one < two, true);


            one = new PageRange(5, 8);
            two = new PageRange(12, 13);
            Assert.AreEqual(one < two, true);


            one = new PageRange(1, 2);
            two = new PageRange(2, 3);
            Assert.AreEqual(two < one, false);


            one = new PageRange(1);
            two = new PageRange(2);
            Assert.AreEqual(two < one, false);


            one = new PageRange(5, 8);
            two = new PageRange(12, 13);
            Assert.AreEqual(two < one, false);
        }


        [TestMethod]
        public void PageRange_GreaterOperatorTests()
        {
            PageRange one = new PageRange(1, 2);
            PageRange two = new PageRange(2, 3);
            Assert.AreEqual(one > two, false);


            one = new PageRange(1);
            two = new PageRange(2);
            Assert.AreEqual(one > two, false);


            one = new PageRange(5, 8);
            two = new PageRange(12, 13);
            Assert.AreEqual(one > two, false);


            one = new PageRange(1, 2);
            two = new PageRange(2, 3);
            Assert.AreEqual(two > one, true);


            one = new PageRange(1);
            two = new PageRange(2);
            Assert.AreEqual(two > one, true);


            one = new PageRange(5, 8);
            two = new PageRange(12, 13);
            Assert.AreEqual(two > one, true);
        }

        [TestMethod]
        public void PageRange_GetCatListFromToRemoveListTests()
        {
            List<PageRange> toRemove = new List<PageRange>();
            toRemove.Add(new PageRange(2, 6));

            uint lastPage = 11;

            List<PageRange> expected = new List<PageRange>();
            expected.Add(new PageRange(1));
            expected.Add(new PageRange(7, 11));
            List<PageRange> actual = PageRange.GetCatListFromToRemoveList(toRemove, lastPage);
            CollectionAssert.AreEqual(actual, expected);


            toRemove = new List<PageRange>();
            toRemove.Add(new PageRange(1));
            toRemove.Add(new PageRange(3));
            toRemove.Add(new PageRange(6, 9));

            lastPage = 14;

            expected = new List<PageRange>();
            expected.Add(new PageRange(2));
            expected.Add(new PageRange(4, 5));
            expected.Add(new PageRange(10, 14));
            actual = PageRange.GetCatListFromToRemoveList(toRemove, lastPage);
            CollectionAssert.AreEqual(actual, expected);
        }
    }    
}
