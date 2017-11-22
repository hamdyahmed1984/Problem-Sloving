using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cracking.Graphs;

namespace Cracking.Sorting_Searching
{
    class HeapSort
    {
        public void Test()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int[] arr2 = { 12, 11, 13, 5, 6, 7 };

            HeapSortArr(arr);
            Console.WriteLine(string.Join(",", arr));

            HeapSortArr2(arr2);
            Console.WriteLine(string.Join(",", arr2));
        }

        private void HeapSortArr(int[] arr)
        {
            int n = arr.Length;
            // Build heap (rearrange array)
            //We start from n/2 - 1 down to 0 because all nodes at indeces starting from n/2 to n-1 are leaves and off course leaf nodes(single leaf) are max heapes by nature.
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
            // One by one extract an element(max) from heap
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                int tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;
                // call max heapify on the reduced heap
                Heapify(arr, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        private void Heapify(int[] arr, int n, int i)
        {
            int largest = i;  // Initialize largest as root
            int left = 2 * i + 1;  // left = 2*i + 1
            int right = 2 * i + 2;  // right = 2*i + 2
            // If left child is larger than root
            if (left < n && arr[left] > arr[largest])//Checking left < n to make sure we operate on the reduced heap size
                largest = left;
            // If right child is larger than largest so far
            if (right < n && arr[right] > arr[largest])//Checking right < n to make sure we operate on the reduced heap size
                largest = right;
            // If largest is not root
            if (largest != i)
            {
                int tmp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = tmp;
                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }

        private void HeapSortArr2(int[] arr)
        {
            MinHeap heap = new MinHeap();
            for (int i = 0; i < arr.Length; i++)
                heap.Add(arr[i]);

            for (int i = 0; i < arr.Length; i++)
                arr[i] = heap.Poll();
        }
    }
}
