using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.10 Majority Element: A majority element is an element that makes up more than half of the items in an array.
    /// Given a positive integers array, find the majority element. If there is no majority element, return -1.
    /// Do this in O(N) time and 0(1) space.
    /// Input: 1 2 5 9 5 9 5 5 5
    /// Output: 5
    /// </summary>
    public class MajorityElement
    {
        /// <summary>
        /// Runtime: O(N^2)
        /// Space: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMajorityElement_BF(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int majElm = arr[i];
                if (IsMajorityElement(arr, majElm))
                    return majElm;
            }
            return -1;
        }
        /// <summary>
        /// Runtime: O(N)
        /// Space: O(N)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMajorityElement_Better(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int elm = arr[i];
                if (map.ContainsKey(elm))
                    map[elm]++;
                else
                    map.Add(elm, 1);
            }
            int reqCount = arr.Length / 2 + 1;//the count for an element to reach to be considered as a majority element
            foreach(int elm in map.Keys)
            {
                if(map[elm] >= reqCount)
                {
                    return elm;
                }
            }
            return -1;
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMajorityElement_Optimal(int[] arr)
        {
            int candidate = GetMajorityCandidateElement(arr);
            return IsMajorityElement(arr, candidate) ? candidate : -1;
        }

        private int GetMajorityCandidateElement(int[] arr)
        {
            int count = 0;
            int majElm = 0;
            foreach (int elm in arr)
            {
                if (count == 0) //No majority element in previous set.
                {
                    majElm = elm;
                }
                if (elm == majElm)
                    count++;
                else
                    count--;
            }
            return majElm;
        }

        private bool IsMajorityElement(int[] arr, int majElm)
        {
            int count = 0;
            for(int i = 0;i < arr.Length; i++)
            {
                if (arr[i] == majElm)
                    count++;
            }
            return count > arr.Length / 2;
        }
    }
}
