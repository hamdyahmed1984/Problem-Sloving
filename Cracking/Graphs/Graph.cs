using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    public class Vertix
    {
        public int Id;
        public Dictionary<Vertix, int?> Adjacents;//key: vertix, value: weight
        public Vertix(int id)
        {
            this.Id = id;
            this.Adjacents = new Dictionary<Vertix, int?>();
        }
    }
    class Graph
    {
        public Dictionary<int, Vertix> Vertices = new Dictionary<int, Vertix>();
        public Graph()
        {

        }
        public Vertix GetVertix(int id)
        {
            if (Vertices.ContainsKey(id))
                return Vertices[id];
            throw new InvalidOperationException("Not existing vertix.");
        }

        public Vertix AddVertix(int id)
        {
            if (Vertices.ContainsKey(id))
                throw new InvalidOperationException("Vertix already exists in the graph.");
            Vertix v = new Vertix(id);
            Vertices.Add(id, v);
            return v;
        }

        public void AddEdge(int source, int destination)
        {
            Vertix s = GetVertix(source);
            Vertix d = GetVertix(destination);
            s.Adjacents.Add(d, null);
        }
        public void AddEdge(int source, int destination, int weight)
        {
            Vertix s = GetVertix(source);
            Vertix d = GetVertix(destination);
            s.Adjacents.Add(d, weight);
        }

        public void PrintGraph()
        {
            foreach(KeyValuePair<int, Vertix> v in Vertices)
            {
                Console.Write("Vertix({0}): ", v.Key);
                foreach(KeyValuePair<Vertix, int?> adj in v.Value.Adjacents)
                {
                    Console.Write("{0}-{1},", adj.Key.Id, adj.Value);
                }
                Console.WriteLine();
            }
        }

        public void DFS()
        {
            HashSet<Vertix> visited = new HashSet<Vertix>();
            foreach (KeyValuePair<int, Vertix> kvp in Vertices)
                if (!visited.Contains(kvp.Value))
                    DFS(visited, kvp.Value);
        }

        private void DFS(HashSet<Vertix> visited, Vertix v)
        {
            Console.WriteLine(v.Id);
            visited.Add(v);
            foreach (var adj in v.Adjacents)
                if (!visited.Contains(adj.Key))
                    DFS(visited, adj.Key);
        }

        public void BFS(int start)
        {
            Queue<Vertix> toVisit = new Queue<Vertix>();
            HashSet<Vertix> visited = new HashSet<Vertix>();

            toVisit.Enqueue(GetVertix(start));
            while(toVisit.Count > 0)
            {
                Vertix processed = toVisit.Dequeue();
                if (visited.Contains(processed))
                    continue;
                visited.Add(processed);
                Console.WriteLine(processed.Id);
                foreach (KeyValuePair<Vertix, int?> kvp in processed.Adjacents)
                    toVisit.Enqueue(kvp.Key);
            }
        }

        public bool HasPathDFS(int source, int destination)
        {
            Vertix s = GetVertix(source);
            Vertix d = GetVertix(destination);
            HashSet<int> visited = new HashSet<int>();
            return HasPathDFS(s, d, visited);
        }

        private bool HasPathDFS(Vertix source, Vertix destination, HashSet<int> visited)
        {
            if (visited.Contains(source.Id))
                return false;
            visited.Add(source.Id);
            if (source == destination)
                return true;
            foreach(KeyValuePair<Vertix, int?> adj in source.Adjacents)
            {
                if (HasPathDFS(adj.Key, destination, visited))
                    return true;
            }
            return false;
        }

        public bool HasPathBFS(int source, int destination)
        {
            Vertix s = GetVertix(source);
            Vertix d = GetVertix(destination);
            return HasPathBFS(s, d);
        }
        private bool HasPathBFS(Vertix source, Vertix destination)
        {
            Queue<Vertix> nextToVisit = new Queue<Vertix>();
            HashSet<int> visited = new HashSet<int>();
            nextToVisit.Enqueue(source);
            while(nextToVisit.Count > 0)
            {
                Vertix src = nextToVisit.Dequeue();
                if (src == destination)
                    return true;
                if (visited.Contains(src.Id))
                    continue;
                visited.Add(src.Id);
                foreach (KeyValuePair<Vertix, int?> adj in src.Adjacents)
                {
                    nextToVisit.Enqueue(adj.Key);
                }
            }
            return false;
        }
    }
}
