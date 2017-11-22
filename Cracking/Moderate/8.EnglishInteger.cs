using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.8 English Int: Given any integer, print an English phrase that describes the integer (e.g., "One Thousand, Two Hundred Thirty Four").
    /// 
    /// We can think about converting a number like 19,323,984 as converting each of three 3-digit segments of
    /// the number, and inserting "thousands" and "millions" in between as appropriate.That is,
    /// convert(19,323,984) = convert(19) + " million " + convert(323) + " thousand " + convert(984)
    /// </summary>
    class EnglishInteger
    {
        public void Test()
        {
            int num = 19323984;
            string strNum = ConvertIntToEnglishString(num);
            Console.WriteLine(num + ": " + strNum);

            num = 5;
            strNum = ConvertIntToEnglishString(num);
            Console.WriteLine(num + ": " + strNum);

            num = 120;
            strNum = ConvertIntToEnglishString(num);
            Console.WriteLine(num + ": " + strNum);

            num = 1517;
            strNum = ConvertIntToEnglishString(num);
            Console.WriteLine(num + ": " + strNum);
        }

        string hundred = "Hundred";
        string negative = "Negative";
        string[] bigs = { "", "Thousand", "Million", "Billion" };
        string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] ones = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string ConvertIntToEnglishString(int num)
        {
            if (num == 0) return ones[num];
            if (num < 0)
                return negative + " " + ConvertIntToEnglishString(-1 * num);

            int chunksCount = 0;
            Stack<string> parts = new Stack<string>();
            while(num > 0)
            {
                if(num % 1000 != 0)
                {
                    string chunkString = ConvertChunk(num % 1000)+ " " + bigs[chunksCount];
                    parts.Push(chunkString);
                    chunksCount++;
                }
                num /= 1000;// shift chunk
            }

            return StackToString(parts);
        }        

        private string ConvertChunk(int num)
        {
            Queue<string> parts = new Queue<string>();
            if(num >= 100)
            {
                parts.Enqueue(ones[num / 100]);
                parts.Enqueue(hundred);
                num %= 100;
            }
            if(num >= 20)
            {
                parts.Enqueue(tens[num / 10]);
                num %= 10;
            }
            //if(num >= 10 && num <= 19)
            //{
            //    parts.Enqueue(ones[num]);
            //}
            //if(num > 0 && num <= 9)
            //{
            //    parts.Enqueue(ones[num]);
            //}
            if (num > 0 && num <= 19)
            {
                parts.Enqueue(ones[num]);
            }
            return QueueToString(parts);
        }

        private string StackToString(Stack<string> parts)
        {
            StringBuilder sb = new StringBuilder();
            while(parts.Count > 1)
            {
                sb.Append(parts.Pop() + " ");
            }
            sb.Append(parts.Pop());
            return sb.ToString();
        }
        private string QueueToString(Queue<string> parts)
        {
            StringBuilder sb = new StringBuilder();
            while (parts.Count > 1)
            {
                sb.Append(parts.Dequeue() + " ");
            }
            sb.Append(parts.Dequeue());
            return sb.ToString();
        }
    }
}
