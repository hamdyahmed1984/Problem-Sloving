using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cracking.Hard;
using Cracking.Primitives;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Trees;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MerkleTree_Test()
        {
            List<char> lst = "0123456789".ToList();
            MerkleTree<char> tree = new MerkleTree<char>(lst);

            string treeHash = tree.Root.Hash;
        }

        [TestMethod]
        public void GCD_Test()
        {
            int[] a = { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 };
            int[] b = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int lcm = LCM_All(a);
            int gcd = GCD_All(b);

            int count = 0;
            for (int i = lcm; i <= gcd; i += lcm)
                if (gcd % i == 0) count++;

        }

        private static int GCD_All(int[] arr)
        {
            if (arr.Length == 0) return 0;
            int gcd = arr[0];
            for (int i = 1; i < arr.Length; i++)
                gcd = GCD(gcd, arr[i]);
            return gcd;
        }
        private static int LCM_All(int[] arr)
        {
            if (arr.Length == 0) return 0;
            int lcm = arr[0];
            for (int i = 1; i < arr.Length; i++)
                lcm = LCM(lcm, arr[i]);
            return lcm;
        }
        private static int GCD(int a, int b)
        {
            /*if (a == 0 || b == 0) return 0;
            if (a == b) return a;
            if (a > b) return GCD(a - b, b);
            else return GCD(a, b - a);*/
            if (b == 0)
                return a;
           return GCD(b, a % b);
        }
        private static int LCM(int a, int b)
        {
            int gcd = GCD(a, b);
            if (gcd == 0) return 0;
            return a * b / gcd;
        }

        [TestMethod]
        public void MaxSumSubMattix_Test()
        {
            
            MaxSumSubMatrix m = new MaxSumSubMatrix();
            int[][] matrix = new int[4][]
            {
                new int[]{  1 ,  2, -1, -4, -20},
                new int[]{ -8,  -3,  4,  2,  1},
                new int[]{  3,   8,  10, 1,  3},
                new int[]{ -4,  -1,  1,  7, -6}
            };

            MaxSumSubMatrix.SubMatrix actual1 = m.GetSubMatrixWithMaxSum_BF(matrix);
            MaxSumSubMatrix.SubMatrix actual2 = m.GetSubMatrixWithMaxSum_Optimized(matrix);
            MaxSumSubMatrix.SubMatrix actual3 = m.GetSubMatrixWithMaxSum_Optimal(matrix);
        }

        [TestMethod]
        public void MaxSquareMatrix_Test()
        {
            MaxSquareMatrix msm = new MaxSquareMatrix();
            int[][] matrix = new int[5][]
            {
                new int[]{1,0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0,1},
                new int[]{0,0,0,0,0},
                new int[]{1,0,0,0,0}
            };

            MaxSquareMatrix.SubSquareMatrix square = msm.FindSubSquareMatrixWithZeroBordere_Optimal(matrix);
        }

        [TestMethod]
        public void VolumeOfHistogram_Test()
        {
            VolumeOfHistogram vh = new VolumeOfHistogram();
            int[] histogram = { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 5, 0, 1, 0, 0, 0 };
            int expected = 26;
            int actual = vh.GetHistogramVolume_Simplified_Optimized(histogram);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContinuousMedian_Test()
        {
            ContinuousMedian cm = new ContinuousMedian();
            Random rand = new Random();
            double currentMedian = 0;
            for(int i = 0; i < 10; i++)
            {
                cm.AddNewNumber(rand.Next(1, 10));
                currentMedian = cm.GetMedian();
            }
        }

        [TestMethod]
        public void Missing2Numbers_Test()
        {
            Missing2Numbers mn = new Missing2Numbers();
            int[] arr = { 1, 2, 10, 4, 6, 7, 8, 3, 9 };//missing is 5
            int missingNumber = 0;
            missingNumber = mn.FindMissingNumber_UsingSum(arr);
            missingNumber = mn.FindMissingNumber_UsingSquareSum(arr);
            missingNumber = mn.FindMissingNumber_UsingProduct(arr);
            missingNumber = mn.FindMissingNumber_UsingXOR(arr);

            int[] arr2 = { 1, 2, 10, 5, 7, 6, 8, 9 };//missing 2 numbers are 3 and 4
            int[] missing2Numbers = mn.FindMissing2Numbers(arr2);
        }

        [TestMethod]
        public void ShortestSupersequence_Test()
        {
            ShortestSuperSequence sss = new ShortestSuperSequence();
            int[] big = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 8, 9, 7 };
            int[] small = { 1, 5, 9 };
            ShortestSuperSequence.Range range = sss.FindShortestSupersequence_MoreOptimal(big, small);
        }

        [TestMethod]
        public void MultiSearch_Test()
        {
            MultiSearch ms = new MultiSearch();
            string big = "mississippi";
            string[] smalls = { "is", "ppi", "hi", "sis", "i", "ssippi" };
            var actual = ms.SearchAll_Trie(big, smalls);
        }

        [TestMethod]
        public void TheMasseuse_Test()
        {
            TheMasseuse mas = new TheMasseuse();
            int[] requests = { 30, 15, 60, 75, 45, 15, 15, 45 };//{ 45, 60, 45, 15 };

            int expected = 180;
            int actual = 0;
            actual = mas.MaxMinutes_Recursion(requests);
            Assert.AreEqual(expected, actual);
            actual = mas.MaxMinutes_Memo(requests);
            Assert.AreEqual(expected, actual);
            actual = mas.MaxMinutes_Iterative(requests);
            Assert.AreEqual(expected, actual);
            actual = mas.MaxMinutes_Optimal(requests);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestWord_Test()
        {
            LongestWord lw = new LongestWord();
            //string[] words = { "ThereAfterThemath", "AfterThem", "There", "math", "The", "he" };
            string[] words = { "cat", "dog", "cat dog", "catsdog", "rat", "catdogratcatdog" };
            string test = lw.FindLongestCompoundWord_2Loops(words);
            string expected = "catdogratcatdog";
            string actual = "";
            
            //actual = lw.FindLongestCompoundWord_TwoWords(words);
            //Assert.AreEqual(expected, actual);
            actual = lw.FindLongestCompoundWord_Memo(words);
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SmallestKNumbers_Test()
        {
            int[] arr = { 20, 2, 4, 10, 29, -5, 1, 100, 2 };
            int k = 3;

            SmallestKNumbers skn = new SmallestKNumbers();

            int[] actual = new int[k];
            //actual = skn.FindSmallestKNumbers(arr, k);
            //actual = skn.FindSmallestKNumbers_MaxHeap(arr, k);
            //actual = skn.FindSmallestKNumbers_NK(arr, k);
            actual = skn.FindSmallestKNumbers_SelectionRank(arr, k);
        }

        [TestMethod]
        public void ReSpace_Test()
        {
            string sentence = "inthisisawesome";
            HashSet<string> dictionary = new HashSet<string>()
            {
                "this",
                "is",
                "awesome"
            };
            
            ReSpace rs = new ReSpace();
            //string actual = rs.BestSplit(dictionary, sentence);

            ReSpace.ParseResult actual = rs.ReSpaceSentence(sentence, dictionary);
            //string str = rs.BestSplit(dictionary, sentence);

            string sentence2 = "jesslookedjustliketimherbrother";
            HashSet<string> dictionary2 = new HashSet<string>()
            {
                "looked",
                "just",
                "like",
                "her",
                "brother"
            };
            actual = rs.ReSpaceSentence(sentence2, dictionary2);
            //string str2 = rs.BestSplit(dictionary2, sentence2);

            var x = rs.parse(sentence2, dictionary2);
        }

        [TestMethod]
        public void BiNode_Test()
        {
            BiNodeDS bn = new BiNodeDS();
            BiNodeDS.BiNode[] nodes = new BiNodeDS.BiNode[7];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new BiNodeDS.BiNode(i);
            BiNodeDS.BiNode root = nodes[4];
            nodes[4].Node1 = nodes[2];
            nodes[4].Node2 = nodes[5];
            nodes[2].Node1 = nodes[1];
            nodes[2].Node2 = nodes[3];
            nodes[1].Node1 = nodes[0];
            nodes[5].Node2 = nodes[6];

            //var head = bn.ConvertBST_ToDLL(root);
            var head = bn.ConvertBST_ToDLL2(root);
            //bn.ConvertBST_ToDLL3(root);

            string output = bn.PrintList(root);
            System.Diagnostics.Trace.WriteLine(output);
        }

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
