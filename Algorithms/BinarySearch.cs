using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BinarySearch<T>
    {
        private readonly IComparer<T> comparer = Comparer<T>.Default;
        public bool CheckValue(T[] arr, T val, ref int iterations)
        {
            int start = 0;
            int end = arr.Length - 1;
            int avg;
            while(start <= end)
            {
                iterations++;
                avg = (start + end) / 2;
                int compareResult = Compare(val, arr[avg]);
                if (compareResult == 0)
                    return true;
                else if(compareResult < 0)
                {
                    end = avg - 1;
                }
                else if(compareResult > 0)
                {
                    start = avg + 1;
                }
            }
            return false;
        }


        public bool CheckValue(T[] arr, T val)
        {
            int start = 0;
            int end = arr.Length - 1;
            return CheckValueRecursive(arr, val, start, end);
        }
        private bool CheckValueRecursive(T[] arr, T val, int start, int end)
        {
            if (start > end)
                return false;
            int avg = (start + end) / 2;
            int compareResult = comparer.Compare(val, arr[avg]);
            if (compareResult == 0)
                return true;
            else if (compareResult < 0)
                return CheckValueRecursive(arr, val, start, avg -1);
            else if (compareResult > 0)
                return CheckValueRecursive(arr, val, avg + 1, end);
            return false;
        }

        public int Compare(T x, T y)
        {
            return comparer.Compare(x, y);
        }
    }
}
