﻿using Bybit.Net.Clients;
using Domain.Abstractions;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class KucoinCoins : Coin, IRepository
    {
        private static string kucoinApi = "wss://ws-api-spot.kucoin.com/";
        public event Action<string, DateTime, decimal> DataReceivedKucoin;
        private KucoinSocketClient kucoinSocketClient;

        public async Task GetDataFromApi(int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    kucoinSocketClient = new KucoinSocketClient();
                    var tickerSubscriptionResult = await kucoinSocketClient.SpotApi.SubscribeToTickerUpdatesAsync("BTC-USDT", (update) =>
                    {
                        DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                        DataReceivedKucoin?.Invoke(update.Topic, moscowTime, (decimal)update.Data.LastPrice);
                    });
                    await Task.Delay(TimeSpan.FromSeconds(intervalSeconds));
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error API: {ex.Message}");
                }
            }
            
        }
    }
}
