using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.8 Circus Tower: A circus is designing a tower routine consisting of people standing atop one another's
    /// shoulders.For practical and aesthetic reasons, each person must be both shorter and lighter than
    /// the person below him or her.Given the heights and weights of each person in the circus, write a
    /// method to compute the largest possible number of people in such a tower.
    /// 
    /// EXAMPLE
    /// lnput(ht, wt): (65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110)
    /// Output: The longest tower is length 6 and includes from top to bottom:
    /// (56, 90) (60,95) (65,100) (68,110) (70,150) (75,190)
    /// 
    /// SOLUTION:
    /// The idea is that we sort the list by height then we get the longest increasing subsequence of this sorted list based on th weight
    /// </summary>
    public class CircusTower
    {
        public List<HtWt> FindBestSequence(List<HtWt> arr)
        {
            arr.Sort();

            List<List<HtWt>> solutions = new List<List<HtWt>>();
            List<HtWt> bestSeq = null;// = new List<HtWt>();
            for (int i = 0; i < arr.Count; i++)
            {
                List<HtWt> bestAtIndex = BestSeqAtIndex(arr, solutions, i);
                solutions.Add(bestAtIndex);
                bestSeq = Max(bestSeq, bestAtIndex);
            }
            return bestSeq;
        }

        private List<HtWt> BestSeqAtIndex(List<HtWt> arr, List<List<HtWt>> solutions, int index)
        {
            HtWt value = arr[index];
            List<HtWt> bestSeq = new List<HtWt>();
            for (int i = 0; i < index; i++)
            {
                List<HtWt> solutionAtIndex = solutions[i];
                //Here: we are sure that the list is sorted by height so no need to check for this as every item is higher in height than its previous                
                if (solutionAtIndex.Count == 0 || solutionAtIndex[solutionAtIndex.Count - 1].Weight < value.Weight)
                {
                    bestSeq = Max(bestSeq, solutionAtIndex);
                }
            }
            //Add the current value to the best solution
            bestSeq.Add(value);

            return bestSeq.ToList();//Convert new list to get rid of references issue.
        }

        private List<HtWt> Max(List<HtWt> lst1, List<HtWt> lst2)
        {
            if (lst1 == null) return lst2;
            if (lst2 == null) return lst1;

            return lst1.Count > lst2.Count ? lst1 : lst2;
        }
        public class HtWt: IComparable<HtWt>
        {
            public int Height { get; set; }
            public int Weight { get; set; }

            public HtWt(int h, int w)
            {
                this.Height = h;
                this.Weight = w;
            }

            public int CompareTo(HtWt other)
            {
                //We sort based on height, so if the 2 heights are equal we sort based on weight
                if (this.Height != other.Height)
                    return this.Height.CompareTo(other.Height);
                else
                    return this.Weight.CompareTo(other.Weight);
            }
        }
    }
}
