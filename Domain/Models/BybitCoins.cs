
using Bybit.Net.Clients;
using Domain.Abstractions;


namespace Domain.Models
{
    public class BybitCoins : Coin, IRepository
    {
        private bool stopGetData;
        private static string bybitAPI = "wss://stream.bybit.com/v5/public/spot";

        public event Action<string, DateTime, decimal> DataReceivedBybit;
        private BybitSocketClient bybitSocketClient;

        public async Task GetDataFromApi(string pair, int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    bybitSocketClient = new BybitSocketClient();

                    var tickerSubscriptionResult = await bybitSocketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(pair, (update) =>
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

        public void StopDataFetching()
        {
            stopGetData = true;
        }
    }
}
