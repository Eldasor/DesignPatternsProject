using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class WindowsFileSystemMarketDataSource : IMarketDataSource
    {
        public void load(Dictionary<String, StockHistory> datapool, String file)
        {
            String[] lines = File.ReadAllLines(file);
            String[] temp = file.Split("\\");
            String ticker = temp[temp.Length - 1].Split(".")[0];
            datapool[ticker] = StockHistory.makeStockHistory(ticker, lines);
        }
    }
}
