using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.21 Volume of Histogram: Imagine a histogram (bar graph).
    /// Design an algorithm to compute the volume of water it could hold if someone poured water across the top.
    /// You can assume that each histogram bar has width 1.
    /// EXAMPLE
    /// Input{ 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 5, 0, 1, 0, 0, 0}
    /// Output: 26
    /// (Black bars are the histogram.Gray is water.)
    /// </summary>
    public class VolumeOfHistogram
    {
        /// <summary>
        /// O(N^2) time in the worst case, where N is the number of bars in the histogram.
        /// This is because we have to repeatedly scan the histogram to find the max height.
        /// </summary>
        /// <param name="histogram"></param>
        /// <returns></returns>
        public int GetHistogramVolume_Recursive(int[] histogram)
        {
            int start = 0;
            int end = histogram.Length - 1;
            int indexOfMax = FindIndexOfMax(histogram, start, end);
            int leftVol = ComputeLeftPartVol(histogram, start, indexOfMax);
            int rightVol = ComputeRightPartVol(histogram, indexOfMax, end);
            return leftVol + rightVol;
        }

        private int ComputeLeftPartVol(int[] histogram, int start, int indexOfMax)
        {
            if (start >= indexOfMax) return 0;
            int indexOfSecondMax = FindIndexOfMax(histogram, start, indexOfMax - 1);
            int sum = 0;
            sum += ComputeVolBetween2Bars(histogram, indexOfSecondMax/*smaller index*/, indexOfMax/*bigger index*/);
            sum += ComputeLeftPartVol(histogram, start, indexOfSecondMax);
            return sum;
        }

        private int ComputeRightPartVol(int[] histogram, int indexOfMax, int end)
        {
            if (indexOfMax >= end) return 0;
            int indexOfSecondMax = FindIndexOfMax(histogram, indexOfMax + 1, end);
            int sum = 0;
            sum += ComputeVolBetween2Bars(histogram, indexOfMax/*smaller index*/, indexOfSecondMax/*bigger index*/);
            sum += ComputeRightPartVol(histogram, indexOfSecondMax, end);
            return sum;
        }

        private int ComputeVolBetween2Bars(int[] histogram, int start, int end)
        {
            if (start >= end) return 0;
            int min = Math.Min(histogram[start], histogram[end]);
            int sum = 0;
            for(int i = start + 1; i < end; i++)
            {
                sum += min - histogram[i];
            }
            return sum;
        }

        private int FindIndexOfMax(int[] histogram, int start, int end)
        {
            int indexOfMax = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (histogram[i] > histogram[indexOfMax])
                    indexOfMax = i;
            }
            return indexOfMax;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Runtime: O(N), Space: O(N)
        /// 
        /// In two sweeps through the histogram (one moving right to left and the other moving left to right), we can
        /// create a table that tells us, from any index i, the location of the max index on the right and the max index on the left.
        /// INDEX:           0 1 2 3 4 5 6 7 8 9
        /// HEICHT:          3 1 4 0 0 6 0 3 0 2
        /// INDEX LEFT MAX:  0 0 2 2 2 5 5 5 5 5
        /// INDEX RIGHT MAX: 5 5 5 5 5 5 7 7 9 9
        /// </summary>
        /// <param name="histogram"></param>
        /// <returns></returns>
        public int GetHistogramVolume_Recursive_Optimized(int[] histogram)
        {
            if (histogram == null || histogram.Length == 0) return 0;
            int start = 0;
            int end = histogram.Length - 1;
            int[] leftMaxIndeces = ConstructLeftMaxIndeces(histogram);//At index i, there is the index of the max element on left of i
            int[] rightMaxIndeces = ConstructRightMaxIndeces(histogram);//At index i, there is the index of the max element of right of i
            int indexOfMax = rightMaxIndeces[0];// Get overall max
            int leftVol = ComputeLeftPartVol_Optimized(histogram, start, indexOfMax, leftMaxIndeces);
            int rightVol = ComputeRightPartVol_Optimized(histogram, indexOfMax, end, rightMaxIndeces);
            return leftVol + rightVol;
        }

        private int[] ConstructLeftMaxIndeces(int[] histogram)
        {
            int[] leftMaxIndeces = new int[histogram.Length];
            int maxIndex = 0;
            for(int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] >= histogram[maxIndex])
                    maxIndex = i;
                leftMaxIndeces[i] = maxIndex;
            }
            return leftMaxIndeces;
        }

        private int[] ConstructRightMaxIndeces(int[] histogram)
        {
            int[] rightMaxIndeces = new int[histogram.Length];
            int maxIndex = histogram.Length - 1;
            for(int i = histogram.Length - 1; i >= 0; i--)
            {
                if (histogram[i] >= histogram[maxIndex])
                    maxIndex = i;
                rightMaxIndeces[i] = maxIndex;
            }
            return rightMaxIndeces;
        }

        private int ComputeLeftPartVol_Optimized(int[] histogram, int start, int indexOfMax, int[] leftMaxIndeces)
        {
            if (start >= indexOfMax) return 0;
            int indexOfSecondMax = leftMaxIndeces[indexOfMax - 1];
            int sum = 0;
            sum += ComputeVolBetween2Bars(histogram, indexOfSecondMax/*smaller index*/, indexOfMax/*bigger index*/);
            sum += ComputeLeftPartVol_Optimized(histogram, start, indexOfSecondMax, leftMaxIndeces);
            return sum;
        }

        private int ComputeRightPartVol_Optimized(int[] histogram, int indexOfMax, int end, int[] rightMaxIndeces)
        {
            if (indexOfMax >= end) return 0;
            int indexOfSecondMax = rightMaxIndeces[indexOfMax + 1];
            int sum = 0;
            sum += ComputeVolBetween2Bars(histogram, indexOfMax/*smaller index*/, indexOfSecondMax/*bigger index*/);
            sum += ComputeRightPartVol_Optimized(histogram, indexOfSecondMax, end, rightMaxIndeces);
            return sum;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Runtime: O(N), Space: O(N)
        /// 
        /// we were able to precompute the height of the tallest bar on the left and right of each index.
        /// The minimums of these will indicate the "water level" at a bar.
        /// The difference between the water level and the height of this bar will be the volume of water.
        /// HEIGHT:    0 0 4 0 0 6 0 0 3 0 8 0 2 0 5 2 0 3 0 0
        /// LEFT MAX:  0 0 4 4 4 6 6 6 6 6 8 8 8 8 8 8 8 8 8 8
        /// RIGHT MAX: 8 8 8 8 8 8 8 8 8 8 8 5 5 5 5 3 3 3 0 0
        /// MIN:       0 0 4 4 4 6 6 6 6 6 8 5 5 5 5 3 3 3 0 0
        /// DELTA:     0 0 0 4 4 0 6 6 3 6 0 5 3 5 0 1 3 0 0 0
        /// 
        /// Our algorithm now runs in a few simple steps:
        /// 1. Sweep left to right, tracking the max height you've seen and setting left max.
        /// 2. Sweep right to left, tracking the max height you've seen and setting right max.
        /// 3. Sweep across the histogram, computing the minimum of the left max and right max for each index.
        /// 4. Sweep across the histogram, computing the delta between each minimum and the bar.Sum these deltas.
        /// 
        /// In the actual implementation, we don't need to keep so much data around. Steps 2, 3, and 4 can be merged
        /// into the same sweep. First, compute the left maxes in one sweep. Then sweep through in reverse, tracking
        /// the right max as you go. At each element, calculate the min of the left and right max and then the delta
        /// between that (the "min of maxes") and the bar height.Add this to the sum.
        /// </summary>
        /// <param name="histogram"></param>
        /// <returns></returns>
        public int GetHistogramVolume_Simplified_Optimized(int[] histogram)
        {
            int[] leftMaxes = new int[histogram.Length];
            int[] rightMaxes = new int[histogram.Length];
            int[] mins = new int[histogram.Length];
            int[] deltas = new int[histogram.Length];

            //Get Left maxes
            int leftMax = histogram[0];
            for(int i = 0; i < histogram.Length; i++)
            {
                leftMax = Math.Max(leftMax, histogram[i]);
                leftMaxes[i] = leftMax;
            }

            //Get Right Maxes
            int rightMax = histogram[histogram.Length - 1];
            for(int i = histogram.Length - 1; i >= 0; i--)
            {
                rightMax = Math.Max(rightMax, histogram[i]);
                rightMaxes[i] = rightMax;
            }

            //Get min of leftMaxes and rightMaxes
            for (int i = 0; i < histogram.Length; i++)
            {
                mins[i] = Math.Min(leftMaxes[i], rightMaxes[i]);
            }

            //Get deltas of mins and histogram heights which are our required sum
            for (int i = 0; i < histogram.Length; i++)
            {
               // if (mins[i] > histogram[i])
                    deltas[i] = mins[i] - histogram[i];
            }

            //Get the required volumes bu summing up
            int sum = 0;
            for(int i = 0; i < deltas.Length; i++)
            {
                sum += deltas[i];
            }
            return sum;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Runtime: O(N), Space: O(N)
        /// 
        /// This is the same as the above method but cleaner after removing some loops.
        /// 
        /// /* Go through each bar and compute the volume of water above it.
        /// Volume of water at a bar = height - min(tallest bar on left, tallest bar on right) !!!, I think it is the reverse
        /// [where above equation is positive]
        /// Compute the left max in the first sweep, then sweep again to compute the right max, minimum of the bar heights, and the delta. */
        /// </summary>
        /// <param name="histogram"></param>
        /// <returns></returns>
        public int GetHistogramVolume_Simplified_Optimized_Clean(int[] histogram)
        {
            int[] leftMaxes = new int[histogram.Length];

            //Get Left maxes
            int leftMax = histogram[0];
            for (int i = 0; i < histogram.Length; i++)
            {
                leftMax = Math.Max(leftMax, histogram[i]);
                leftMaxes[i] = leftMax;
            }

            int sum = 0;
            int rightMax = histogram[histogram.Length - 1];
            for (int i = histogram.Length - 1; i >= 0; i--)
            {
                rightMax = Math.Max(rightMax, histogram[i]);

                int secondTallestBar = Math.Min(rightMax, leftMaxes[i]);
                /*If there are taller things on the left and right side, then there is water above this bar. Compute the volume and add to the sum.*/
                if (secondTallestBar > histogram[i])
                {
                    sum += secondTallestBar - histogram[i];
                }
            }
            return sum;
        }
    }
}
