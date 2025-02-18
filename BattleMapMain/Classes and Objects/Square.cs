using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.Classes_and_Objects
{
    public class Square
    {
        Point bottomLeft;
        Point topRight;
        public Square(Point bottomLeft, Point topRight)
        {
            this.bottomLeft = new Point(bottomLeft.X, bottomLeft.Y);
            this.topRight = new Point(topRight.X, topRight.Y);
        }
    }
}
