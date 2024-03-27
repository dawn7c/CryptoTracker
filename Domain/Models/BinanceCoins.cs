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
        public event Action<string, decimal, decimal> DataReceived;
        private BinanceSocketClient socketClient;

        private static string binanceApi = "wss://stream.binance.com:9443";
        //public ObservableCollection<BinanceSymbolViewModel> AllPrices;

        public async Task GetDataFromApi(int intervalMinutes)
        {
            while (true)
            {
                try
                {
                    socketClient = new BinanceSocketClient();
                    
                    var subscription = await socketClient.SpotApi.ExchangeData.SubscribeToTradeUpdatesAsync("BTCUSDT", data =>
                    {
                        DataReceived?.Invoke(data.Data.TradeTime, data.Data.Quantity, data.Data.Price);

                    });
                    //List<Coin> coinList = new List<Coin>();
                    //using (ClientWebSocket client = new ClientWebSocket())
                    //{
                    //    await client.ConnectAsync(new Uri(binanceApi), CancellationToken.None);
                    //    var buffer = new byte[1024];
                    //    WebSocketReceiveResult result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    //    //HttpResponseMessage response = await client.(binanceApi);
                    //    //response.EnsureSuccessStatusCode();
                    //    //string data = await response.Content.ReadAsStringAsync();
                    //    //coinList = JsonConvert.DeserializeObject<List<Coin>>(data);
                    //    //await Task.Delay(TimeSpan.FromMinutes(intervalMinutes));
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error API: {ex.Message}");
                }
            }

        }

        public delegate Task GetDataDelegate(int intervalMinutes);
    }
}
