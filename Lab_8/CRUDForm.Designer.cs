namespace Lab_8
{
    partial class CRUDForm
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
            label1 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            CreateUpdateButton = new Button();
            DeleteButton = new Button();
            prev_page_button = new Button();
            next_page_button = new Button();
            page_num_label = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 368);
            dataGridView1.TabIndex = 0;
            dataGridView1.KeyUp += dataGridView1_KeyUp;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Страны", "Города", "Должности", "Статусы", "МоделиАвто", "Сотрудники", "Клиенты", "Автомобили", "СпискиОтгрузки", "АктыВыполненныхРабот", "Грузы", "Заказы" });
            comboBox1.Location = new Point(91, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 2;
            label1.Text = "Таблицы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(314, 12);
            label2.Name = "label2";
            label2.Size = new Size(207, 21);
            label2.TabIndex = 3;
            label2.Text = "Представления (Read-Only)";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "\"Отчеты о выполненных заказах\"" });
            comboBox2.Location = new Point(527, 12);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(211, 23);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // CreateUpdateButton
            // 
            CreateUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CreateUpdateButton.Location = new Point(91, 41);
            CreateUpdateButton.Name = "CreateUpdateButton";
            CreateUpdateButton.Size = new Size(112, 23);
            CreateUpdateButton.TabIndex = 5;
            CreateUpdateButton.Text = "Create/Update";
            CreateUpdateButton.UseVisualStyleBackColor = true;
            CreateUpdateButton.Click += CreateUpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteButton.Location = new Point(209, 41);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(93, 23);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // prev_page_button
            // 
            prev_page_button.Location = new Point(12, 452);
            prev_page_button.Name = "prev_page_button";
            prev_page_button.Size = new Size(75, 23);
            prev_page_button.TabIndex = 7;
            prev_page_button.Text = "<<";
            prev_page_button.UseVisualStyleBackColor = true;
            prev_page_button.Click += prev_page_button_Click;
            // 
            // next_page_button
            // 
            next_page_button.Location = new Point(159, 452);
            next_page_button.Name = "next_page_button";
            next_page_button.Size = new Size(75, 23);
            next_page_button.TabIndex = 8;
            next_page_button.Text = ">>";
            next_page_button.UseVisualStyleBackColor = true;
            next_page_button.Click += next_page_button_Click;
            // 
            // page_num_label
            // 
            page_num_label.AutoSize = true;
            page_num_label.Location = new Point(113, 456);
            page_num_label.Name = "page_num_label";
            page_num_label.Size = new Size(13, 15);
            page_num_label.TabIndex = 9;
            page_num_label.Text = "0";
            // 
            // CRUDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 487);
            Controls.Add(page_num_label);
            Controls.Add(next_page_button);
            Controls.Add(prev_page_button);
            Controls.Add(DeleteButton);
            Controls.Add(CreateUpdateButton);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "CRUDForm";
            Text = "CRUDForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox2;
        private Button CreateUpdateButton;
        private Button DeleteButton;
        private Button prev_page_button;
        private Button next_page_button;
        private Label page_num_label;
    }
}