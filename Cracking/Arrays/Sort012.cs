using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class Sort012
    {
        public static void Sort012Test()
        {
            int[] arr = new int[] { 0,2,1,0,0,0,1,1,0,2,2,2,2,2,0,1,2,0 };
            Sort012Array(arr);
            Console.WriteLine(string.Join(", ", arr));
            
        }

        private static void Sort012Array(int[] arr)
        {
            int low = 0;
            int mid = 0;
            int hi = arr.Length - 1;
            while(mid <= hi)
            {
                if(arr[mid] == 0)
                {
                    Swap(arr, low, mid);
                    low++;
                    mid++;
                }
                else if(arr[mid] == 1)
                {
                    mid++;
                }
                else if(arr[mid] == 2)//Must equal 2 and we need to error check for this
                {
                    Swap(arr, mid, hi);
                    hi--;
                }
            }
        }

        static void Swap(int[]arr, int i, int j)
        {
            if(arr[i] != arr[j])
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
        }
    }
}
