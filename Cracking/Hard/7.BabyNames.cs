using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Hard
{
    /// <summary>
    /// 17.7 Baby Names: Each year, the government releases a list of the 10,000 most common baby names
    /// and their frequencies(the number of babies with that name). The only problem with this is that
    /// some names have multiple spellings. For example, "John" and ''.Jon" are essentially the same name
    /// but would be listed separately in the list. Given two lists, one of names/frequencies and the other
    /// of pairs of equivalent names, write an algorithm to print a new list of the true frequency of each
    /// name.Note that if John and Jon are synonyms, and Jon and Johnny are synonyms, then John and
    /// Johnny are synonyms. (It is both transitive and symmetric.) In the final list, any name can be used
    /// as the "real" name.
    /// EXAMPLE
    /// Input:
    /// Names: John(15), Jon(12), Chris(13), Kris(4), Christopher(19)
    /// Synonyms: (Jon, John), (John, Johnny), (Chris, Kris), (Chris, Christopher)
    /// Output: John(27), Kris(36)
    /// </summary>
    public class BabyNames
    {
        /// <summary>
        /// Runtime: O(N Log N) in the worst case, like the idea of the merge sort
        /// </summary>
        /// <param name="names"></param>
        /// <param name="synomyms"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetTrulyMostPopular(Dictionary<string, int> names, string[][] synomyms)
        {
            /*Parse list and initialize equivalence classes.*/
            Dictionary<string, NameSet> groups = CreateGroups(names);
            /*Merge equivalence classes together.*/
            MergeClasses(groups, synomyms);
            /*Convert back to hash map.*/
            return ConvertToHashMap(groups);
        }        
        private Dictionary<string, NameSet> CreateGroups(Dictionary<string, int> names)
        {
            Dictionary<string, NameSet> groups = new Dictionary<string, NameSet>();
            foreach(KeyValuePair<string, int> kvp in names)
            {
                string name = kvp.Key;
                int freq = kvp.Value;
                NameSet set = new NameSet(name, freq);
                groups.Add(name, set);//We are sure values in the dictionary is unique )
            }
            return groups;
        }     

        private void MergeClasses(Dictionary<string, NameSet> groups, string[][] synonyms)
        {
            foreach(string[] entry in synonyms)
            {
                string name1 = entry[0];
                string name2 = entry[1];

                NameSet set1 = groups[name1];
                NameSet set2 = groups[name2];

                if(set1 != set2)//I don't know we use this condition
                {
                    NameSet smaller = set1.Names.Count < set2.Names.Count ? set1 : set2;
                    NameSet bigger = set1.Names.Count < set2.Names.Count ? set2 : set1;

                    bigger.MergeSets(smaller.Names, smaller.frequency);

                    foreach(string name in smaller.Names)
                    {
                        groups[name] = bigger;
                    }
                }
            }
        }

        private Dictionary<string, int> ConvertToHashMap(Dictionary<string, NameSet> groups)
        {
            Dictionary<string, int> trulyPopularNames = new Dictionary<string, int>();
            //foreach(KeyValuePair<string, NameSet> kvp  in groups)
            //{
            //    string name = kvp.Key;
            //    int freq = kvp.Value.frequency;
            //    trulyPopularNames.Add(name, freq);
            //}
            foreach(NameSet ns in groups.Values)
            {
                string name = ns.rootName;
                int freq = ns.frequency;
                if (!trulyPopularNames.ContainsKey(name))
                    trulyPopularNames.Add(name, freq);
            }
            return trulyPopularNames;
        }

        class NameSet
        {
            public string rootName { get; set; }
            public int frequency { get; set; }
            public HashSet<string> Names { get; set; }

            public NameSet(string name, int freq)
            {
                this.rootName = name;
                this.frequency = freq;
                Names = new HashSet<string>() { name };
            }

            public void MergeSets(HashSet<string> otherNames, int freq)
            {
                this.frequency += freq;
                foreach (string name in otherNames)
                    Names.Add(name);
            }
        }
    }



    /*
     * 
     * 
     * 
     * Baby names problem using graphs
     * 
     * 
     * 
     * */
     public class BabyNames_UsingGraphs
    {
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="names"></param>
        /// <param name="synonyms"></param>
        /// <returns></returns>
        public Dictionary<string , int> GetTrulyMostPopularNames(Dictionary<string, int> names, string[][] synonyms)
        {
            Graph graph = ConstructGraph(names);
            ConstructEdges(graph, synonyms);
            return GetTrulyDictionary_DepthFirst(graph);
        }        

        private Dictionary<string, int> GetTrulyDictionary_DepthFirst(Graph graph)
        {
            Dictionary<string, int> trueFrequeunces = new Dictionary<string, int>();
            foreach(GraphNode node in graph.Nodes)
            {
                if(!node.Visited)
                {
                    string name = node.Name;
                    int freq = GetNodeTotalFrequency(node);
                    trueFrequeunces.Add(name, freq);
                }
            }
            return trueFrequeunces;
        }

        private int GetNodeTotalFrequency(GraphNode node)
        {
            if (node.Visited) return 0;
            node.Visited = true;
            int freq = node.Frequency;
            foreach (GraphNode neighbor in node.Neighbours)
            {
                freq += GetNodeTotalFrequency(neighbor);
            }
            return freq;
        }

        private Graph ConstructGraph(Dictionary<string, int> names)
        {
            Graph graph = new Graph();
            foreach(KeyValuePair<string, int> kvp in names)
            {
                string name = kvp.Key;
                int freq = kvp.Value;
                graph.CreateNode(name, freq);
            }
            return graph;
        }
        private void ConstructEdges(Graph graph, string[][] synonyms)
        {
            foreach(string[] pair in synonyms)
            {
                string name1 = pair[0];
                string name2 = pair[1];
                graph.AddEdge(name1, name2);
            }
        }        

        public class Graph
        {
            public List<GraphNode> Nodes { get; set; }
            public Dictionary<string, GraphNode> map { get; set; }

            public Graph()
            {
                this.Nodes = new List<GraphNode>();
                this.map = new Dictionary<string, GraphNode>();
            }

            public GraphNode GetNode(string name)
            {
                if (map.ContainsKey(name))
                    return map[name];
                return null;
            }

            public GraphNode CreateNode(string name, int freq)
            {
                if (map.ContainsKey(name))
                    return GetNode(name);
                GraphNode node = new GraphNode(name, freq);
                Nodes.Add(node);
                map.Add(name, node);
                return node;
            }
            public void AddEdge(string name1, string name2)
            {
                GraphNode node1 = GetNode(name1);
                GraphNode node2 = GetNode(name2);
                if(node1 != null  && node2 != null)
                {
                    node1.AddNeighbor(node2);
                    node2.AddNeighbor(node1);
                }
            }
        }
        public class GraphNode
        {
            public string Name { get; set; }
            public int Frequency { get; set; }
            public bool Visited { get; set; }
            public List<GraphNode> Neighbours { get; set; }
            public Dictionary<string, GraphNode> map { get; set; }

            public GraphNode(string name, int freq)
            {
                this.Name = name;
                this.Frequency = freq;
                this.Neighbours = new List<GraphNode>();
                this.map = new Dictionary<string, GraphNode>();
            }

            public bool AddNeighbor(GraphNode node)
            {
                if (map.ContainsKey(node.Name))
                    return false;
                Neighbours.Add(node);
                map.Add(node.Name, node);
                return true;
            }
        }
    }
}
