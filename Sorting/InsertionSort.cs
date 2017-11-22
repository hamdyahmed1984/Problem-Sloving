using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertionSort<T>
    {
        IComparer<T> comparer = Comparer<T>.Default;
        public void Sort(ref T[] arr)
        {           
            for (int i = 1; i < arr.Length; i++)
            {
                int index = i - 1;
                T tmp = arr[i];
                while (index >= 0 && Compare(arr[index], tmp) > 0)
                {
                    arr[index + 1] = arr[index];
                    index--;
                }
                arr[index + 1] = tmp;

            }
        }
        int Compare(T x, T y)
        {
            return comparer.Compare(x, y);
        }
    }
}
