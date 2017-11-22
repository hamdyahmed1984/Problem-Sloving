using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Sorting_Searching
{
    /// <summary>
    /// 10.8 Find Duplicates: You have an array with all the numbers from 1 to N, where N is at most 32,000. The
    /// array may have duplicate entries and you do not know what N is. With only 4 kilobytes of memory
    /// available, how would you print all duplicate elements in the array?
    /// 
    /// 
    /// SOLUTION
    /// We have 4 kilobytes of memory which means we can address up to 8 * 4 * 2^10 bits.Note that 32 * 2^10
    /// bits is greater than 32000. We can create a bit vector with 32000 bits, where each bit represents one integer.
    /// Using this bit vector, we can then iterate through the array, flagging each element v by setting bit v to 1.
    /// When we come across a duplicate element, we print it.
    /// </summary>
    class FindDuplicates_BitSet
    {
        public void Test()
        {
            int[] arr = { 1, 5, 2, 5, 32000, 10, 2, 32000 };
            FindDuplicates_BitSetArr(arr);
            FindDuplicates_UsingBitArray(arr);
        }

        private void FindDuplicates_BitSetArr(int[] arr)
        {
            BitSet bs = new BitSet(32000);
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                int num0 = num - 1;//bitset starts at 0, numbers start at 1
                if (bs.GetBit(num0))
                    Console.WriteLine(num);
                else
                    bs.SetBit(num0);
            }
        }

        private void FindDuplicates_UsingBitArray(int[] arr)
        {            
            System.Collections.BitArray bitArr = new System.Collections.BitArray(32000);
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                int num0 = num - 1;//bitset starts at 0, numbers start at 1
                if (bitArr.Get(num0))
                    Console.WriteLine(num);
                else
                    bitArr.Set(num0, true);
            }
        }

        class BitSet
        {
            /* We use int array and not Byte array because int array with (32000/32) entries will need exactly 4KB of memory.
             * Where using Byte array with (32000/8) entries will need 16KB which is more than the available memory(4KB).
             */
            int[] bitSet;
            public BitSet(int size)
            {
                bitSet = new int[(size / 32)];
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
