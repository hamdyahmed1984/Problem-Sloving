using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //Factorial f = new Factorial();
            //int fact = f.LoopFactorial(n);
            //Console.WriteLine(string.Format("Factorial For Loop = {0}", fact));
            //fact = f.WhileFactorial(n);
            //Console.WriteLine(string.Format("Factorial While Loop = {0}", fact));
            //fact = f.RecurFactorial(n);
            //Console.WriteLine(string.Format("Factorial Recursion = {0}", fact));
            //Console.ReadLine();

            //string word = Console.ReadLine();
            //Console.WriteLine(string.Format("Word {0} Is Palendrome?: {1}", word, new Palendrome().IsPalendrome(word)));
            //Console.ReadLine();

            Console.WriteLine("Enter number of disks!");
            int numberOFDisks = int.Parse(Console.ReadLine());
            TowersOfHanoi toh = new TowersOfHanoi();
            string strMoves = "";
            toh.Move(numberOFDisks, "[S]", "[I]", "[D]", ref strMoves);
            Console.WriteLine(strMoves);
            Console.ReadLine();
        }
    }
}
