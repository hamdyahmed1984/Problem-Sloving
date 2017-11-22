using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class PrintLastKLines
    {
        public void Test()
        {
            int k = 13;
            PrintLastKLinesFromFile(k);
        }

        private void PrintLastKLinesFromFile(int k)
        {
            string[] arr = new string[k];
            int index = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader("numbers.txt"))
            {
                while(!sr.EndOfStream)
                {
                    arr[AdjustIndex(arr.Length, index)] = sr.ReadLine();
                    index++;
                }
            }

            int min = Math.Min(k, index);//We use minimum of k and index(count of lines in the file) to take care of the case where k is greater than number of lines in the file.
            for(int i = 0; i < min; i++)
            {
                Console.WriteLine(arr[AdjustIndex(min, index++)]);
            }
        }

        int AdjustIndex(int length, int index)
        {
            return index % length;
        }
    }
}
