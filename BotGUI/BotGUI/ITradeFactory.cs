using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal interface ITradeFactory
    {
        // fill or kill
        public static readonly Func<float, float, float, int, int> FOK =
            (curPrice, minCost, maxCost, shares) => {
                if (curPrice * shares < minCost)
                    return 0;
                if (curPrice * shares > maxCost)
                    return 0;
                return shares;
            };
        // immediate or cancel
        public static readonly Func<float, float, float, int, int> IOC =
            (curPrice, minCost, maxCost, shares) => {
                if (curPrice * shares < minCost)
                    return 0;
                // floor because we aren't doing partial shares
                return Math.Min((int)Math.Floor(maxCost / curPrice), shares);
            };
        // all our orders will behave like limit orders, since a limit order
        // with unlimited max cost or no min cost is just like a market order
        // another way of interpreting these two is a FOK is "all or nothing"
        // while IOC is "partial execution"
        public static ITradeFactory makeFactory(bool buy)
        {
            return buy ? new BuyTradeFactory() : new SellTradeFactory();
        }
        public AbstractTrade createTrade(bool fok, Bot b);
    }
}
