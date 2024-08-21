namespace Lab_8
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            connectionStatusIndicator = new Panel();
            label6 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(873, 323);
            dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "acts_of_work_performed", "orders", "shipment_lists", "shipment_units" });
            comboBox1.Location = new Point(365, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 1;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // connectionStatusIndicator
            // 
            connectionStatusIndicator.BackColor = Color.Red;
            connectionStatusIndicator.Location = new Point(276, 409);
            connectionStatusIndicator.Name = "connectionStatusIndicator";
            connectionStatusIndicator.Size = new Size(38, 37);
            connectionStatusIndicator.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 409);
            label6.Name = "label6";
            label6.Size = new Size(244, 32);
            label6.TabIndex = 16;
            label6.Text = "Статус подключения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(347, 32);
            label1.TabIndex = 18;
            label1.Text = "Таблица оперативных данных";
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 462);
            Controls.Add(label1);
            Controls.Add(connectionStatusIndicator);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "DataForm";
            Text = "Оперативные данные";
            Load += DataForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Panel connectionStatusIndicator;
        private Label label6;
        private Label label1;
    }
}