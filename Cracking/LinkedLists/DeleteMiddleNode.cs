using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.LinkedLists
{
    class DeleteMiddleNode
    {
        public static bool DeleteMiddleNodeFromList(Node n)
        {
            if (n == null || n.Next == null)
                return false;
            n.data = n.Next.data;
            n.Next = n.Next.Next;
            return true;
        }
    }
}
