﻿namespace Infrastructure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_GetData = new Button();
            button_Exit = new Button();
            dataGridView1 = new DataGridView();
            button_Stop = new Button();
            dataGridView2_Bybit = new DataGridView();
            dataGridView_Kucoin = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2_Bybit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Kucoin).BeginInit();
            SuspendLayout();
            // 
            // button_GetData
            // 
            button_GetData.Location = new Point(487, 560);
            button_GetData.Name = "button_GetData";
            button_GetData.Size = new Size(131, 23);
            button_GetData.TabIndex = 0;
            button_GetData.Text = "Получить данные";
            button_GetData.UseVisualStyleBackColor = true;
            button_GetData.Click += button_GetData_Click;
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(1267, 560);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(75, 23);
            button_Exit.TabIndex = 1;
            button_Exit.Text = "Выход";
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(4, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(329, 510);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(624, 560);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(132, 23);
            button_Stop.TabIndex = 3;
            button_Stop.Text = "Стоп";
            button_Stop.UseVisualStyleBackColor = true;
            button_Stop.Click += button_Stop_Click;
            // 
            // dataGridView2_Bybit
            // 
            dataGridView2_Bybit.AllowUserToAddRows = false;
            dataGridView2_Bybit.AllowUserToDeleteRows = false;
            dataGridView2_Bybit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2_Bybit.Location = new Point(350, 34);
            dataGridView2_Bybit.Name = "dataGridView2_Bybit";
            dataGridView2_Bybit.ReadOnly = true;
            dataGridView2_Bybit.Size = new Size(321, 510);
            dataGridView2_Bybit.TabIndex = 4;
            dataGridView2_Bybit.CellContentClick += dataGridView2_Bybit_CellContentClick;
            // 
            // dataGridView_Kucoin
            // 
            dataGridView_Kucoin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Kucoin.Location = new Point(711, 34);
            dataGridView_Kucoin.Name = "dataGridView_Kucoin";
            dataGridView_Kucoin.Size = new Size(298, 510);
            dataGridView_Kucoin.TabIndex = 5;
            dataGridView_Kucoin.CellContentClick += dataGridView_Kucoin_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(132, 12);
            label1.Name = "label1";
            label1.Size = new Size(51, 17);
            label1.TabIndex = 6;
            label1.Text = "Binance";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(505, 12);
            label2.Name = "label2";
            label2.Size = new Size(36, 17);
            label2.TabIndex = 7;
            label2.Text = "Bybit";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(828, 12);
            label3.Name = "label3";
            label3.Size = new Size(46, 17);
            label3.TabIndex = 8;
            label3.Text = "Kucoin";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 595);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView_Kucoin);
            Controls.Add(dataGridView2_Bybit);
            Controls.Add(button_Stop);
            Controls.Add(dataGridView1);
            Controls.Add(button_Exit);
            Controls.Add(button_GetData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2_Bybit).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Kucoin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_GetData;
        private Button button_Exit;
        private DataGridView dataGridView1;
        private Button button_Stop;
        private DataGridView dataGridView2_Bybit;
        private DataGridView dataGridView_Kucoin;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
