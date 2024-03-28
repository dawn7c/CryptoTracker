namespace Infrastructure
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
            dataGridView_BitGet = new DataGridView();
            label4 = new Label();
            comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2_Bybit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Kucoin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BitGet).BeginInit();
            SuspendLayout();
            // 
            // button_GetData
            // 
            button_GetData.Location = new Point(516, 575);
            button_GetData.Name = "button_GetData";
            button_GetData.Size = new Size(131, 23);
            button_GetData.TabIndex = 0;
            button_GetData.Text = "Получить данные";
            button_GetData.UseVisualStyleBackColor = true;
            button_GetData.Click += button_GetData_Click;
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(1297, 575);
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
            dataGridView1.Location = new Point(6, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(331, 500);
            dataGridView1.TabIndex = 2;
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(653, 575);
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
            dataGridView2_Bybit.Location = new Point(360, 57);
            dataGridView2_Bybit.Name = "dataGridView2_Bybit";
            dataGridView2_Bybit.ReadOnly = true;
            dataGridView2_Bybit.Size = new Size(325, 500);
            dataGridView2_Bybit.TabIndex = 4;
            // 
            // dataGridView_Kucoin
            // 
            dataGridView_Kucoin.AllowUserToAddRows = false;
            dataGridView_Kucoin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Kucoin.Location = new Point(710, 57);
            dataGridView_Kucoin.Name = "dataGridView_Kucoin";
            dataGridView_Kucoin.Size = new Size(325, 500);
            dataGridView_Kucoin.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(131, 37);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(51, 17);
            label1.TabIndex = 6;
            label1.Text = "Binance";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(507, 37);
            label2.Name = "label2";
            label2.Size = new Size(36, 17);
            label2.TabIndex = 7;
            label2.Text = "Bybit";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(841, 37);
            label3.Name = "label3";
            label3.Size = new Size(46, 17);
            label3.TabIndex = 8;
            label3.Text = "Kucoin";
            // 
            // dataGridView_BitGet
            // 
            dataGridView_BitGet.AllowUserToAddRows = false;
            dataGridView_BitGet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_BitGet.Location = new Point(1056, 57);
            dataGridView_BitGet.Name = "dataGridView_BitGet";
            dataGridView_BitGet.Size = new Size(325, 500);
            dataGridView_BitGet.TabIndex = 9;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(1219, 37);
            label4.Name = "label4";
            label4.Size = new Size(41, 17);
            label4.TabIndex = 10;
            label4.Text = "BitGet";
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(6, 3);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(131, 23);
            comboBox.TabIndex = 11;
            comboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 601);
            Controls.Add(comboBox);
            Controls.Add(label4);
            Controls.Add(dataGridView_BitGet);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView_BitGet).EndInit();
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
        private DataGridView dataGridView_BitGet;
        private Label label4;
        private ComboBox comboBox;
    }
}
