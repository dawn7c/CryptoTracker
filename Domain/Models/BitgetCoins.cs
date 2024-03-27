using Bitget.Net.Clients;
using Domain.Abstractions;


namespace Domain.Models
{
    public class BitgetCoins : Coin, IRepository
    {
        private bool stopGetData;
        private static string bitGetApi = "wss://ws.bitget.com/v2/ws/public";

        public event Action<string, DateTime, decimal>DataReceivedBitGet;
        private BitgetSocketClient bitGetSocketClient;

        public async Task GetDataFromApi(string pair, int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    bitGetSocketClient = new BitgetSocketClient();
                    var tickerSubscriptionResult = await bitGetSocketClient.SpotApi.SubscribeToTickerUpdatesAsync(pair, (update) =>
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

        public void StopDataFetching()
        {
            stopGetData = true;
        }
    }
}
