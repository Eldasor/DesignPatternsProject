using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal struct StockData
    {
        public static StockData empty = new StockData(0, 0, 0, 0);
        public float open;
        public float high;
        public float low;
        public float close;
        public StockData(float a, float b, float c, float d)
        {
            open = a; high = b; low = c; close = d;
        }
        public static StockData? Parse(String[] fields)
        {
            StockData? ret;
            try
            {
                ret = new StockData(
                     float.Parse(fields[1]), float.Parse(fields[2]),
                     float.Parse(fields[3]), float.Parse(fields[4]));
            } catch (Exception e) { ret = null; }
            return ret;
        }
    }
}
