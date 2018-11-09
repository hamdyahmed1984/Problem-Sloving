using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /*
     * Definition:
       Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
     */

    public interface ISortStrategy
    {
        void Sort(List<string> lst);
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(List<string> lst)
        {
            lst.Sort();
            Console.WriteLine("QuickSort --> sorting");
        }
    }

    public class ShellSort : ISortStrategy
    {
        public void Sort(List<string> lst)
        {
            lst.Sort();
            Console.WriteLine("ShellSort --> sorting");
        }
    }

    public class MergekSort : ISortStrategy
    {
        public void Sort(List<string> lst)
        {
            lst.Sort();
            Console.WriteLine("MergekSort --> sorting");
        }
    }

    public class SortedList
    {
        private ISortStrategy _algorithm;

        private List<string> _lst = new List<string>();

        public SortedList(List<string> lst)
        {
            this._lst = lst;
        }

        public void SetSortStrategy(ISortStrategy algorithm)
        {
            this._algorithm = algorithm;
        }

        public void SortTheList()
        {
            _algorithm.Sort(_lst);
            Console.WriteLine("Start printing the sorted list.");
            foreach (var str in _lst)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("End printing the sorted list.");
        }
    }
}
