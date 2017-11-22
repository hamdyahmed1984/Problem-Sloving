using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class QuickSort
    {
        public static void Sort(ref int[] arr)
        {
            Sort(ref arr, 0, arr.Length - 1);
        }
        public static void Sort(ref int[] arr, int start, int end)
        {
            if(end > start)
            {
                int pivot = Partition(ref arr, start, end);
                Sort(ref arr, start, pivot - 1);
                Sort(ref arr, pivot + 1, end);
            }
        }

        private static int Partition(ref int[] arr, int start, int end)
        {
            int i = start;
            int j = start;
            while(i < end)
            {
                if (arr[i] < arr[end])
                {
                    Swap(ref arr, i, j);
                    j++;
                }
                i++;
            }
            Swap(ref arr, j, end);
            return j;
        }

        private static void Swap(ref int[] arr, int firstIndex, int seconIndex)
        {
            int tmp = arr[firstIndex];
            arr[firstIndex] = arr[seconIndex];
            arr[seconIndex] = tmp;
        }
    }
}
