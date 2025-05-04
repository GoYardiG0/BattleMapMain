using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.Classes_and_Objects
{
    public class MapDetails
    {
        public List<List<Mini>> AllMinis
        {
            get; set;
        }
        public List<Line> Lines
        {
            get; set;
        }

        public MapDetails(Mini[,] allMinis, List<Line> lines)
        {
            this.AllMinis = ConvertToList(allMinis);
            this.Lines = lines;
        }
        public MapDetails() { Lines = new List<Line>(); }

        public static List<List<Mini>> ConvertToList(Mini[,] array)
        {
            var list = new List<List<Mini>>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                var row = new List<Mini>();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row.Add(array[i, j]);
                }
                list.Add(row);
            }
            return list;
        }
        public static Mini[,] ConvertTo2DArray(List<List<Mini>> nestedList)
        {
            if (nestedList == null || nestedList.Count == 0)
                return new Mini[0, 0];

            int rows = nestedList.Count;
            int cols = nestedList[0].Count;
            var result = new Mini[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                if (nestedList[i].Count != cols)
                    throw new InvalidOperationException("All rows must have the same number of columns.");

                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = nestedList[i][j];
                }
            }

            return result;
        }
    }
}
