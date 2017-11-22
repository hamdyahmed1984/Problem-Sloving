using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            new RemoveDuplicatesFromSortedArray().RemoveDupsFromSortedArr(new int[]{ 1, 2, 2, 3, 4, 6, 6 });

            //RemoveDuplicatesFromArray rd = new RemoveDuplicatesFromArray();
            //int[] arr = new int[] { 1, 2, 3, 1, 2, 6, 6 };
            //int[] unique = rd.RemoveDuplicatesWithoutExtraSpace(arr);

            //FindDuplicatesInArray fd = new FindDuplicatesInArray();
            //int[] arr = new int[] { 1, 2, 3, 1, 2, 6, 6 };
            //int[] dupl0 = fd.getDuplicatesWithoutExtraSpace(arr);
            //int[] dupl1 = fd.getDuplicatesUsingBruteForce(arr);
            //int[] dupl2 = fd.getDuplicatesUsingHashSet(arr);
            //int[] dupl3 = fd.getDuplicatesUsingDictionary(arr);

            //MostFrequentNumber mfn = new MostFrequentNumber();
            //int[] arr = new int[] { 1, 2, 1, 3, 1, 4, 2, 5, 2, 2, 1 };
            //string ret = mfn.getMostFrequentNumber(arr);
            //Console.WriteLine(ret);


            //MagicOfThree mot = new MagicOfThree();
            //Console.WriteLine("Enter a number  ending with 3 to get the lowest multiple with all ones: ");
            //double numberOfOnes = mot.findNumberOfOnes(double.Parse(Console.ReadLine()));
            //for (int i = 0; i < numberOfOnes; i++)
            //{
            //    Console.Write("1");
            //}

            //BinarySearch<int> bs = new BinarySearch<int>();
            //Console.WriteLine("Enter values: ");
            //int[] arr = Enumerable.Range(1, 100000).ToArray();//Array.ConvertAll(Console.ReadLine().Split(' ').ToArray(), int.Parse);
            //Console.WriteLine("Enter search value: ");
            //int searchValue = int.Parse(Console.ReadLine());
            //int iterations = 0;
            //string exists = bs.CheckValue(arr, searchValue, ref iterations) ? "Exists" : "Not";
            ////string exists = bs.CheckValue(arr, searchValue) ? "Exists" : "Not";
            //Console.WriteLine(exists);
            //Console.WriteLine("Iterations: " + iterations.ToString());


            //BinarySearch<string> bs = new BinarySearch<string>();
            //string[] arr = new string[5] {"aa","bb","cc","dd","ee" };
            //int iterations = 0;
            //string exists = bs.CheckValue(arr, "bb", ref iterations) ? "Exists" : "Not";

            Console.ReadLine();
        }
    }
}
