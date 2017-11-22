using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    class BucketSort
    {
        public void Test()
        {
            int[] arr = { 22, 45, 12, 8, 10, 6, 72, 81, 33, 18, 50, 14 };
            BucketSortArr(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        private void BucketSortArr(int[] arr)
        {
            int bucketSize = 5;
            // Determine minimum and maximum values
            int minValue = arr[0];
            int maxValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
                else if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }
            int bucketsCount = (maxValue - minValue) / bucketSize + 1;
            List<List<int>> buckets = new List<List<int>>();
            for(int i = 0; i < bucketsCount; i++)
            {
                buckets.Add(new List<int>());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                buckets[(arr[i] - minValue) / bucketSize].Add(arr[i]);
            }

            int currentIndex = 0;
            for (int i = 0; i < buckets.Count; i++)
            {
                List<int> bucketElements = buckets[i];
                bucketElements.Sort();//We can implemet insertion sort here as a separate method
                for(int j = 0; j < bucketElements.Count; j++)
                {
                    arr[currentIndex++] = bucketElements[j];
                }
            }
        }
        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }
    }
}
