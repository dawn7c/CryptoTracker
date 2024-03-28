using Bitget.Net.Clients;
using Domain.Abstractions;

namespace Domain.Models
{
    public class BitgetCoins : Coin, IRepository
    {
        public event Action<string, DateTime, decimal>DataReceivedBitGet;
        private BitgetSocketClient bitGetSocketClient;

        public async Task GetDataFromApi(string pair, int intervalSeconds, bool stopGetData)
        {
            try
            {
                bitGetSocketClient = new BitgetSocketClient();
                var tickerSubscriptionResult = await bitGetSocketClient.SpotApi.SubscribeToTickerUpdatesAsync(pair, update =>
                {
                    DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(update.Data.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
                    DataReceivedBitGet?.Invoke(update.Data.Symbol, moscowTime, update.Data.LastPrice);
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
            await bitGetSocketClient.UnsubscribeAllAsync();
            bitGetSocketClient = null;
        }

    }
}
