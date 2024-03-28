using Binance.Net.Clients;
using Domain.Abstractions;

namespace Domain.Models
{
    public class BinanceCoins : Coin, IRepository
    {
        public event Action<string, DateTime, decimal> DataReceivedBinance;
        private BinanceSocketClient socketClient;
        private bool stopGetData;
        
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

        public void StopDataFetching()
        {
            stopGetData = true;
        }
        public async Task StopData()
        {
            await socketClient.UnsubscribeAllAsync();
            socketClient = null;
        }
    }
}
