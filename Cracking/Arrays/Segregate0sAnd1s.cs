using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class Segregate0sAnd1s
    {
        public static void Segregate0sAnd1sTest()
        {
            int[] arr = new int[] { 1,1,0,0,0,1,0,1,0,1,1,0,0,0 };
            Segregate0sAnd1s_3(arr);
            Console.WriteLine(string.Join(",", arr));
        }
        public static void Segregate0sAnd1s_1(int [] arr)
        {
            int count_0 = 0;
            for(int i = 0; i< arr.Length; i++)
            {
                if (arr[i] == 0)
                    count_0++;
            }
            for (int i = 0; i < count_0; i++)
                arr[i] = 0;
            for (int i = count_0; i < arr.Length; i++)
                arr[i] = 1;
        }
        public static void Segregate0sAnd1s_2(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while(left < right)
            {
                while (arr[left] == 0)
                    left++;
                while (arr[right] == 1)
                    right--;
                if(left < right)
                {
                    arr[left] = 0;
                    arr[right] = 1;
                    left++;
                    right--;
                }
            }
        }

        public static void Segregate0sAnd1s_3(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left] == 0)
                    left++;
                else if(arr[left] == 1)
                {
                    if (arr[right] == 1)
                        right--;
                    else
                    {
                        Swap(arr, left, right);
                        left++;
                        right--;
                    }
                }
            }
        }
        static void Swap(int[] arr, int i, int j)
        {
            if (arr[i] != arr[j])
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
        }

    }
}
