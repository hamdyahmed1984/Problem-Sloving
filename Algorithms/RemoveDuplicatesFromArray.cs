using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class RemoveDuplicatesFromArray
    {
        public int[] RemoveDuplicatesWithoutExtraSpace(int[] arr)
        {
            int end = arr.Length - 1;
            for(int i = 0; i < end; i++)
            {
                for(int j = i + 1; j < end; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        for (int k = j; k < end; k++)
                            arr[k] = arr[k + 1];                    
                        end--;
                        j--;
                    }
                }
            }
            for (int i = end; i < arr.Length; i++)
                arr[i] = default(int);
            return arr;
        }
    }
}
