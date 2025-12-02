using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal struct StockBar
    {
        public static StockBar empty = new StockBar(0, 0, 0, 0, 0, 0);
        public float open;
        public float high;
        public float low;
        public float close;
        public float adj;
        public float volume;
        public StockBar(float a, float b, float c, float d, float e, float f)
        {
            open = a; high = b; low = c; close = d; adj = e; volume = f;
        }
        public static StockBar? makeStockBar(String[] fields)
        {
            StockBar? ret;
            try
            {
                ret = new StockBar(
                     float.Parse(fields[1]), float.Parse(fields[2]),
                     float.Parse(fields[3]), float.Parse(fields[4]),
                     float.Parse(fields[5]), float.Parse(fields[6]));
            } catch (Exception e) { ret = null; }
            return ret;
        }
    }
}
