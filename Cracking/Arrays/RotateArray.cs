using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class RotateArray
    {
        /// <summary>
        /// O(KN)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] RotateArrayByK2(int[] arr, int k)
        {
            while( k > 0)
            {
                int tmp = arr[0];
                for(int i = 1; i < arr.Length; i++)
                {
                    arr[i - 1] = arr[i];
                }
                arr[arr.Length - 1] = tmp;
                k--;
            }
            Console.WriteLine(arr);
            return arr;
        }
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] RotateArrayByK(int[] arr, int k)
        {
            Reverse(arr, 0, k - 1);
            Reverse(arr, k, arr.Length - 1);
            Reverse(arr, 0, arr.Length - 1);

            return arr;
        }

        public static void Reverse(int[] arr, int start, int end)
        {
            for(int i = start; i <= (start + end)/2; i++)
            {
                Swap(arr, i, (start + end) - i);
            }
            
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
