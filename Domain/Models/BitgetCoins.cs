using Bitget.Net.Clients;

using Domain.Abstractions;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BitgetCoins : Coin, IRepository
    {
        private static string bitGetApi = "wss://ws.bitget.com/v2/ws/public";

        public event Action<string, DateTime, decimal>DataReceivedBitGet;
        private BitgetSocketClient bitGetSocketClient;

        public async Task GetDataFromApi(int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    bitGetSocketClient = new BitgetSocketClient();
                    var tickerSubscriptionResult = await bitGetSocketClient.SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT", (update) =>
                    {
                        DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Timestamp,TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                        DataReceivedBitGet?.Invoke(update.Topic, moscowTime, update.Data.LastPrice);
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
