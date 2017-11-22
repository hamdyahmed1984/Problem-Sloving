using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cracking.Graphs;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.14 Smallest K: Design an algorithm to find the smallest K numbers in an array.
    /// </summary>
    public class SmallestKNumbers
    {
        /// <summary>
        /// O(N log N)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] FindSmallestKNumbers(int[] arr, int k)
        {
            if (k <= 0 || k > arr.Length)
                throw new IndexOutOfRangeException();
            Array.Sort(arr);
            int[] smallestK = new int[k];
            for (int i = 0; i < k; i++)
                smallestK[i] = arr[i];
            return smallestK;
        }

        /// <summary>
        /// O( N log K), where N is the array size and K is the number of smalles array size we want
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] FindSmallestKNumbers_MaxHeap(int[] arr, int k)
        {
            if (k <= 0 || k > arr.Length)
                throw new IndexOutOfRangeException();

            Cracking.Graphs.MaxHeap heap = CreateMaxHeapWithSmallestKElements(arr, k);
            return ConvertMaxHeapToArr(heap);
        }

        /* Create max heap of smallest k elements. */
        private MaxHeap CreateMaxHeapWithSmallestKElements(int[] arr, int k)
        {
            Cracking.Graphs.MaxHeap heap = new MaxHeap();
            foreach(int num in arr)
            {
                if (heap.Size() < k)//If space remaining
                    heap.Add(num);
                else
                {
                    if(num < heap.Peek())///If full and top is small
                    {
                        heap.Poll();//Remove the top, which is the max
                        heap.Add(num);//Then insert the new num
                    }
                }
            }
            return heap;
        }

        private int[] ConvertMaxHeapToArr(MaxHeap heap)
        {
            int[] smalestK = new int[heap.Size()];
            while(heap.Size() > 0)
            {
                smalestK[heap.Size() - 1] = heap.Poll();
            }
            return smalestK;
        }

        /// <summary>
        /// O(N*K)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] FindSmallestKNumbers_NK(int[] arr, int k)
        {
            if (k <= 0 || k > arr.Length)
                throw new IndexOutOfRangeException();

            int[] smallestK = new int[k];

            int min = int.MaxValue;
            int minIndex = -1;
            for (int kIndex = 0; kIndex < k; kIndex++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int num = arr[i];
                    if (num < min && num != int.MaxValue)
                    {
                        min = num;
                        minIndex = i;
                    }
                }
                smallestK[kIndex] = min;
                min = int.MaxValue;
                arr[minIndex] = int.MaxValue;//We set the min elemnt it max value so we mark it and not use it gain in later iterations
            }
            
            return smallestK;
        }

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] FindSmallestKNumbers_SelectionRank(int[] arr, int k)
        {
            if (k <= 0 || k > arr.Length)
                throw new IndexOutOfRangeException();
            /*Get item with rank k - 1.*/
            int threshold = Rank(arr, k - 1);

            int[] smallestK = new int[k];
            int count = 0;
            /*Copy elements smaller than the threshold element.*/
            foreach (int num in arr)
            {
                if (num < threshold)
                    smallestK[count++] = num;
            }
            /*If there's still room left, this must be for elements equal to the threshold element. Copy those in.
             * We can't simply copy all elements less than or equal to threshold
             *   into the array. Since we have duplicates, there could be many more than K elements that are less than or equal
             *   to threshold. (We also can't just say "okay, only copy K elements over:' We could inadvertently fill up the
             *   array early on with "equal" elements, and not leave enough space for the smaller ones.)
             *   The solution for this is fairly simple: only copy over the smaller elements first, then fill up the array with equal
             *   elements at the end.
             */
            while (count < k)
            {
                smallestK[count++] = threshold;
            }
            return smallestK;
        }

        private int Rank(int[] arr, int k)
        {
            if (k > arr.Length)
                throw new InvalidOperationException();
            return Rank(arr, k, 0, arr.Length - 1);
        }

        private int Rank(int[] arr, int k, int start, int end)
        {
            Random rand = new Random();
            /*Partition array around an arbitrary pivot.*/
            int pivot = arr[rand.Next(start, end)];
            PartitionResult pr = Partition(arr, pivot, start, end);

            int leftSize = pr.LeftSize;
            int middleSize = pr.MiddleSize;

            if(k < leftSize)//Rank k is in left side
            {
                return Rank(arr, k, start, start + leftSize - 1);
            }
            else if( k < leftSize + middleSize)//Rank k is in middle side
            {
                return pivot;//middle element are all pivot element
            }
            else//Rank k is in right side
            {
                return Rank(arr, k - leftSize - middleSize, start + leftSize + middleSize, end);
            }
        }

        private PartitionResult Partition(int[] arr, int pivot, int start, int end)
        {
            int left = start;/*Stays at (right) edge of left side.*/
            int middle = start;/*Stays at (right) edge of middle.*/
            int right = end;/*Stays at (left) edge of right side.*/
            while(middle <= right)
            {
                if(arr[middle] < pivot)
                {
                    /* Middle is smaller than the pivot. 
                     * Left is either smaller or equal to the pivot. 
                     * Either way, swap them. Then middle and left should move by one.
                     */
                    Swap(arr, left, middle);
                    left++;
                    middle++;
                }
                else if(arr[middle] > pivot)
                {
                    /* Middle is bigger than the pivot. Right could have any value. Swap them, 
                     * then we know that the new right is bigger than the pivot. Move right by one.
                     */
                    Swap(arr, middle, right);
                    right--;
                }
                else if(arr[middle] == pivot)
                {
                    /* Middle is equal to the pivot. Move by one. */
                    middle++;
                }
            }
            return new PartitionResult(left - start, right - left + 1);
        }

        private void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        class PartitionResult
        {
            public int LeftSize { get; set; }
            public int MiddleSize { get; set; }
            public PartitionResult(int leftSize, int middleSize)
            {
                this.LeftSize = leftSize;
                this.MiddleSize = middleSize;
            }
        }
    }
}
