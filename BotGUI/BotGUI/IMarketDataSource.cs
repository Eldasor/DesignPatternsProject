using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal interface IMarketDataSource
    {
        public void load(Dictionary<String, StockHistory> datapool, String file);
    }
}
