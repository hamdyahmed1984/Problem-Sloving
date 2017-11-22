using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class Parens
    {
        public static void Test()
        {
            int n = 2;
            HashSet<string> validParens = GenerateValidParens(n);
            Console.WriteLine("Method1:");
            foreach (string str in validParens)
                Console.WriteLine(str);
            Console.WriteLine("Method2:");
            List<string> validParens2 = GenerateValidParens_Optimal(n);
            foreach (string str in validParens2)
                Console.WriteLine(str);
        }

        private static HashSet<string> GenerateValidParens(int n)
        {
            HashSet<string> validParens = new HashSet<string>();
            if( n == 0)
            {
                validParens.Add("");
                return validParens;
            }
            HashSet<string> prevSet = GenerateValidParens(n - 1);
            foreach(string str in prevSet)
            {
                for(int i = 0; i< str.Length; i++)
                {
                    if (str[i] == '(')
                    {
                        string newOne = InsertInside(str, i);
                        /*Add newOne to set if it's not already in there. 
                         * Note: HashSet automatically checks for duplicates before adding, so an explicit check is not necessary. */
                        validParens.Add(newOne);
                    }
                }
                validParens.Add("()" + str);
            }
            return validParens;
        }

        private static string InsertInside(string str, int i)
        {
            string before = str.Substring(0, i + 1);
            string after = str.Substring(i + 1);
            return before + "()" + after;
        }

        private static List<string> GenerateValidParens_Optimal(int n)
        {
            int leftRem = n;
            int rightRem = n;
            int index = 0;
            char[] arr = new char[n * 2];
            List<string> validParens = new List<string>();
            GenerateValidParens_Optimal(arr, leftRem, rightRem, index, validParens);
            return validParens;
        }

        private static void GenerateValidParens_Optimal(char[] arr, int leftRem, int rightRem, int index, List<string> validParens)
        {
            if (leftRem < 0 || rightRem < leftRem) return;
            if(leftRem == 0 && rightRem==0)
            {
                validParens.Add(new string(arr));
            }
            else
            {
                arr[index] = '(';
                GenerateValidParens_Optimal(arr, leftRem - 1, rightRem, index + 1, validParens);

                arr[index] = ')';
                GenerateValidParens_Optimal(arr, leftRem, rightRem - 1, index + 1, validParens);
            }
        }
    }
}
