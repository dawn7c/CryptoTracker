﻿
using Domain.Abstractions;
using Kucoin.Net.Clients;


namespace Domain.Models
{
    public class KucoinCoins :  IRepository
    {
        public event Action<string, DateTime, decimal> DataReceivedKucoin;
        public KucoinSocketClient kucoinSocketClient;
        
        public async Task GetDataFromApi(string pair, int intervalSeconds, bool stopGetData)
        {
            string formattedPair = FormatPairForKucoin(pair);
            try
            {
                kucoinSocketClient = new KucoinSocketClient();
                var tickerSubscriptionResult = await kucoinSocketClient.SpotApi.SubscribeToTickerUpdatesAsync(formattedPair, update =>
                {
                    DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Data.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                    DataReceivedKucoin?.Invoke(update.Topic, moscowTime, (decimal)update.Data.LastPrice);
                });
                await Task.Delay(TimeSpan.FromSeconds(intervalSeconds));
            }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error API: {ex.Message}");
                }
        }
        public async Task StopData()
        {
            await kucoinSocketClient.UnsubscribeAllAsync();
            kucoinSocketClient = null;
        }
        
        private string FormatPairForKucoin(string pair)
        {
            if (pair.Contains("-")) 
            {
                return pair;
            }
            
            return pair.Replace("BTCUSDT", "BTC-USDT") 
                       .Replace("ETHUSDT", "ETH-USDT") 
                       .Replace("XRPUSDT", "XRP-USDT");
        }
    }
}
