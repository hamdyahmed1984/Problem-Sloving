using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    /*
     * 8.14 Boolean Evaluation: Given a boolean expression consisting of the symbols 0 (false), 1 (true), & (AND), | (OR), and ^ (XOR), 
     * and a desired boolean result value result, implement a function to count the number of ways of parenthesizing the expression such that it evaluates to result.
     * The expression should be fully parenthesized(e.g., ( 0) A( 1)) but not extraneously(e.g., ((( 0)) /\ ( 1)) ).
     * 
     * EXAMPLE
     * countEval("l/\01011", false) -> 2
     * countEval("0&0&0&1All0", true)-> 10
    */
    class BooleanEvaluation_CountWays
    {
        public void Test()
        {
            string exp = "1^0|0|1";
            bool result = false;
            int ways = CountEvals(exp, result);
            Console.WriteLine(ways);

            ways = CountEvals_Memo(exp, result, new Dictionary<string, int>());
            Console.WriteLine(ways);

            List<string> allFormsWithParens = new List<string>();
            FindAllFormsWithParens(exp, allFormsWithParens);
            foreach (string str in allFormsWithParens)
                Console.WriteLine(str);
        }

        private int CountEvals(string exp, bool result)
        {
            if (exp.Length == 0) return 0;
            if (exp.Length == 1)//Base case
                return StringToBool(exp) == result ? 1 : 0;
            string key = exp + result;
            int totalWays = 0;
            for (int i = 1; i < exp.Length; i = i + 2)
            {
                char c = exp[i];
                string leftPart = exp.Substring(0, i);
                string rightPart = exp.Substring(i + 1);

                int leftTrue = CountEvals(leftPart, true);
                int leftFalse = CountEvals(leftPart, false);
                int rightTrue = CountEvals(rightPart, true);
                int rightFalse = CountEvals(rightPart, false);

                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

                if (c == '&')
                    totalWays += result ? leftTrue * rightTrue : total - (leftTrue * rightTrue);
                else if (c == '^')
                    totalWays += result ? (leftTrue * rightFalse) + (leftFalse * rightTrue) : total - ((leftTrue * rightFalse) + (leftFalse * rightTrue));
                else if (c == '|')
                    totalWays += result ? (leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue) :
                        total - ((leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue));
            }
            return totalWays;
        }
        private int CountEvals_Memo(string exp, bool result, Dictionary<string, int> map)
        {
            if (exp.Length == 0) return 0;
            if (exp.Length == 1)//Base case
                return StringToBool(exp) == result ? 1 : 0;
            string key = exp + "_" + result;
            if (!map.ContainsKey(key))
            {
                int totalWays = 0;
                for(int i = 1; i < exp.Length; i = i + 2)
                {
                    char c = exp[i];
                    string leftPart = exp.Substring(0, i);
                    string rightPart = exp.Substring(i + 1);

                    int leftTrue = CountEvals_Memo(leftPart, true, map);
                    int leftFalse = CountEvals_Memo(leftPart, false, map);
                    int rightTrue = CountEvals_Memo(rightPart, true, map);
                    int rightFalse = CountEvals_Memo(rightPart, false, map);

                    int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

                    if (c == '&')
                        totalWays += result ? leftTrue * rightTrue : total - (leftTrue * rightTrue);
                    else if (c == '^')
                        totalWays += result ? (leftTrue * rightFalse) + (leftFalse * rightTrue) : total - ((leftTrue * rightFalse) + (leftFalse * rightTrue));
                    else if (c == '|')
                        totalWays += result ? (leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue) :
                            total - ((leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue));
                }
                map[key] = totalWays;
            }
            return map[key];
        }

        private bool StringToBool(string str)
        {
            return str == "1" ? true : false;
        }


        /// <summary>
        /// This is an additional problem where we want to return all forms of the string with different places of parens.
        /// 
        /// THIS IS WRONG IMPLEMENTATION AND NEED TO BE FIXED :)
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="allForms"></param>
        private void FindAllFormsWithParens(string exp, List<string> allForms)
        {
            if (exp.Length == 0) return;
            for (int i = 1; i < exp.Length; i = i + 2)
            {
                char c = exp[i];
                string leftPart = exp.Substring(0, i);
                string rightPart = exp.Substring(i + 1);

                StringBuilder sb = new StringBuilder();
                sb.Append("(" + leftPart + ")");
                sb.Append(c);
                sb.Append("(" + rightPart + ")");
                allForms.Add(sb.ToString());
                FindAllFormsWithParens(leftPart, allForms);
                FindAllFormsWithParens(rightPart, allForms);
            }
        }
    }
}
