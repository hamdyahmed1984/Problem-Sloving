using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Primitives
{
    public class GCD
    {
        public static int GetGCD1(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            if (a == b)
                return a;
            if (a > b)
                return GetGCD1(a - b, b);
            else
                return GetGCD1(a, b - a);
        }

        public static int GetGCD2(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            if (a == b)
                return a;
            while(a != b)
            {
                if (a > b)
                    a = a - b;
                else if (a < b)
                    b = b - a;
            }
            return a;
        }

        public static int GetGCD3(int a, int b)
        {
            if (b == 0)
                return a;
            return GetGCD3(b, a % b);
        }

        public static int GetGCD4(int a, int b)
        {
            if(b > a)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }
            while(b != 0)
            {
                int r = a % b;
                a = b;
                b = r;                
            }
            return a;
        }

        public static int GetGCDForArr(int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            int GCD = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                GCD = GetGCD1(arr[i], GCD);
            }
            return GCD;
        }
    }
}
