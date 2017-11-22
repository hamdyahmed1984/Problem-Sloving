using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.7 Missing Int: Given an input file with four billion non-negative integers, provide an algorithm to
    /// generate an integer that is not contained in the file.Assume you have 1 GB of memory available for this task.
    /// FOLLOW UP
    /// What if you have only 1 O MB of memory? Assume that all the values are distinct and we now have
    /// no more than one billion non-negative integers.
    /// 
    /// 
    /// 
    ///SOLUTION
    ///    There are a total of 2^32, or 4 billion, distinct integers possible and 2^31 non-negative integers.Therefore, we
    ///know the input file (assuming it is ints rather than longs) contains some duplicates.
    ///We have 1 GB of memory, or 8 billion bits.Thus, with 8 billion bits, we can map all possible integers to a
    ///distinct bit with the available memory. The logic is as follows:
    ///1. Create a bit vector (BV) with 4 billion bits. Recall that a bit vector is an array that compactly stores
    ///boolean values by using an array of ints(or another data type). Each int represents 32 boolean values.
    ///2. Initialize BV with all Os.
    ///3. Scan all numbers (num) from the file and call BV.set (num, 1) .
    ///4. Now scan again BV from the 0th index.
    ///5. Return the first index which has a value of 0.
    /// </summary>
    class MissingInt_Bits
    {
        public void Test()
        {

            //using (StreamWriter sw = new StreamWriter("numbers.txt"))
            //{
            //    Random rand = new Random();
            //    for (int i = 0; i < 10; i++)
            //    {                    
            //        sw.WriteLine(rand.Next(0, int.MaxValue));
            //    }
            //}
            PrintMissingNumber();
        }

        public void PrintMissingNumber()
        {
            long integresLength = ((long)int.MaxValue) + 1;
            BitSet bs = new BitSet(integresLength);
            //Read integres from file line by line
            using (StreamReader sr = new StreamReader("numbers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    int num = int.Parse(line);
                    bs.SetBit(num);
                }
            }


            for(int i = 0; i <= int.MaxValue; i++)//<= because we have integerg from 0 to int.MaxValue
            {
                if(!bs.GetBit(i))
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }


        class BitSet
        {
            int[] bitSet;
            public long Length = 0;
            /// <summary>
            /// It is assumed that we have 4 billion integres and there are duplicates in them (int.MaxValue is 2147483647).
            /// the size parameter is long because we have integers in range from 0 to 2147483647 so 2147483647 is inclusive with us 
            /// and we need to exceed the int.MaxValue by 1 to include this value with us.
            /// </summary>
            /// <param name="size"></param>
            public BitSet(long size)
            {                
                bitSet = new int[(size / 32)];
                Length = size / 32;
            }

            public void SetBit(int pos)
            {
                int wordIndex = pos / 32;// divide by 32, also can be done using: (pos >> 5);
                int bitIndex = pos % 32;// mod 32, also can be done using: (pos & 0x1F);  (I also tried pos & 0xFF and it works)
                bitSet[wordIndex] = bitSet[wordIndex] | (1 << bitIndex);
            }

            public bool GetBit(int pos)
            {
                int wordIndex = pos / 32;// divide by 32, also can be done using: (pos >> 5);
                int bitIndex = pos % 32;// mod 32, also can be done using: (pos & 0x1F);  (I also tried pos & 0xFF and it works)
                return (bitSet[wordIndex] & (1 << bitIndex)) != 0;
            }
        }
    }
}
