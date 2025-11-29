using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // static class that functions as the "stock market"
    // stores hashmaps of stocks across the whole market we're simulating
    // almost like global variables too
    internal static class Market
    {
        static readonly Date safeMinDate = new Date(1999, 1, 1);
        static readonly Date safeMaxDate = new Date(2021, 1, 1);
        static List<IListener> listeners = new List<IListener>();
        static List<IBackListener> blisteners = new List<IBackListener>();
        static List<AbstractTrade> pending = new List<AbstractTrade>();
        static Date curDate = new Date(2005, 5, 2);
        static Random rand = new Random(DateTimeOffset.UtcNow.Millisecond);
        static Dictionary<String, Dictionary<Date, StockData>> stockMarket = new Dictionary<String, Dictionary<Date, StockData>>();
        static HashSet<Date> validDate = new HashSet<Date>();
        static String log = "";
        static mainForm? form;
        static List<Bot> bots = new List<Bot>();
        public static void init(mainForm f)
        {
            form = f;
            // assuming windows, need to maybe modify that?
            String here = Directory.GetCurrentDirectory();
            here += "\\stockdata";
            String[] stockfiles = Directory.GetFiles(here);
            foreach(String file in stockfiles)
            {
                String[] lines = File.ReadAllLines(file);
                String[] temp = file.Split("\\");
                String ticker = temp[temp.Length - 1].Split(".")[0];
                stockMarket[ticker] = new Dictionary<Date, StockData>();
                for (int i = 1; i < lines.Length; ++i)
                {
                    String[] fields = lines[i].Split(",");
                    if (fields.Length > 4)
                    {
                        StockData? sd = StockData.Parse(fields);
                        if (sd != null)
                        {
                            Date d = Date.parseDate(fields[0]);
                            stockMarket[ticker][d] = (StockData) sd;
                            validDate.Add(d);
                        }
                    }
                }
            }
            listeners.Add(f);
            blisteners.Add(f);
            log += "Finished initializing stock data from files\n";
            refresh();
        }
        public static void tick()
        {
            foreach (AbstractTrade trade in pending)
            {
                trade.execute();
            }
            pending.Clear();
            curDate = getNextDate(curDate);
            foreach (IListener listener in listeners)
            {
                listener.notify();
            }
        }
        public static Date getPrevDate(Date d)
        {
            do
            {
                --d;
                if (d < safeMinDate) break; // or throw exception?
            } while (!validDate.Contains(d));
            return d;
        }

        public static void refresh()
        {
            form.notify();
        }

        public static void submit(AbstractTrade trade)
        {
            pending.Add(trade);
            log += "Trade order submitted to clearing house:\n";
            log += trade.describe() + "\n";
        }

        public static Date getNextDate(Date d)
        {
            do
            {
                ++d;
                if (d > safeMaxDate) break; // or throw exception?
            } while (!validDate.Contains(d));
            return d;
        }
        public static void back()
        {
            foreach (AbstractTrade t in pending)
            {
                t.cancel();
            }
            pending.Clear();
            curDate = getPrevDate(curDate);
            List<IBackListener> temp = new List<IBackListener>();
            foreach (IBackListener listener in blisteners)
            {
                if (listener.back()) temp.Add(listener);
            }
            foreach (var listener in temp)
                blisteners.Remove(listener);
        }

        public static void addListener(Bot b)
        {
            listeners.Insert(0, b);
        }

        public static void addBListener(AbstractTrade t)
        {
            blisteners.Insert(0, t);
        }

        public static Date getDate()
        {
            // don't pass the curdate object directly! it gets modified!
            return curDate.clone();
        }

        public static void addBot(Bot b)
        {
            bots.Add(b);
            form.notify();
        }

        public static void addLog(String s)
        {
            log += s;
        }

        public static List<Bot> getBots()
        {
            return bots;
        }

        public static String getLog()
        {
            return log;
        }

        public static String getBLog()
        {
            String ret = "";
            for (int i = 0; i < bots.Count; ++i)
            {
                if (i > 0)
                    ret += "=====================\n";
                ret += bots[i].describe();
            }
            return ret;
        }

        public static float calcVal()
        {
            float ret = 0;
            foreach (Bot b in bots)
                ret += b.calcVal();
            return ret;
        }

        public static float getVal(String s, Date d)
        {
            // getting the value on the current day should always be uncertain! this is the stock market!
            if (d == getDate())
            {
                StockData temp = stockMarket[s].GetValueOrDefault(d, StockData.empty);
                if (temp.high == 0)
                    return 0;
                return temp.low + (temp.high - temp.low) * (float) rand.NextDouble();
            }
            // use closing price for any previous day
            return stockMarket[s].GetValueOrDefault(d, StockData.empty).close;
        }

        public static int random(int n)
        {
            return rand.Next(n);
        }
    }
}
