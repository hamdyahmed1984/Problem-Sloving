using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class ReverseArray
    {
        public int[] Reverse(int[] arr)
        {
            for(int i = 0; i < arr.Length / 2; i++)
            {
                int tmp = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = arr[i];
                arr[i] = tmp;
            }
            return arr;
        }
    }
}
