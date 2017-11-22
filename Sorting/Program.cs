using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 2, 5, 3, 1, 4, 7, 6 };
            //SelectionSort<int> ss = new SelectionSort<int>();

            //string[] arr = new string[] { "a", "d", "c", "b" };
            //SelectionSort<string> ss = new SelectionSort<string>();

            //int[] arr = new int[] { 2, 5, 3, 1, 4, 7, 6 };
            //InsertionSort<int> ss = new InsertionSort<int>();

            //Console.WriteLine(string.Format("Array before sort: {0}", string.Join(",", arr)));
            //ss.Sort(ref arr);
            //Console.WriteLine(string.Format("Array after sort: {0}", string.Join(",", arr)));
            //Console.ReadLine();

            //int[] arr = new int[] { 2, 5, 3, 1, 4, 7, 6 };
            //Console.WriteLine(string.Format("Array before sort: {0}", string.Join(",", arr)));
            //MergeSort.Sort(ref arr);
            //Console.WriteLine(string.Format("Array after sort: {0}", string.Join(",", arr)));

            int[] arr = new int[] { 7, 2, 1, 8, 6, 3, 5, 4 };// { 2, 5, 3, 1, 4, 7, 6 };
            Console.WriteLine(string.Format("Array before sort: {0}", string.Join(",", arr)));
            QuickSort.Sort(ref arr);
            Console.WriteLine(string.Format("Array after sort: {0}", string.Join(",", arr)));

        }
    }
}
