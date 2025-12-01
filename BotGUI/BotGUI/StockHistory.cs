using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class StockHistory
    {
        String ticker;
        Dictionary<Date, StockBar> stockdata;
        public StockHistory(String t, Dictionary<Date, StockBar> data)
        {
            ticker = t;
            stockdata = data;
        }

        // static factory method
        public static StockHistory makeStockHistory(String t, String[] lines)
        {
            Dictionary<Date, StockBar> data = new Dictionary<Date, StockBar>();
            for (int i = 1; i < lines.Length; ++i)
            {
                String[] fields = lines[i].Split(",");
                if (fields.Length > 4)
                {
                    StockBar? sd = StockBar.makeStockBar(fields);
                    if (sd != null)
                    {
                        Date d = Date.parseDate(fields[0]);
                        data[d] = (StockBar)sd;
                        Market.getInstance().addValidDate(d);
                    }
                }
            }
            return new StockHistory(t, data);
        }
        public StockBar get(Date d)
        {
            return stockdata.GetValueOrDefault(d, StockBar.empty);
        }
    }
}
