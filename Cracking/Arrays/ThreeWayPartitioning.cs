using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class ThreeWayPartitioning
    {
        public static void ThreeWayPartitionTest()
        {
            int[] arr = new int[] { 1, 14, 5, 20, 4, 2, 54, 20, 87, 98, 3, 1, 32 };
            ThreeWayPartition_2(arr, 14, 20);
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void ThreeWayPartition_1(int[] arr, int lowVal, int highVal)
        {
            int low = 0;
            int mid = 0;
            int hi = arr.Length - 1;
            while (mid <= hi)
            {
                if (arr[mid] < lowVal)
                {
                    Swap(arr, low, mid);
                    low++;
                    mid++;
                }
                else if(arr[mid] > highVal)
                {
                    Swap(arr, mid, hi);
                    hi--;
                }
                else//(arr[mid] >= lowVal && arr[mid] <= highVal)
                {
                    mid++;
                }
               
            }
        }

        private static void ThreeWayPartition_2(int[] arr, int lowVal, int highVal)
        {
            int low = 0;
            int hi = arr.Length - 1;
            for(int i = 0; i < hi;)
            {
                if (arr[i] < lowVal)
                {
                    Swap(arr, i, low);
                    i++;
                    low++;
                }
                else if (arr[i] > highVal)
                {
                    Swap(arr, i, hi);
                    hi--;                    
                }
                else
                    i++;
            }
        }
        static void Swap(int[] arr, int i, int j)
        {
            if (arr[i] != arr[j])
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
        }
    }
}
