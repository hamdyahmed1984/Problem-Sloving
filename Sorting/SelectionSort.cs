using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SelectionSort<T>
    {
        private readonly IComparer<T> comparer = Comparer<T>.Default;
        public void Sort(ref T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = getMinIndex(arr, i);
                if (Compare(arr[i], arr[minIndex]) > 0)//(arr[i] > arr[minIndex])
                    Swap(ref arr, i, minIndex);
            }
        }
        int getMinIndex(T[] arr, int startIndex)
        {
            T minValue = arr[startIndex];
            int minIndex = startIndex;
            for (int i = minIndex + 1; i < arr.Length; i++)
            {
                if(Compare(arr[i], minValue) < 0)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        void Swap(ref T[] arr, int firstIndex, int secondIndex)
        {
            //arr[firstIndex] += arr[secondIndex];
            //arr[secondIndex] = arr[firstIndex] - arr[secondIndex];
            //arr[firstIndex] = arr[firstIndex] - arr[secondIndex];
            T tmp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = tmp;
        }

        int Compare(T x, T y)
        {
            return comparer.Compare(x, y);
        }
    }
}
