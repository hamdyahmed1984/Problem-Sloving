using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /*
     * 10.1 Sorted Merge: You are given two sorted arrays, A and B, where A has a large enough buffer at the end to hold B.
     * Write a method to merge B into A in sorted order.
     * 
     * 
     * Since we know that A has enough buffer at the end, we won't need to allocate additional space.
     * Our logic should involve simply comparing elements of A and B and inserting them in order, until we've exhausted all elements in A and in B.
     * The only issue with this is that if we insert an element into the front of A, then we'll have to shift the existing elements backwards to make room for it.
     * It's better to insert elements into the back of the array, where there's empty space. 
     * The code below does just that. It works from the back of A and B, moving the largest elements to the back of A.
     * Note that you don't need to copy the contents of A after running out of elements in B. They are already in place.
     */
    class SortedMerge
    {
        public void Test()
        {
            int?[] A = { 1, 5, 7, 8, 9, 20, 99, null, null, null, null, null, null, null, null, null, null, null, null, null };
            int?[] B = { 8, 10, 10, 20 };

            SortedMergeArrays(A, B, 7, 4);
            Console.WriteLine(string.Join(",", A));
        }

        private void SortedMergeArrays(int?[] A, int?[] B, int sizeA, int sizeB)
        {
            int indexA = sizeA - 1;
            int indexB = sizeB - 1;
            int indexMerged = sizeA + sizeB - 1;
            while(indexB >= 0)
            {
                if(indexA >= 0 && A[indexA] > B[indexB])
                {
                    A[indexMerged--] = A[indexA--];
                }
                else
                {
                    A[indexMerged--] = B[indexB--];
                }
            }
        }
    }
}
