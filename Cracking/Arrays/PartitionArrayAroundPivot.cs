using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class PartitionArrayAroundPivot
    {
        public static void PartitionArrayTest()
        {
            int[] arr = new int[] { 1, 8, 2, 4, 3, 9, 5, 6, 7 };
            Console.WriteLine("Array before partitioning:");
            Console.WriteLine(string.Join(",", arr));
            PartitionArray1(arr, 8);
            Console.WriteLine("Array after partitioning:");
            Console.WriteLine(string.Join(",", arr));
        }

        public static void PartitionArray1(int[] arr, int pivotIndex)
        {
            int pivot = arr[pivotIndex];
            int i = -1;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if(arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, pivotIndex);
        }
        public static void PartitionArray2(int[] arr, int pivotIndex)
        {
            int pivot = arr[pivotIndex];
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                if (arr[i] < pivot)
                    i++;
                else if(arr[i] == pivot)
                {
                    Swap(arr, i, j);//We don't decrement j if thay arr[i] is equal to the pivot
                }
                else
                {
                    Swap(arr, i, j);
                    j--;
                }
            }
            //return arr;
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            ////Swapping by XORing
            //arr[index1] = arr[index1] ^ arr[index2];
            //arr[index2] = arr[index1] ^ arr[index2];
            //arr[index1] = arr[index1] ^ arr[index2];

            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
