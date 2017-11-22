using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class QuickSort
    {
        public static void QuickSortTest()
        {
            int[] arr = new int[] { 1, 8, 2, 4, 3, 9, 5, 6, 7 };
            Console.WriteLine("Array before sorting:");
            Console.WriteLine(string.Join(",", arr));
            Sort_Iterative(arr, 0, arr.Length - 1);
            Console.WriteLine("Array after sorting:");
            Console.WriteLine(string.Join(",", arr));
        }

        public static void Sort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int pi = PartitionArray(arr, start, end);
                Sort(arr, start, pi - 1);
                Sort(arr, pi + 1, end);
            }
        }
        public static int PartitionArray(int[] arr, int start, int end)
        {
            int i = start - 1;
            int pivot = arr[end];
            for(int j = start; j < end; j++)
            {
                if(arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            //We looped fro start to the index of the arr - 1 hence we didn't process pivot so we finally swap pivot with i+1 to be in the correct place
            Swap(arr, i + 1, end);
            return i + 1;
        }

        public static void Sort_Iterative(int[] arr, int start, int end)
        {
            int[] stack = new int[end - start + 1];
            int top = -1;
            stack[++top] = start;
            stack[++top] = end;
            while(top >= 0)
            {
                end = stack[top--];
                start = stack[top--];

                int pi = PartitionArray(arr, start, end);

                // If there are elements on left side of pivot,
                // then push left side to stack
                if(pi - 1 > start)
                {
                    stack[++top] = start;
                    stack[++top] = pi - 1;
                }
                if (pi + 1 < end)
                {
                    stack[++top] = pi + 1;
                    stack[++top] = end;
                }
                // If there are elements on right side of pivot,
                // then push right side to stack
            }
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            //Swapping by XORing
            if (arr[index1] != arr[index2])//This check is a must as XORing value with itself results in 
            {
                arr[index1] = arr[index1] ^ arr[index2];
                arr[index2] = arr[index1] ^ arr[index2];
                arr[index1] = arr[index1] ^ arr[index2];
            }

            //int tmp = arr[index1];
            //arr[index1] = arr[index2];
            //arr[index2] = tmp;
        }
    }
}
