using Domain;
using Domain.Models;
using System.ComponentModel;
using static Domain.Models.BinanceCoins;

namespace Infrastructure
{
    public partial class Form1 : Form
    {
        private BindingList<TradeData> tradeDataList = new BindingList<TradeData>();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = tradeDataList;
        }

        private void button_GetData_Click(object sender, EventArgs e)
        {
            BinanceCoins binanceCoins = new BinanceCoins();
            GetDataDelegate getDataDelegate = binanceCoins.GetDataFromApi;

            getDataDelegate(1);
            dataGridView1.DataSource = binanceCoins.Symbol;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void OnDataReceived(string tradeTime, decimal quantity, decimal price)
        {
            // Обновляем UI через поток, в котором он был создан
            Invoke(new MethodInvoker(delegate
            {
                // Добавляем новые данные в список для отображения в dataGridView1
                tradeDataList.Add(new TradeData { TradeTime = tradeTime, Quantity = quantity, Price = price });
            }));
        }
    }
}
