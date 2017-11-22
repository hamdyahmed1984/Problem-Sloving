using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] adjList = new int[][] {
                new int[]{ 1} ,
                new int[]{ 0, 4, 5 },
                new int[]{3,4,5 },
                new int[]{ 2,6},
                new int[]{ 1,2},
                new int[]{1,2,6 },
                new int[]{3,5 },
                new int[]{ },
            };

            var bfsList = BreadthFirstSearch.DoBFS(adjList, 3);
            foreach(Vertex v in bfsList)
            {
                Console.WriteLine(string.Format("Vertex index: {0} has distance: {1} and predecessor: {2}", v.Index, v.Distance, v.Predecessor));
            }
        }
    }
}
