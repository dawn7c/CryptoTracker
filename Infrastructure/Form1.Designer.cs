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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button_GetData
            // 
            button_GetData.Location = new Point(255, 415);
            button_GetData.Name = "button_GetData";
            button_GetData.Size = new Size(271, 23);
            button_GetData.TabIndex = 0;
            button_GetData.Text = "Получить данные";
            button_GetData.UseVisualStyleBackColor = true;
            button_GetData.Click += button_GetData_Click;
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(713, 415);
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
            dataGridView1.Location = new Point(12, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(776, 253);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button_Exit);
            Controls.Add(button_GetData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button_GetData;
        private Button button_Exit;
        private DataGridView dataGridView1;
    }
}
