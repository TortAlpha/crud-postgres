namespace Lab_8
{
    partial class CreditsForm
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
            label1 = new Label();
            connectionStatusIndicator = new Panel();
            label6 = new Label();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(201, 32);
            label1.TabIndex = 23;
            label1.Text = "Таблица отчетов";
            // 
            // connectionStatusIndicator
            // 
            connectionStatusIndicator.BackColor = Color.Red;
            connectionStatusIndicator.Location = new Point(265, 401);
            connectionStatusIndicator.Name = "connectionStatusIndicator";
            connectionStatusIndicator.Size = new Size(38, 37);
            connectionStatusIndicator.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 401);
            label6.Name = "label6";
            label6.Size = new Size(244, 32);
            label6.TabIndex = 21;
            label6.Text = "Статус подключения";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "\"Acts_of_performed_work\"" });
            comboBox1.Location = new Point(222, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 20;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(873, 315);
            dataGridView1.TabIndex = 19;
            // 
            // CreditsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 450);
            Controls.Add(label1);
            Controls.Add(connectionStatusIndicator);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "CreditsForm";
            Text = "CreditsForm";
            Load += CreditsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel connectionStatusIndicator;
        private Label label6;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
    }
}