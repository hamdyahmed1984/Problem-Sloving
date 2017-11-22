using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class QuickSort
    {
        public void Test()
        {
            int[] arr1 = { 10, 80, 30, 90, 40, 50, 70 };
            int[] arr2 = new int[arr1.Length];
            int[] arr3 = new int[arr1.Length];
            arr1.CopyTo(arr2, 0);
            arr1.CopyTo(arr3, 0);

            QuickSortArr1(arr1, 0, arr1.Length - 1);
            Console.WriteLine(string.Join(",", arr1));

            QuickSortArr2(arr2, 0, arr2.Length - 1);
            Console.WriteLine(string.Join(",", arr2));

            QuickSortArr_Iterative(arr3, 0, arr3.Length - 1);
            Console.WriteLine(string.Join(",", arr3));
        }

        private void QuickSortArr1(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int index = Partition1(arr, left, right);
                if (left < index - 1) //Sort left half
                    QuickSortArr1(arr, left, index - 1);
                if (index + 1 < right)//Sort right half
                    QuickSortArr1(arr, index, right);
            }
        }

        private int Partition1(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];
            while(left <= right)
            {
                // Find element on left that should be on right
                while (arr[left] < pivot) left++;
                //Find element on right that should be on left
                while (arr[right] > pivot) right--;
                //Swap elements, and move left and right indices
                if (left <= right)
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private void QuickSortArr2(int[] arr, int low, int high)
        {
            if(low < high)
            {
                int pi = Partition2(arr, low, high);
                QuickSortArr2(arr, low, pi - 1);
                QuickSortArr2(arr, pi + 1, high);
            }
        }

        private int Partition2(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for(int j = low; j < high; j++)
            {
                if(arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            //We looped from start to the index of the arr - 1 hence we didn't process pivot so we finally swap pivot with i+1 to be in the correct place
            Swap(arr, i + 1, high);
            return i + 1;
        }

        public void QuickSortArr_Iterative(int[] arr, int start, int end)
        {
            int[] stack = new int[end - start + 1];
            int top = -1;
            stack[++top] = start;
            stack[++top] = end;
            while (top >= 0)
            {
                end = stack[top--];
                start = stack[top--];

                int pi = Partition2(arr, start, end);

                // If there are elements on left side of pivot,
                // then push left side to stack
                if (pi - 1 > start)
                {
                    stack[++top] = start;
                    stack[++top] = pi - 1;
                }
                // If there are elements on right side of pivot,
                // then push right side to stack
                if (pi + 1 < end)
                {
                    stack[++top] = pi + 1;
                    stack[++top] = end;
                }
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
