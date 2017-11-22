using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BreadthFirstSearch
    {
        public static Vertex[] DoBFS(int[][] graph, int source)
        {
            Vertex[] bfsList = new Vertex[graph.Length];
            for(int i = 0; i<bfsList.Length; i++)
            {
                bfsList[i] = new Vertex();
                bfsList[i].Distance = null;
                bfsList[i].Predecessor = null;
                bfsList[i].Index = i;
            }

            bfsList[source].Distance = 0;

            var queue = new Queue<Vertex>();
            queue.Enqueue(bfsList[source]);

            while(queue.Count != 0)
            {
                Vertex u = queue.Dequeue();
                for(int i = 0; i < graph[u.Index].Length; i++)
                {
                    var vIndex = graph[u.Index][i];
                    if (!bfsList[vIndex].Distance.HasValue)
                    {
                        bfsList[vIndex].Distance = u.Distance + 1;
                        bfsList[vIndex].Predecessor = u.Index;
                        queue.Enqueue(bfsList[vIndex]);
                    }
                }
            }


            return bfsList;
        }
    }

    public class Vertex
    {
        public int Index { get; set; }
        public int? Distance { get; set; }
        public int? Predecessor { get; set; }
    }
}
