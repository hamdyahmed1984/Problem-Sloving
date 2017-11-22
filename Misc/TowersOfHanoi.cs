using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class TowersOfHanoi
    {
        public void Move(int n, string Source, string Intermediate, string Dest, ref string strMoves)
        {
            if (n == 1)
                strMoves += string.Format("Move 1 disk from {0} to {1}\r\n", Source, Dest);
            else
            {
                Move(n - 1, Source, Dest, Intermediate, ref strMoves);
                Move(1, Source, Intermediate, Dest, ref strMoves);
                Move(n - 1, Intermediate, Source, Dest, ref strMoves);
            }
        }
    }
}
