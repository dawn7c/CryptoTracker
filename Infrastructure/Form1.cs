using Domain;
using Domain.Models;
using System.ComponentModel;
using static Domain.Models.BinanceCoins;

namespace Infrastructure
{
    public partial class Form1 : Form
    {
        private BindingList<TradeData> tradeDataList = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListBybit = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListKucoin = new BindingList<TradeData>();
        private BindingList<TradeData> tradeDataListBitGet = new BindingList<TradeData>();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = tradeDataList;
            dataGridView2_Bybit.DataSource = tradeDataListBybit;
            dataGridView_Kucoin.DataSource = tradeDataListKucoin;
            dataGridView_BitGet.DataSource = tradeDataListBitGet;
        }

        private async void button_GetData_Click(object sender, EventArgs e)
        {
            button_Stop.Enabled = true;
            BinanceCoins binanceCoins = new BinanceCoins();
            BybitCoins bybitCoins = new BybitCoins();
            KucoinCoins kucoinCoins = new KucoinCoins();
            BitgetCoins bitgetCoins = new BitgetCoins();
            binanceCoins.DataReceivedBinance += OnDataReceived;
            bybitCoins.DataReceivedBybit += OnDataReceivedBybit;
            kucoinCoins.DataReceivedKucoin += OnDataReceivedKucoin;
            bitgetCoins.DataReceivedBitGet += OnDataReceivedBitGet;
            // Запускаем получение данных из API в асинхронном режиме
            await Task.WhenAll(binanceCoins.GetDataFromApi(5), bybitCoins.GetDataFromApi(5), kucoinCoins.GetDataFromApi(5), bitgetCoins.GetDataFromApi(5));

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void OnDataReceived(string symbol, DateTime tradeTime, decimal price)
        {
            // Обновляем UI через поток, в котором он был создан
            Invoke(new MethodInvoker(delegate
            {
                // Добавляем новые данные в список для отображения в dataGridView1
                tradeDataList.Add(new TradeData { Symbol = symbol, TradeTime = tradeTime, Price = price });
            }));
        }

        private void OnDataReceivedBybit(string symbol, DateTime timestamp, decimal lastPrice)
        {
            Invoke(new MethodInvoker(delegate
            {
                tradeDataListBybit.Add(new TradeData { Symbol = symbol, TradeTime = timestamp, Price = lastPrice });
            }));
        }
        private void OnDataReceivedKucoin(string symbol, DateTime timestamp, decimal lastPrice)
        {
            Invoke(new MethodInvoker(delegate
            {
                tradeDataListKucoin.Add(new TradeData { Symbol = symbol, TradeTime = timestamp, Price = lastPrice });
            }));
        }
        private void OnDataReceivedBitGet(string symbol, DateTime timestamp,decimal price)
        {
            Invoke(new MethodInvoker(delegate
            {
                tradeDataListBitGet.Add(new TradeData { Symbol = symbol, TradeTime = timestamp, Price = price});
            }));
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {

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
    }
}
