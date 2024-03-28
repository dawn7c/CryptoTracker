
using Bitget.Net.Clients;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces;
using Domain.Abstractions;


namespace Domain.Models
{
    public class BybitCoins : Coin, IRepository
    {
        public event Action<string, DateTime, decimal> DataReceivedBybit;
        private BybitSocketClient bybitSocketClient;

        public async Task GetDataFromApi(string pair, int intervalSeconds, bool stopGetData)
        {
            try
            {
                bybitSocketClient = new BybitSocketClient();

                var tickerSubscriptionResult = await bybitSocketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(pair, update =>
                {
                    DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                    DataReceivedBybit?.Invoke(update.Data.Symbol, moscowTime, update.Data.LastPrice);
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
            await bybitSocketClient.UnsubscribeAllAsync();
            bybitSocketClient = null;
        }
    }
}
