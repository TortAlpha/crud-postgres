namespace Lab_8
{
    partial class AboutForm
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
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(770, 146);
            label1.TabIndex = 0;
            label1.Text = "Программа разработана для просмотра содержимого базы данных, используемое СУБД - PostgreSQL. Студент-разрабочик Аванесов Роман группа 26/1.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(343, 217);
            label3.Name = "label3";
            label3.Size = new Size(81, 32);
            label3.TabIndex = 2;
            label3.Text = "КУБГУ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 185);
            label4.Name = "label4";
            label4.Size = new Size(285, 32);
            label4.TabIndex = 3;
            label4.Text = "@ Аванесов Роман 2024";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 269);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "AboutForm";
            Text = "О программе";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
    }
}