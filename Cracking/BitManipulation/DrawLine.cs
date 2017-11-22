using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.BitManipulation
{
    class DrawLine
    {
        public static void Test()
        {
            byte[] screen = new byte[10 * 6];//10 bytes width and 6 rows for height
            int width = 10 * 8;
            int x1 = 3;
            int x2 = 25;
            int y = 2;
            PrintScreenBits(screen);
            DrawLineFromX1ToX2(screen, width, x1, x2, y);
            Console.WriteLine();
            PrintScreenBits(screen);
        }        

        private static void DrawLineFromX1ToX2(byte[] screen, int width, int x1, int x2, int y)
        {
            if (x1 >= x2) return;

            int row_start = (width / 8) * y;//y starts from 0

            int first_byte = x1 / 8;
            int last_byte = x2 / 8;
            int first_full_byte = first_byte;
            int last_full_byte = last_byte;
            int start_offset = x1 % 8;
            int end_offset = x2 % 8;

            if (start_offset != 0)
                first_full_byte++;
            if (end_offset != 7)
                last_full_byte--;
            // Create masks for start and end bytes of line
            byte start_mask = (byte)(0xFF >> start_offset);
            byte end_mask = (byte)~(0xFF >> end_offset + 1);

            if(first_byte == last_byte)// xl and x2 are in the same byte
            {
                byte mask = (byte)(start_mask & end_mask);
                screen[row_start + first_byte] |= mask;                
            }
            else
            {
                if (first_byte != first_full_byte)
                    screen[row_start + first_byte] |= start_mask;
                if (last_byte != last_full_byte)
                    screen[row_start + last_byte] |= end_mask;
                // Set full bytes
                for (int b = first_full_byte; b <= last_full_byte; b++)
                {
                    screen[row_start + b] |= (byte)0xFF;
                }
            }
        }

        private static void PrintScreenBits(byte[] screen)
        {
            for (int i = 0; i < screen.Length; i++)
            {
                if (i % 10 == 0)
                    Console.WriteLine();
                byte mask = 1 << 7;
                for (int bitIndex = 0; bitIndex < 8; bitIndex++)
                {
                    Console.Write((screen[i] & (mask >> bitIndex)) > 0 ? "1" : "0");
                }
            }
        }
    }
}
