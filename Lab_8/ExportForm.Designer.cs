namespace Lab_8
{
    partial class ExportForm
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
            exportHTMLRadioButton = new RadioButton();
            exportXMLRadioButton = new RadioButton();
            cancelButton = new Button();
            exportButton = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // exportHTMLRadioButton
            // 
            exportHTMLRadioButton.AutoSize = true;
            exportHTMLRadioButton.Location = new Point(106, 222);
            exportHTMLRadioButton.Name = "exportHTMLRadioButton";
            exportHTMLRadioButton.Size = new Size(247, 41);
            exportHTMLRadioButton.TabIndex = 0;
            exportHTMLRadioButton.TabStop = true;
            exportHTMLRadioButton.Text = "Экспорт в HTML";
            exportHTMLRadioButton.UseVisualStyleBackColor = true;
            exportHTMLRadioButton.CheckedChanged += exportHTMLRadioButton_CheckedChanged;
            // 
            // exportXMLRadioButton
            // 
            exportXMLRadioButton.AutoSize = true;
            exportXMLRadioButton.Location = new Point(106, 352);
            exportXMLRadioButton.Name = "exportXMLRadioButton";
            exportXMLRadioButton.Size = new Size(236, 41);
            exportXMLRadioButton.TabIndex = 1;
            exportXMLRadioButton.TabStop = true;
            exportXMLRadioButton.Text = "Экспорт в Excel";
            exportXMLRadioButton.UseVisualStyleBackColor = true;
            exportXMLRadioButton.CheckedChanged += exportXMLRadioButton_CheckedChanged;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(633, 541);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(169, 52);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отменить";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // exportButton
            // 
            exportButton.Location = new Point(188, 541);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(169, 52);
            exportButton.TabIndex = 3;
            exportButton.Text = "Экспорт";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "\"Отчеты о выполненных заказах\"" });
            comboBox1.Location = new Point(601, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(272, 45);
            comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(684, 102);
            label1.Name = "label1";
            label1.Size = new Size(107, 37);
            label1.TabIndex = 5;
            label1.Text = "Отчеты";
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 659);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(exportButton);
            Controls.Add(cancelButton);
            Controls.Add(exportXMLRadioButton);
            Controls.Add(exportHTMLRadioButton);
            Name = "ExportForm";
            Text = "ExportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton exportHTMLRadioButton;
        private RadioButton exportXMLRadioButton;
        private Button cancelButton;
        private Button exportButton;
        private ComboBox comboBox1;
        private Label label1;
        private SaveFileDialog saveFileDialog1;
    }
}