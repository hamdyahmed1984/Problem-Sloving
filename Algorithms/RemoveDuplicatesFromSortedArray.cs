using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDupsFromSortedArr(int[] arr)
        {
            int prev = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[prev])
                    arr[++prev] = arr[i];
            }
            return prev + 1;//This is the length of the arra after removing duplicates
        }
    }
}
