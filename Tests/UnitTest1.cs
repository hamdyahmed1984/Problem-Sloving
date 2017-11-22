using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cracking.Hard;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordDistance_Test()
        {
            WordDistance wd = new WordDistance();
            string[] words = new string[]
            {
                "c",
                "b",
                "w",
                "a",
                "e",
                "a",
                "a",
                "t",
                "b",
                "b",
            };

            int[] actual = wd.FindClosestDistance(words, "a", "b");
            actual = wd.FindClosestDistance2(words, "a", "b");
            actual = wd.FindClosestDistance3(words, "a", "b");
        }

        [TestMethod]
        public void MajorityElement_Test()
        {
            int[] arr1 = { 5, 1, 5, 3, 5 };
            int[] arr2 = { 5, 1, 5, 5, 3 };
            int[] arr3 = { 5, 1, 5, 3, 1 };
            int[] arr4 = { 1, 2, 5, 9, 5, 9, 5, 5, 5 };
            int[] arr5 = { 3, 1, 7, 1, 3, 7, 3, 7, 1, 7, 7 };

            MajorityElement me = new MajorityElement();
            int expected = 5;
            int actual = me.FindMajorityElement_BF(arr1);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Better(arr1);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Optimal(arr1);
            Assert.AreEqual(expected, actual);

            expected = 5;
            actual = me.FindMajorityElement_BF(arr2);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Better(arr2);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Optimal(arr2);
            Assert.AreEqual(expected, actual);

            expected = -1;
            actual = me.FindMajorityElement_BF(arr3);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Better(arr3);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Optimal(arr3);
            Assert.AreEqual(expected, actual);

            expected = 5;
            actual = me.FindMajorityElement_BF(arr4);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Better(arr4);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Optimal(arr4);
            Assert.AreEqual(expected, actual);

            expected = -1;
            actual = me.FindMajorityElement_BF(arr5);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Better(arr5);
            Assert.AreEqual(expected, actual);

            actual = me.FindMajorityElement_Optimal(arr5);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void KthMultiples_Test()
        {
            int k = 10;
            KthMultiple km = new KthMultiple();
            System.Diagnostics.Trace.WriteLine("BruteForce: ");
            for (int i = 0; i <= 10; i++)
                System.Diagnostics.Trace.Write(km.GetKthMagicNumber_BF(i) + ", ");
            System.Diagnostics.Trace.WriteLine("Better: ");
            for (int i = 0; i <= 10; i++)
                System.Diagnostics.Trace.Write(km.GetKthMagicNumber_Better(i) + ", ");
            System.Diagnostics.Trace.WriteLine("Optimal: ");
            for (int i = 0; i <= 10; i++)
                System.Diagnostics.Trace.Write(km.GetKthMagicNumber_Optimal(i) + ", ");
            System.Diagnostics.Trace.WriteLine("Optimal2: ");
            for (int i = 0; i <= 10; i++)
                System.Diagnostics.Trace.Write(km.GetKthMagicNumber_Optimal_2(i) + ", ");
        }

        [TestMethod]
        public void CircusTower_Test()
        {
            List<CircusTower.HtWt> arr = new List<CircusTower.HtWt>();
            arr.AddRange(new List<CircusTower.HtWt>()
            {
                new CircusTower.HtWt(65, 100),
                new CircusTower.HtWt(70, 150),
                new CircusTower.HtWt(56, 90),
                new CircusTower.HtWt(75, 190),
                new CircusTower.HtWt(60, 105),
                new CircusTower.HtWt(68, 110)
            });

            List<CircusTower.HtWt> actual = new CircusTower().FindBestSequence(arr);

            //CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BabyNames_UsingGraphs_Test()
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            names.Add("John", 10);
            names.Add("Jon", 3);
            names.Add("Davis", 2);
            names.Add("Kari", 3);
            names.Add("Johnny", 11);
            names.Add("Carlton", 8);
            names.Add("Carleton", 2);
            names.Add("Jonathan", 9);
            names.Add("Carrie", 5);

            string[][] synonems = new string[5][]
            {
                new string[]{"Jonathan", "John"},
                new string[]{"Jon", "Johnny"},
                new string[]{"Johnny", "John"},
                new string[]{"Kari", "Carrie"},
                new string[]{"Carleton", "Carlton"}
            };

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("John", 33);
            expected.Add("Kari", 8);
            expected.Add("Davis", 2);
            expected.Add("Carleton", 10);

            BabyNames_UsingGraphs bn = new BabyNames_UsingGraphs();
            Dictionary<string, int> dictionary = bn.GetTrulyMostPopularNames(names, synonems);
        }

        [TestMethod]
        public void BabyNames_Test()
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            names.Add("John", 10);
            names.Add("Jon", 3);
            names.Add("Davis", 2);
            names.Add("Kari", 3);
            names.Add("Johnny", 11);
            names.Add("Carlton", 8);
            names.Add("Carleton", 2);
            names.Add("Jonathan", 9 );
            names.Add("Carrie", 5);

            string[][] synonems = new string[5][]
            {
                new string[]{"Jonathan", "John"},
                new string[]{"Jon", "Johnny"},
                new string[]{"Johnny", "John"},
                new string[]{"Kari", "Carrie"},
                new string[]{"Carleton", "Carlton"}
            };

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("John", 33);
            expected.Add("Kari", 8);
            expected.Add("Davis", 2);
            expected.Add("Carleton", 10);

            BabyNames bn = new BabyNames();
            Dictionary<string, int> dictionary = bn.GetTrulyMostPopular(names, synonems);
        }

        [TestMethod]
        public void FindMissingNumber_Test()
        {
            List<System.Collections.BitArray> list = new List<System.Collections.BitArray>();
            list.Add(new System.Collections.BitArray((new byte[] { 1 })));
            list.Add(new System.Collections.BitArray((new byte[] { 5 })));
            list.Add(new System.Collections.BitArray((new byte[] { 2 })));
            list.Add(new System.Collections.BitArray((new byte[] { 4 })));
            list.Add(new System.Collections.BitArray((new byte[] { 0 })));


            MissingNumber mn = new MissingNumber();
            int expected = 3;
            int actual = mn.FindMissingNumber(list);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FindMissingNumber_Sum_Test()
        {
            int[] arr = { 1, 2, 5, 4 };
            MissingNumber mn = new MissingNumber();
            int expected = 3;
            int actual = mn.FindMissingNumber_UsingSum(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FindMissingNumber_XOR_Test()
        {
            int[] arr = { 1, 2, 5, 4 };
            MissingNumber mn = new MissingNumber();
            int expected = 3;
            int actual = mn.FindMissingNumber_XOR(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountNumberOf2s_BF1_Test()
        {
            int n = 1000000;
            CountOf2s c2s = new CountOf2s();
            int expected = 600000;
            int actual = c2s.CountNumberOf2sInRange_BF(n);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountNumberOf2s_BF2_Test()
        {
            int n = 1000000;
            CountOf2s c2s = new CountOf2s();
            int expected = 600000;
            int actual = c2s.CountNumberOf2sInRange_BF2(n);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountNumberOf2s_Optimal_Test()
        {
            int n = 1000000;
            CountOf2s c2s = new CountOf2s();
            int expected = 600000;
            int actual = c2s.CountNumberOf2sInRange_Optimal(n);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LettersAndNumbers_optimal_Test()
        {
            char[] arr = { '1', 'a', '5', '2', 'b' };
            char[] expected = { 'a', '5', '2', 'b' };
            LettersAndNumbers ln = new LettersAndNumbers();
            char[] actual = ln.FindLongestSubArray_Optimal(arr);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LettersAndNumbers_BF_Test()
        {
            char[] arr = { '1', 'a', '5', '2', 'b' };
            char[] expected = { 'a', '5', '2', 'b' };
            LettersAndNumbers ln = new LettersAndNumbers();
            char[] actual = ln.FindLongestSubArray_BF(arr);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LettersAndNumbers_BF_Optimized_Test()
        {
            char[] arr = { '1', 'a', '5', '2', 'b' };
            char[] expected = { 'a', '5', '2', 'b' };
            LettersAndNumbers ln = new LettersAndNumbers();
            char[] actual = ln.FindLongestSubArray_BF_Optimized(arr);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShuffleIterativeTest()
        {
            int[] arr = { 1, 2, 3 };
            int[] arr_Copy = { 1, 2, 3 };
            Shuffle shuffle = new Shuffle();
            int[] actual = shuffle.ShuffleArray_Iteratively(arr_Copy);
            CollectionAssert.AreNotEqual(arr, actual);
        }

        [TestMethod]
        public void ShuffleRecursiveTest()
        {
            int[] arr = { 1, 2, 3 };
            int[] arr_Copy = { 1, 2, 3 };
            Shuffle shuffle = new Shuffle();
            int[] actual = shuffle.ShuffleArray_Recursively(arr_Copy, arr_Copy.Length - 1);
            CollectionAssert.AreNotEqual(arr, actual);
        }

        [TestMethod]
        public void AddWithoutPlusTest()
        {
            int a = 5;
            int b = 6;
            int expected = 11;
            Cracking.Hard.AddWithoutPlus addWithoutPlus = new Cracking.Hard.AddWithoutPlus();
            int actual = addWithoutPlus.Add(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}
