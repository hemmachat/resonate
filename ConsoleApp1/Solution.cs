using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Solution
    {
        public static Dictionary<string, double>[] DoAggregations(double[,] input)
        {
            var totalCols = input.GetUpperBound(1) + 1;
            var totalRows = input.GetUpperBound(0) + 1;
            var sumItems = new double[totalCols];
            var avgItems = new double[totalCols];
            var countDistinctItems = new int[totalCols];
            var distinctItems = new Dictionary<double, byte[]>();
            var sum = 0d;

            for (var y = 0; y < totalCols; y++)
            {
                var currentColumn = y;
            
                for (var x = 0; x < totalRows; x++)
                {
                    if (currentColumn == y)
                    {
                        var currentValue = input[x, y];
                        sum += currentValue;
                        distinctItems[currentValue] = null;
                    }
                }
                
                sumItems[y] = sum;
                avgItems[y] = sum / totalRows;
                countDistinctItems[y] = distinctItems.Count;
                distinctItems.Clear();
                sum = 0d;
            }

            return new Dictionary<string, double>[]
            {
                new Dictionary<string, double>{{"SUM", sumItems[0]}, {"AVERAGE", avgItems[0]}, {"COUNT DISTINCT", countDistinctItems[0]}},
                new Dictionary<string, double>{{"SUM", sumItems[1]}, {"AVERAGE", avgItems[1]}, {"COUNT DISTINCT", countDistinctItems[1]}},
                new Dictionary<string, double>{{"SUM", sumItems[2]}, {"AVERAGE", avgItems[2]}, {"COUNT DISTINCT", countDistinctItems[2]}}
            };
        }
    }
    
    public class Mock
    {
        public static Dictionary<string, double>[] DoAggregations(double[,] input)
        {
            return new Dictionary<string, double>[]{
                new Dictionary<string, double>{{"SUM", 9d}, {"AVERAGE", 2.25d}, {"COUNT DISTINCT", 3d}},
                new Dictionary<string, double>{{"SUM", 14d}, {"AVERAGE", 3.5d}, {"COUNT DISTINCT", 2d}},
                new Dictionary<string, double>{{"SUM", 16d}, {"AVERAGE", 4d}, {"COUNT DISTINCT", 4d}}};
        }
    }
}