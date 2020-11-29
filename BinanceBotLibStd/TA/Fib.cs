using Binance.Net;
using ExchangeClientLib;
using System;
using System.Linq;
using System.Text;

namespace BinanceBotLib
{
    public class Fib
    {
        public decimal PriceBullShortClose { get; private set; }
        public decimal PriceBullLongClose { get; private set; }
        public decimal PriceBearShortClose { get; private set; }
        public decimal PriceBearLongClose { get; private set; }

        public Fib(TradingData trade)
        {
            using (var tempClient = new BinanceClient())
            {
                var dataLast24hr = tempClient.FuturesUsdt.Market.Get24HPrices(trade.CoinPair.ToString()).Data.First();
                var fundingRate = tempClient.FuturesUsdt.Market.GetFundingRates(trade.CoinPair.ToString()).Data.First().FundingRate;
                decimal priceDiff = dataLast24hr.HighPrice - dataLast24hr.LowPrice;

                PriceBullShortClose = Math.Round(dataLast24hr.HighPrice - 0.236m * priceDiff, 0);
                PriceBullLongClose = Math.Round(trade.Price + 0.618m * priceDiff, 0);
                PriceBearShortClose = Math.Round(trade.Price - 0.236m * priceDiff, 0);
                PriceBearLongClose = Math.Round(trade.Price + 0.236m * priceDiff, 0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"PriceBullShortClose {PriceBullShortClose}");
            sb.AppendLine($"PriceBullLongClose {PriceBullLongClose}");
            sb.AppendLine($"PriceBearShortClose {PriceBearShortClose}");
            sb.AppendLine($"PriceBearLongClose {PriceBearLongClose}");
            return sb.ToString();
        }
    }
}
