using Binance.Net.Clients;
using Domain.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BinanceCoins : Coin, IRepository
    {
        public event Action<string, DateTime, decimal, decimal> DataReceived;
        private BinanceSocketClient socketClient;

        private static string binanceApi = "wss://stream.binance.com:9443";
        

        public async Task GetDataFromApi(int intervalSeconds)
        {
            while (true)
            {
                try
                {
                    socketClient = new BinanceSocketClient();
                    
                    var subscription = await socketClient.SpotApi.ExchangeData.SubscribeToTradeUpdatesAsync("BTCUSDT", data =>
                    {
                        DataReceived?.Invoke(data.Data.Symbol, data.Data.TradeTime, data.Data.Quantity, data.Data.Price);

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
