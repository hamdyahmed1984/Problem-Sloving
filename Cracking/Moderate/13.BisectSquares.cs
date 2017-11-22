using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.13 Bisect Squares: Given two squares on a two-dimensional plane, find a line that would cut these two squares in half.
    /// Assume that the top and the bottom sides of the square run parallel to the x-axis.
    /// 
    /// The Idea: This line that cuts two squares in half must connect the two centers.
    /// </summary>
    class BisectSquares
    {
        public void Test()
        {
            Square sq1 = new Square(1, 2, 2);
            Square sq2 = new Square(3, 7, 3);

            Line cutLine = sq1.CuttingLine(sq2);
        }



        class Square
        {
            double Left, Top, Right, Bottom;
            
            public double EdgeSize { get; set; }

            public Square(double left, double top, double edgeSize)
            {
                this.Left = left;
                this.Top = top;
                this.EdgeSize = edgeSize;
                this.Right = left + edgeSize;
                this.Bottom = top + edgeSize;
            }

            public Point Center()
            {
                Point center = new Point((Left + Right) / 2, (Top + Bottom) / 2);
                /* The center of the square can be calculated this way also */
                //Point center2 = new Point((Left + EdgeSize / 2), (Top + EdgeSize / 2));

                return center;//or even center2, they are equal
            }

            public Line CuttingLine(Square other)
            {
                Point center1 = this.Center();
                Point center2 = other.Center();

                if(center1 == center2)//Same center
                {
                    return new Line(new Point(Left, Top), new Point(Right, Bottom));
                }
                else
                {
                    return new Line(center1, center2);
                }
            }
        }

        class Line
        {
            Point Start, End;
            public Line(Point start, Point end)
            {
                this.Start = start;
                this.End = end;
            }
        }
        class Point
        {
            double X, Y;
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
        }     
    }
}
