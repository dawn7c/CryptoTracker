
using Domain.Abstractions;
using Kucoin.Net.Clients;


namespace Domain.Models
{
    public class KucoinCoins : Coin, IRepository
    {
        private bool stopGetData;
        private static string kucoinApi = "wss://ws-api-spot.kucoin.com/";
        public event Action<string, DateTime, decimal> DataReceivedKucoin;
        private KucoinSocketClient kucoinSocketClient;

        public async Task GetDataFromApi(string pair, int intervalSeconds)
        {
            string formattedPair = FormatPairForKucoin(pair);
            while (true)
            {
                try
                {
                    kucoinSocketClient = new KucoinSocketClient();
                    var tickerSubscriptionResult = await kucoinSocketClient.SpotApi.SubscribeToTickerUpdatesAsync(formattedPair, (update) =>
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

        public void StopDataFetching()
        {
            stopGetData = true;
        }

        private string FormatPairForKucoin(string pair)
        {
            if (pair.Contains("-")) // Уже в формате Kucoin
            {
                return pair;
            }
            // Преобразуем пару в формат для Kucoin, добавляя тире
            return pair.Replace("BTCUSDT", "BTC-USDT") // Пример преобразования для Kucoin
                       .Replace("ETHUSDT", "ETH-USDT") // Другие преобразования для Kucoin
                       .Replace("XRPUSDT", "XRP-USDT");
        }
    }
}
