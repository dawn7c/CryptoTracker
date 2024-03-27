using Domain;
using Domain.Models;
using System.ComponentModel;
using static Domain.Models.BinanceCoins;

namespace Infrastructure
{
    public partial class Form1 : Form
    {
        private string selectedPair;
        private bool stopDataFetching = false;
        private BinanceCoins binanceCoins;
        private BybitCoins bybitCoins;
        private KucoinCoins kucoinCoins;
        private BitgetCoins bitgetCoins;

        private BindingList<TradeData> tradeDataList = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListBybit = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListKucoin = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListBitGet = new BindingList<TradeData>();
        private List<string> pairs = new List<string> { "BTCUSDT", "ETHUSDT", "XRPUSDT" };
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = tradeDataList;
            dataGridView2_Bybit.DataSource = tradeDataListBybit;
            dataGridView_Kucoin.DataSource = tradeDataListKucoin;
            dataGridView_BitGet.DataSource = tradeDataListBitGet;
            comboBox.Text = "Выберите пару";
            comboBox.Items.AddRange(pairs.ToArray());
        }

        private async void button_GetData_Click(object sender, EventArgs e)
        {
            if (stopDataFetching)
            {
                stopDataFetching = false; // Сбрасываем флаг остановки получения данных
                button_Stop.Enabled = true; // Делаем кнопку "Стоп" доступной
            }

            
                ClearTradeDataLists();


                if (binanceCoins != null)
                {
                    binanceCoins.DataReceivedBinance -= OnDataReceived;
                }
                if (bybitCoins != null)
                {
                    bybitCoins.DataReceivedBybit -= OnDataReceived;
                }
                if (kucoinCoins != null)
                {
                    kucoinCoins.DataReceivedKucoin -= OnDataReceived;
                }
                if (bitgetCoins != null)
                {
                    bitgetCoins.DataReceivedBitGet -= OnDataReceived;
                }
                //binanceCoins.DataReceivedBinance -= OnDataReceived;
                //bybitCoins.DataReceivedBybit -= OnDataReceivedBybit;
                // kucoinCoins.DataReceivedKucoin -= OnDataReceivedKucoin;
                //bitgetCoins.DataReceivedBitGet -= OnDataReceivedBitGet;
                
            
            await GetDataFromAllApi();

        }
        private async Task GetDataFromAllApi()
        {
            Task binanceTask = Task.Run(() => GetDataFromBinance());
            Task bybitTask = Task.Run(() => GetDataFromBybit());
            Task kucoinTask = Task.Run(() => GetDataFromKucoin());
            Task bitgetTask = Task.Run(() => GetDataFromBitget());

            await Task.WhenAll(binanceTask, bybitTask, kucoinTask, bitgetTask);


        }

        private void ClearTradeDataLists()
        {
            tradeDataList.Clear();
            tradeDataListBybit.Clear();
            tradeDataListKucoin.Clear();
            tradeDataListBitGet.Clear();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedPair = comboBox.Text;

        }
        private async Task GetDataFromBinance()
        {
            if (selectedPair != null)
            {
                binanceCoins = new BinanceCoins();
                binanceCoins.DataReceivedBinance += OnDataReceived;
                await binanceCoins.GetDataFromApi(selectedPair, 5);
            }
            
        }
        private async Task GetDataFromBybit()
        {
            if (selectedPair != null)
            {
                bybitCoins = new BybitCoins();
                bybitCoins.DataReceivedBybit += OnDataReceivedBybit;
                await bybitCoins.GetDataFromApi(selectedPair, 5);
            }
            
        }
        private async Task GetDataFromKucoin()
        {
            if (selectedPair != null) 
            {
                kucoinCoins = new KucoinCoins();
                kucoinCoins.DataReceivedKucoin += OnDataReceivedKucoin;
                await kucoinCoins.GetDataFromApi(selectedPair, 5);
            }
        }
        private async Task GetDataFromBitget()
        {
            if (selectedPair != null)
            {
                bitgetCoins = new BitgetCoins();
                bitgetCoins.DataReceivedBitGet += OnDataReceivedBitGet;
                await bitgetCoins.GetDataFromApi(selectedPair, 5);
            }
                
        }

        private void OnDataReceived(string symbol, DateTime tradeTime, decimal price)
        {
            if (stopDataFetching) return;
            Invoke(new MethodInvoker(delegate
            {
                tradeDataList.Add(new TradeData { Symbol = symbol, ChangeTime = tradeTime, Price = price });
            }));
        }

        private void OnDataReceivedBybit(string symbol, DateTime timestamp, decimal lastPrice)
        {
            if (stopDataFetching) return;
            Invoke(new MethodInvoker(delegate
            {
                tradeDataListBybit.Add(new TradeData { Symbol = symbol, ChangeTime = timestamp, Price = lastPrice });
            }));
        }
        private void OnDataReceivedKucoin(string symbol, DateTime timestamp, decimal lastPrice)
        {
            if (stopDataFetching) return;

            Invoke(new MethodInvoker(delegate
            {
                tradeDataListKucoin.Add(new TradeData { Symbol = symbol, ChangeTime = timestamp, Price = lastPrice });
            }));
        }
        private void OnDataReceivedBitGet(string symbol, DateTime timestamp, decimal price)
        {
            if (stopDataFetching) return;
            Invoke(new MethodInvoker(delegate
            {
                tradeDataListBitGet.Add(new TradeData { Symbol = symbol, ChangeTime = timestamp, Price = price });
            }));
        }
        

        private void button_Stop_Click(object sender, EventArgs e)
        {
            stopDataFetching = true;

            button_Stop.Enabled = false;

        }

        private void dataGridView2_Bybit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Kucoin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_BitGet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
