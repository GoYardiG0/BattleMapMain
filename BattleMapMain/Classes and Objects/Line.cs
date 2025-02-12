using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.Classes_and_Objects
{
    public class Line
    {
        public Point start;
        public Point end;
        public Line(Point start, Point end)
        {
            this.start = new Point(start.X,start.Y);
            this.end = new Point(end.X,end.Y);
        }
    }
}
