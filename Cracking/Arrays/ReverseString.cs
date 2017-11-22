using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class ReverseString
    {
        public void Test()
        {
            string str = "abcd";
            
            char[] arr = str.ToCharArray();
            Reverse1(arr);
            Reverse2(arr);
            Reverse_Recursive(arr, 0, str.Length - 1);
            Reverse_Recursive2(arr);
        }

        private void Reverse1(char[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n / 2; i++)
                Swap(arr, i, n - i - 1);
        }

        private void Reverse2(char[] arr)
        {
            int n = arr.Length;
            int i = 0;
            while(i < n/2)
            {
                Swap(arr, i, n - i - 1);
                i++;
            }
        }

        private void Reverse_Recursive(char[] arr, int start, int end)
        {
            if (start < end)
            {
                Swap(arr, start, end);
                Reverse_Recursive(arr, start + 1, end - 1);
            }
        }

        private void Reverse_Recursive2(char[] arr)
        {
            if (arr.Length > 0)
            {
                Console.Write(arr[arr.Length - 1]);
                Reverse_Recursive2(arr.Take(arr.Length - 1).ToArray());
            }
        }
        void Swap(char[] str, int i, int j)
        {
            char c = str[i];
            str[i] = str[j];
            str[j] = c;
        }
    }
}
