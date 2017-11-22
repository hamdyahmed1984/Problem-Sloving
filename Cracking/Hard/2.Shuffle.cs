using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17 .2 Shuffle: Write a method to shuffle a deck of cards. It must be a perfect shuffle-in other words, 
    /// each of the 52! permutations of the deck has to be equally likely.Assume that you are given a random number generator which is perfect.
    /// </summary>
    public class Shuffle
    {
        public int[] ShuffleArray_Iteratively(int[] arr)
        {
            Random rand = new Random();
            for(int i = 0; i < arr.Length; i ++)
            {
                int k = rand.Next(0, i);

                int tmp = arr[i];
                arr[i] = arr[k];
                arr[k] = tmp;
            }
            return arr;
        }

        public int[] ShuffleArray_Recursively(int[] arr, int i)
        {
            if (i == 0) return arr;
            ShuffleArray_Recursively(arr, i - 1);//Shuffle earlier part

            int k = new Random().Next(0, i);//Pick random index to swap with

            int tmp = arr[i];
            arr[i] = arr[k];
            arr[k] = tmp;
            /*Return shuffled array*/
            return arr;
        }
    }
}
