using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    class ShuffleArray
    {
        public void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Shuffle2(arr);
            Console.WriteLine(string.Join(",", arr));
        }

        private void Shuffle(int[] arr)
        {
            int n = arr.Length;
            Random rand = new Random();
            for(int i = 0; i < n; i++)
            {
                int end = n - i;
                int j = i + rand.Next(end);
                Swap(arr, i, j);
            }
        }

        private void Shuffle2(int[] arr)
        {
            int n = arr.Length;
            Random rand = new Random();
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i);
                Swap(arr, i, j);
            }
        }

        private void Shuffle2D(int[][] arr)
        {
            if (arr.Length == 0 || arr[0].Length == 0) return;
            int rows = arr.Length;
            int cols = arr[0].Length;
            Random rand = new Random();
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; i < cols; j++)
                {
                    Swap(arr, i, j, i + rand.Next(rows - i), j + rand.Next(cols - j));
                }
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        private void Swap(int[][] arr, int i, int j, int i2, int j2)
        {
            int tmp = arr[i][j];
            arr[i][j] = arr[i2][j2];
            arr[i2][j2] = tmp;
        }
    }
}
