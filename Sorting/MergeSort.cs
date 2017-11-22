using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class MergeSort
    {
        public static void Sort(ref int[] input)
        {
            Sort(ref input, 0, input.Length - 1);
        }

        private static void Sort(ref int[] input, int startindex, int endIndex)
        {
            if(startindex < endIndex)
            {
                int middleIndex = (endIndex + startindex) / 2;
                Sort(ref input, startindex, middleIndex);
                Sort(ref input, middleIndex + 1, endIndex);
                Merge(ref input, startindex, middleIndex, endIndex);
            }
        }

        private static void Merge(ref int[] input, int startindex, int middleIndex, int endIndex)
        {
            int i;
            int j;
            int k = startindex;

            int[] leftArr = new int[middleIndex - startindex + 1];
            int[] rightArr = new int[endIndex - middleIndex];
            for (i = 0; i < leftArr.Length; i++, k++)            
                leftArr[i] = input[k];
            for (j = 0; j < rightArr.Length; j++, k++)
                rightArr[j] = input[k];

            i = j = 0;
            k = startindex;

            //compare values in the 2 subarrays
            while(i < leftArr.Length && j < rightArr.Length)
            {
                if (leftArr[i] < rightArr[j])
                {
                    input[k] = leftArr[i];
                    i++;
                }
                else
                {
                    input[k] = rightArr[j];
                    j++;
                }
                k++;
            }
            //right sub array items are all copied (i < leftArr.Length means that all entries in rightArr copied and leftArr still not)
            while(i < leftArr.Length)
            {
                input[k] = leftArr[i];
                k++;
                i++;
            }
            //left sub array items are all copied (j < righArr.Length means that all entries in leftArr copied and lerightArrftArr still not)
            while (j < rightArr.Length)
            {
                input[k] = rightArr[j];
                k++;
                j++;
            }
        }
    }
}
