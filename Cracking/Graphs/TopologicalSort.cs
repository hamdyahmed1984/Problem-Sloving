
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class TopologicalSort
    {
        /// <summary>
        /// Topological sort should work on directed asyclic graph not graph with cycles.
        /// </summary>
        /// <param name="g"></param>
        private static void DoTopologicalSort(Graph g)
        {
            Stack<int> s = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            foreach (KeyValuePair<int, Vertix> kvp in g.Vertices)
                if (!visited.Contains(kvp.Key))
                    DoTopologicalSort(kvp.Value, visited, s);

            //Finished sorting alll vertices, now print them
            while (s.Count > 0)
            {
                Console.WriteLine(s.Pop());
            }
        }

        private static void DoTopologicalSort(Vertix v, HashSet<int> visited, Stack<int> s)
        {
            visited.Add(v.Id);
            foreach (KeyValuePair<Vertix, int?> kvp in v.Adjacents)
                if (!visited.Contains(kvp.Key.Id))
                    DoTopologicalSort(kvp.Key, visited, s);
            s.Push(v.Id);
        }
    }
}
