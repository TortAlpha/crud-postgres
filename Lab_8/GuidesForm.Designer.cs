namespace Lab_8
{
    partial class GuidesForm
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
            connectionStatusIndicator = new Panel();
            label6 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(896, 331);
            dataGridView1.TabIndex = 0;
            // 
            // connectionStatusIndicator
            // 
            connectionStatusIndicator.BackColor = Color.Red;
            connectionStatusIndicator.Location = new Point(265, 404);
            connectionStatusIndicator.Name = "connectionStatusIndicator";
            connectionStatusIndicator.Size = new Size(38, 37);
            connectionStatusIndicator.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 404);
            label6.Name = "label6";
            label6.Size = new Size(244, 32);
            label6.TabIndex = 14;
            label6.Text = "Статус подключения";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "auto_models", "cars", "cities", "countries", "clients", "employee_positions", "employees", "statuses" });
            comboBox1.Location = new Point(357, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 16;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(335, 32);
            label1.TabIndex = 17;
            label1.Text = "Таблица справочных данных";
            // 
            // GuidesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 450);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(connectionStatusIndicator);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Name = "GuidesForm";
            Text = "Справочники";
            Load += GuidesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel connectionStatusIndicator;
        private Label label6;
        private ComboBox comboBox1;
        private Label label1;
    }
}