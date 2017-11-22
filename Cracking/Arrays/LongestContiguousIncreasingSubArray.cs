using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class LongestContiguousIncreasingSubArray
    {
        public static void GetLongestIncArrayTest()
        {
            int[] arr = {3,2,1,5,6,7,8,3,4,5,1,9,5,6 };
            int longestStart = 0, longestEnd = 0;
            GetLongestIncArray(arr, ref longestStart, ref longestEnd);            
        }

        private static void GetLongestIncArray(int[] arr, ref int longestStart, ref int longestEnd)
        {
            int start = 0, end = 0;
            bool inc = false;
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > arr[i-1])
                {
                    if(!inc)
                    {
                        start = i - 1;
                        end = i;
                        inc = true;
                    }
                    else
                    {
                        end = i;
                    }
                }
                else
                {
                    if (inc)
                    {
                        if ((end - start) > (longestEnd - longestStart))
                        {
                            longestStart = start;
                            longestEnd = end;
                            start = end = 0;
                        }
                        inc = false;
                    }
                }
            }            
        }
    }
}
