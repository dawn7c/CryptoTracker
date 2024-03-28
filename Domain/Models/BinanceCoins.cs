using Binance.Net.Clients;
using Domain.Abstractions;

namespace Domain.Models
{
    public class BinanceCoins : IRepository
    {
        public event Action<string, DateTime, decimal> DataReceivedBinance;
        private BinanceSocketClient socketClient;
        
        public async Task GetDataFromApi(string pair, int intervalSeconds, bool stopGetData)
        {
            try
            {
                socketClient = new BinanceSocketClient();
                var subscription = await socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(pair, data =>
                {
                    DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(data.Data.OpenTime, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                    DataReceivedBinance?.Invoke(data.Data.Symbol, moscowTime, data.Data.LastPrice);

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
            await socketClient.UnsubscribeAllAsync();
            socketClient = null;
        }
    }
}
