using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.16 The Masseuse: A popular masseuse receives a sequence of back-to-back appointment requests and is debating which ones to accept.
    /// She needs a 15-minute break between appointments and therefore she cannot accept any adjacent requests.
    /// Given a sequence of back-to-back appointment requests (all multiples of 15 minutes, none overlap, and none can be moved), 
    /// find the optimal(highest total booked minutes) set the masseuse can honor.
    /// Return the number of minutes.
    /// EXAMPLE
    /// Input: {30, 15, 60, 75, 45, 15, 15, 45}
    /// Output180 minutes({ 30, 60, 45, 45}).
    /// </summary>
    public class TheMasseuse
    {
        /// <summary>
        /// Runtime: O (2^N) because at each element we're making two choices and we do this n times(where n is the number of massages).
        /// Space: O(N) due to recursive call stack
        /// 
        /// We have essentially a sequence of choices as we walk down the list of appointments: 
        /// Do we use this appointment or do we not? If we use appointment i, we must skip appointment i + 1 as we can't take back-to-back appointments. 
        /// Appointment i + 2 is a possibility (but not necessarily the best choice).
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public int MaxMinutes_Recursion(int[] requests)
        {
            return MaxMinutes_Recursion(requests, 0);
        }

        private int MaxMinutes_Recursion(int[] requests, int index)
        {
            if (index >= requests.Length) return 0;
            /*Best with this reservation.*/
            int bestWith = requests[index] + MaxMinutes_Recursion(requests, index + 2);
            /*Best without this reservation.*/
            int bestWithout = MaxMinutes_Recursion(requests, index + 1);
            /*Return best of this subarray, starting from index.*/
            return Math.Max(bestWith, bestWithout);
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(N), due to the memo array and also the recursive call stack
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public int MaxMinutes_Memo(int[] requests)
        {
            int[] memo = new int[requests.Length];
            return MaxMinutes_Memo(requests, 0, memo);
        }

        private int MaxMinutes_Memo(int[] requests, int index, int[] memo)
        {
            if (index >= requests.Length) return 0;
            if (memo[index] == 0)
            {
                /*Best with this reservation.*/
                int bestWith = requests[index] + MaxMinutes_Memo(requests, index + 2, memo);
                /*Best without this reservation.*/
                int bestWithout = MaxMinutes_Memo(requests, index + 1, memo);
                /*Return best of this subarray, starting from index.*/
                memo[index] = Math.Max(bestWith, bestWithout);
            }
            return memo[index];
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(N), due to the memo array
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public int MaxMinutes_Iterative(int[] requests)
        {
            /*Allocating two extra slots in the array so we don't have to do bounds checking in array dp*/
            int[] dp = new int[requests.Length + 2];
            for(int i = requests.Length - 1; i >= 0; i--)
            {
                int bestWith = requests[i] + dp[i + 2];
                int bestWithout = dp[i + 1];
                dp[i] = Math.Max(bestWith, bestWithout);
            }
            return dp[0];
        }

        /// <summary>
        /// Runtime: O(N)
        /// Space: O(1)
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public int MaxMinutes_Optimal(int[] requests)
        {
            int itmAfterCurrent = 0, itmAfterAfterCurrent = 0;
            for(int i = 0; i < requests.Length; i++)
            {
                int bestWith = requests[i] + itmAfterAfterCurrent;
                int bestWithout = itmAfterCurrent;
                int current = Math.Max(bestWith, bestWithout);

                itmAfterAfterCurrent = itmAfterCurrent;
                itmAfterCurrent = current;
            }
            return itmAfterCurrent;
        }
    }
}
