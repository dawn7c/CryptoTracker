using Binance.Net.Clients;
using Bybit.Net.Clients;
using CryptoExchange.Net.Interfaces;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Models
{
    public class BybitCoins : Coin, IRepository
    {
        private static string bybitAPI = "wss://stream.bybit.com/v5/public/spot";

        public event Action<string, DateTime, decimal> DataReceivedBybit;
        private BybitSocketClient bybitSocketClient;

        public async Task GetDataFromApi(int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    bybitSocketClient = new BybitSocketClient();

                    var tickerSubscriptionResult = await bybitSocketClient.V5SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT", (update) =>
                    {
                        DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                        DataReceivedBybit?.Invoke(update.Data.Symbol,moscowTime,update.Data.LastPrice);
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
