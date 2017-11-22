using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class RepeatedElements
    {

        public static void RepeatingTest()
        {
            int[] arr = { 1, 6, 3, 1, 3, 6, 6 };
            printRepeating(arr, arr.Length);
        }
        static void printRepeating(int[] arr, int n)
        {
            // First check all the values that are
            // present in an array then go to that
            // values as indexes and increment by
            // the size of array
            for (int i = 0; i < n; i++)
            {
                int index = arr[i] % n;
                arr[index] += n;
            }

            // Now check which value exists more
            // than once by dividing with the size
            // of array
            for (int i = 0; i < n; i++)
            {
                if ((arr[i] / n) > 1)
                    Console.WriteLine(i + " ");
            }
        }

        public List<int> getDuplicatesWithoutExtraSpace(int[] arr)
        {
            List<int> arrDuplicates = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[Math.Abs(arr[i])] >= 0)
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                else
                    arrDuplicates.Add(Math.Abs(arr[i]));
            }
            return arrDuplicates;
        }
        public List<int> getDuplicatesUsingBruteForce(int[] arr)
        {
            List<int> arrDuplicates = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        arrDuplicates.Add(arr[i]);
                    }
                }
            }
            return arrDuplicates;
        }

        public int[] getDuplicatesUsingHashSet(int[] arr)
        {
            int[] arrDuplicates = new int[0];
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(arr[i]))
                {
                    Array.Resize(ref arrDuplicates, arrDuplicates.Length + 1);
                    arrDuplicates[arrDuplicates.Length - 1] = arr[i];
                }
                else
                    set.Add(arr[i]);
            }
            return arrDuplicates;
        }
    }
}
