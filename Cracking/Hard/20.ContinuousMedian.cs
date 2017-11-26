using Cracking.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.20 Continuous Median: Numbers are randomly generated and passed to a method. 
    /// Write a program to find and maintain the median value as new values are generated.
    /// 
    /// SOLUTION:
    /// One solution is to use two priority heaps: a max heap for the values below the median, and a min heap for the values above the median.
    /// This will divide the elements roughly in half, with the middle two elements ast he top of the two heaps.
    /// This makes it trivial to find the median.
    /// What do we mean by "roughly in half;' though? "Roughly" means that, if we have an odd number of values, one heap will have an extra value.
    /// Observe that the following is true:
    /// If maxHeap. size() > minHeap.si z e(), maxHeap.top() will be the median.
    /// If maxHeap. size() == minHeap.size(), then the average of maxHeap.top() and minHeap.top () will be the median.
    /// By the way in which we rebalance the heaps, we will ensure that it is always maxHeap with extra element.
    /// The algorithm works as follows.When a new value arrives, it is placed in the maxHeap if the value is less than or equal to the median, 
    /// otherwise it is placed into the min Heap.
    /// The heap sizes can be equal, or the maxHeap may have one extra element.
    /// This constraint can easily be restored by shifting an element from one heap to the other.
    /// The median is available in constant time, by looking at the top element(s). 
    /// Updates takeO(log(n)) time.
    /// </summary>
    public class ContinuousMedian
    {
        private MinHeap minHeap = new MinHeap();
        private MaxHeap maxHeap = new MaxHeap();
        public void AddNewNumber(int randomNumber)
        {
            /*Note: addNewNumber maintains a condition that maxHeap.Size() >= minHeap.Size()*/
            if(maxHeap.Size() == minHeap.Size())
            {
                if(minHeap.Size() != 0 && randomNumber > minHeap.Peek())
                {
                    maxHeap.Add(minHeap.Poll());
                    minHeap.Add(randomNumber);
                }
                else
                {
                    maxHeap.Add(randomNumber);
                }
            }
            else
            {
                if(randomNumber < maxHeap.Peek())
                {
                    minHeap.Add(maxHeap.Poll());
                    maxHeap.Add(randomNumber);
                }
                else
                {
                    minHeap.Add(randomNumber);
                }
            }
        }

        public double GetMedian()
        {
            /*maxHeap is always at least as big as minHeap. So if maxHeap is empty, then minHeap is also.*/
            if (maxHeap.Size() == 0) return 0;
            if (maxHeap.Size() == minHeap.Size())
                return ((double)maxHeap.Peek() + (double)minHeap.Peek()) / 2;
            else//If maxHeap and minHeap are of different sizes, then maxHeap must have one extra element. Return maxHeap's top element.
                return maxHeap.Peek();
        }
    }
}
