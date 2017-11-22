using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    class BuildOrder
    {
        public static void Test()
        {
            Graph g = new Graph();
            g.AddVertix(1);
            g.AddVertix(2);
            g.AddVertix(3);
            g.AddVertix(4);
            g.AddVertix(5);
            g.AddVertix(6);

            g.AddEdge(1, 4);
            g.AddEdge(6, 2);
            g.AddEdge(2, 4);
            g.AddEdge(6, 1);
            g.AddEdge(4, 3);
            //g.AddEdge(3, 1);

            bool result = GetBuildOrder(g);
            if (!result)
                Console.WriteLine("The graph contains cyclic path!!");
        }

        private static bool GetBuildOrder(Graph g)
        {
            Stack<int> s = new Stack<int>();
            //HashSet<int> visited = new HashSet<int>();
            ///Here I am using a hashtable instead of hashset to keep track of visited nodes.
            ///And this is to detect cyclic path in the graph.
            ///And I do this by setting each vettix as PARIIAL when it is visited for the first time.
            ///And if I faced it a gain this is a signal for cyclic path.
            ///And when it is finished I mark it as COMPLETED
            Dictionary<int, string> visited = new Dictionary<int, string>();
            foreach (KeyValuePair<int, Vertix> kvp in g.Vertices)
            {
                int vertixId = kvp.Key;
                Vertix v = kvp.Value;
                //If vertix is not visited ever before. 
                //Existence in the visited dictionary means it is visited before
                //Existence in the visited dictionary and its value in the dictionary is PARTIAL means it is cyclic path.
                if (!visited.ContainsKey(vertixId))
                {
                    //If the return is false, so this is cyclic path, just return false as we can't order the build path.
                    if (!GetBuildOrder(v, visited, s))
                        return false;
                }
            }
            
            //Finished sorting alll vertices, now print them
            while(s.Count > 0)
            {
                Console.WriteLine(s.Pop());
            }
            return true;
        }

        private static bool GetBuildOrder(Vertix v, Dictionary<int, string> visited, Stack<int> s)
        {
            if (visited.ContainsKey(v.Id) && visited[v.Id] == "PARTIAL")
                return false;
            visited.Add(v.Id, "PARTIAL");
            foreach (KeyValuePair<Vertix, int?> kvp in v.Adjacents)
            {
                Vertix adj = kvp.Key;
                int adjId = adj.Id;
                if (!visited.ContainsKey(adjId))
                {
                    if (!GetBuildOrder(adj, visited, s))
                        return false;
                }
                else if (visited.ContainsKey(adjId) && visited[adjId] == "PARTIAL")
                    return false;
            }

            visited[v.Id] = "COMPLETED";
            s.Push(v.Id);
            return true;
        }
    }
}
