using Binance.Net.Clients;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Domain.Abstractions;

namespace Domain.Models
{
    public class BinanceCoins : Coin, IRepository
    {
        public event Action<string, DateTime, decimal> DataReceivedBinance;
        private BinanceSocketClient socketClient;
        private bool stopGetData;
        private static string binanceApi = "wss://stream.binance.com:9443";
        
        public async Task GetDataFromApi(string pair, int intervalSeconds)
        {
            try
            {
                if (socketClient != null)
                {
                    await socketClient.UnsubscribeAllAsync();
                    socketClient = null;
                }
                socketClient = new BinanceSocketClient();
                var subscription = await socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(pair, data =>
                {
                    DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(data.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
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

        
    }
}
