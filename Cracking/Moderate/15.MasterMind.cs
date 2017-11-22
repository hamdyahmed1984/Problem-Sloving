using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.15 Master Mind: The G ame of Master Mind is played as follows:
    /// The computer has four slots, and each slot will contain a ball that is red(R), yellow(Y), green(G) or blue(B). 
    /// For example, the computer might have RGGB(Slot #1 is red, Slots #2 and #3 are green, Slot #4 is blue).
    /// You, the user, are trying to guess the solution. You might, for example, guess YRGB.
    /// When you guess the correct color for the correct slot, you get a "hit:' If you guess a color that exists
    /// but is in the wrong slot, you get a "pseudo-hit:' Note that a slot that is a hit can never count as a pseudo-hit.
    /// For example, if the actual solution is RGBY and you guess GGRR , you have one hit and one pseudohit
    /// Write a method that, given a guess and a solution, returns the number of hits and pseudo-hits.
    /// </summary>
    class MasterMind
    {
        public void Test()
        {
            string solution = "RGBY";
            string guess = "GGRR";

            string res = Estimate(solution, guess).ToString();
        }

        private const int MAX_COLORS= 4; 
        private Result Estimate(string solution, string guess)
        {
            Result res = new Result();
            int[] frequenceis = new int[MAX_COLORS];

            for(int i =0; i < solution.Length; i++)
            {
                if(solution[i] == guess[i])
                {
                    res.Hits++;
                }
                else
                {
                    int code = Code(solution[i]);
                    frequenceis[code]++;
                }
            }

            for (int i = 0; i < solution.Length; i++)
            {
                int code = Code(guess[i]);
                if(solution[i] != guess[i] && code >= 0 && frequenceis[code] > 0)
                {
                    res.PseudoHits++;
                    frequenceis[code]--;
                }
            }

            return res;
        }

        private int Code(char c)
        {
            switch(c)
            {
                case 'B':
                    return 0;
                case 'G':
                    return 1;
                case 'R':
                    return 2;
                case 'Y':
                    return 3;
                default:
                    return -1;
            }
        }
        class Result
        {
            public int Hits { get; set; }
            public int PseudoHits { get; set; }
            public override string ToString()
            {
                return "Hits: " + Hits + ", PseohoHits: " + PseudoHits;
                //return base.ToString();
            }
        }
    }
}
