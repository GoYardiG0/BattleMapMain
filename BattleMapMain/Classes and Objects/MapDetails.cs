using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.Classes_and_Objects
{
    public class MapDetails
    {
        public Mini[,] allMinis;
        public List<Line> lines;

        public MapDetails(Mini[,] allMinis, List<Line> lines)
        {
            this.allMinis = allMinis;
            this.lines = lines;
        }
    }
}
