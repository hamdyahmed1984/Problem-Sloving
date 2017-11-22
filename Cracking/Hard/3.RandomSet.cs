using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    public class RandomSet
    {
        public int[] GetRandomSet(int [] arr, int m)
        {
            int[] set = new int[m];
            //Fill in subset array with first part of original array
            for (int i = 0; i < m; i++)
            {
                set[i] = arr[i];
            }
            //Go through rest of original array.
            for(int i = m; i < arr.Length; i++)
            {
                int k = new Random().Next(0, i);//Random# between 0 and i, inclusive
                if (k < m)
                    set[k] = arr[i];
            }
            return set;
        }
    }
}
