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
    internal class Market
    {
        // consider these "global" variables, or constants
        static readonly Date safeMinDate = new Date(1999, 1, 1);
        static readonly Date safeMaxDate = new Date(2021, 1, 1);
        // assuming windows, need to maybe modify that?
        static readonly String directory = Directory.GetCurrentDirectory() + "\\stockdata";
        static Market? instance;
        static readonly IMarketDataSource dataSourceReader = new WindowsFileSystemMarketDataSource();
        private static Object _lock = new Object();

        List<IListener> listeners = new List<IListener>();
        List<IBackListener> blisteners = new List<IBackListener>();
        List<AbstractTrade> pending = new List<AbstractTrade>();
        Date curDate = new Date(2005, 5, 2);
        Random rand = new Random(DateTimeOffset.UtcNow.Millisecond);
        Dictionary<String, StockHistory> stockMarket = new Dictionary<String, StockHistory>();
        HashSet<Date> validDate = new HashSet<Date>();
        String log = "";
        mainForm? form;
        List<Bot> bots = new List<Bot>();
        
        private Market()
        {

        }
        public void init(mainForm? f)
        {
            form = f;
            String[] stockfiles = Directory.GetFiles(directory);
            foreach(String file in stockfiles)
            {
                dataSourceReader.load(stockMarket, file);
            }
            if (f != null)
            {
                listeners.Add(f);
                blisteners.Add(f);
            }
            log += "Finished initializing stock data from files\n";
            refresh();
        }
        public void tick()
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
        public Date getPrevDate(Date d)
        {
            do
            {
                --d;
                if (d < safeMinDate) break; // or throw exception?
            } while (!validDate.Contains(d));
            return d;
        }

        public void refresh()
        {
            form.notify();
        }

        public void submit(AbstractTrade trade)
        {
            pending.Add(trade);
            log += "Trade order submitted to clearing house:\n";
            log += trade.describe() + "\n";
        }

        public Date getNextDate(Date d)
        {
            do
            {
                ++d;
                if (d > safeMaxDate) break; // or throw exception?
            } while (!validDate.Contains(d));
            return d;
        }
        public void back()
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

        public void addListener(Bot b)
        {
            listeners.Insert(0, b);
        }

        public void addBListener(AbstractTrade t)
        {
            blisteners.Insert(0, t);
        }

        public Date getDate()
        {
            // don't pass the curdate object directly! it gets modified!
            return curDate.clone();
        }

        public void addBot(Bot b)
        {
            bots.Add(b);
            form.notify();
        }

        public void addLog(String s)
        {
            log += s;
        }

        public List<Bot> getBots()
        {
            return bots;
        }

        public String getLog()
        {
            return log;
        }

        public String getBLog()
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

        public float calcVal()
        {
            float ret = 0;
            foreach (Bot b in bots)
                ret += b.calcVal();
            return ret;
        }

        public float getVal(String s, Date d)
        {
            // getting the value on the current day should always be uncertain! this is the stock market!
            if (d == getDate())
            {
                StockBar temp = stockMarket[s].get(d);
                if (temp.high == 0)
                    return 0;
                return temp.low + (temp.high - temp.low) * (float) rand.NextDouble();
            }
            // use closing price for any previous day
            return stockMarket[s].get(d).close;
        }

        public int random(int n)
        {
            return rand.Next(n);
        }

        public void addValidDate(Date d)
        {
            validDate.Add(d);
        }

        // singleton
        public static Market getInstance(mainForm? from = null)
        {
            if (instance == null)
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new Market();
                        instance.init(from);
                    }
                }
            }
            if (from != null && instance.form == null)
                instance.form = from;
            return instance;
        }
    }
}
