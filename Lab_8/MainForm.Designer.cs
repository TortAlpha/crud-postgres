namespace Lab_8
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            postgresConnectionButton = new Button();
            hostTextBox = new TextBox();
            portTextBox = new TextBox();
            label2 = new Label();
            userTextBox = new TextBox();
            label3 = new Label();
            passTextBox = new TextBox();
            label4 = new Label();
            dbNameTextBox = new TextBox();
            label5 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            guidesStripMenuButton = new ToolStripMenuItem();
            dataStripMenuData = new ToolStripMenuItem();
            creditsStipMenuButton = new ToolStripMenuItem();
            aboutStripMenuButton = new ToolStripMenuItem();
            closeStripMenuButton = new ToolStripMenuItem();
            label6 = new Label();
            connectionStatusIndicator = new Panel();
            exportStripMenuButton = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 136);
            label1.Name = "label1";
            label1.Size = new Size(83, 45);
            label1.TabIndex = 0;
            label1.Text = "host";
            // 
            // postgresConnectionButton
            // 
            postgresConnectionButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            postgresConnectionButton.Location = new Point(76, 493);
            postgresConnectionButton.Name = "postgresConnectionButton";
            postgresConnectionButton.Size = new Size(265, 66);
            postgresConnectionButton.TabIndex = 1;
            postgresConnectionButton.Text = "Подключиться";
            postgresConnectionButton.UseVisualStyleBackColor = true;
            postgresConnectionButton.Click += postgresConnectionButton_Click;
            // 
            // hostTextBox
            // 
            hostTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            hostTextBox.Location = new Point(142, 133);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(230, 51);
            hostTextBox.TabIndex = 2;
            hostTextBox.Text = "localhost";
            hostTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // portTextBox
            // 
            portTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            portTextBox.Location = new Point(142, 200);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(230, 51);
            portTextBox.TabIndex = 4;
            portTextBox.Text = "5432";
            portTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 204);
            label2.Name = "label2";
            label2.Size = new Size(80, 45);
            label2.TabIndex = 3;
            label2.Text = "port";
            // 
            // userTextBox
            // 
            userTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            userTextBox.Location = new Point(142, 269);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(230, 51);
            userTextBox.TabIndex = 6;
            userTextBox.Text = "postgres";
            userTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(45, 273);
            label3.Name = "label3";
            label3.Size = new Size(81, 45);
            label3.TabIndex = 5;
            label3.Text = "user";
            // 
            // passTextBox
            // 
            passTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            passTextBox.Location = new Point(142, 341);
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '*';
            passTextBox.Size = new Size(230, 51);
            passTextBox.TabIndex = 8;
            passTextBox.Text = "1qa2ws3ed";
            passTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(45, 345);
            label4.Name = "label4";
            label4.Size = new Size(84, 45);
            label4.TabIndex = 7;
            label4.Text = "pass";
            // 
            // dbNameTextBox
            // 
            dbNameTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dbNameTextBox.Location = new Point(142, 417);
            dbNameTextBox.Name = "dbNameTextBox";
            dbNameTextBox.Size = new Size(230, 51);
            dbNameTextBox.TabIndex = 10;
            dbNameTextBox.Text = "Shipments";
            dbNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(54, 423);
            label5.Name = "label5";
            label5.Size = new Size(58, 45);
            label5.TabIndex = 9;
            label5.Text = "db";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { guidesStripMenuButton, dataStripMenuData, creditsStipMenuButton, aboutStripMenuButton, exportStripMenuButton, closeStripMenuButton });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(994, 47);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // guidesStripMenuButton
            // 
            guidesStripMenuButton.Name = "guidesStripMenuButton";
            guidesStripMenuButton.Size = new Size(208, 43);
            guidesStripMenuButton.Text = "Справочники";
            guidesStripMenuButton.Click += guidesStripMenuButton_Click;
            // 
            // dataStripMenuData
            // 
            dataStripMenuData.Name = "dataStripMenuData";
            dataStripMenuData.Size = new Size(137, 43);
            dataStripMenuData.Text = "Данные";
            dataStripMenuData.Click += dataStripMenuData_Click;
            // 
            // creditsStipMenuButton
            // 
            creditsStipMenuButton.Name = "creditsStipMenuButton";
            creditsStipMenuButton.Size = new Size(129, 43);
            creditsStipMenuButton.Text = "Отчеты";
            creditsStipMenuButton.Click += creditsStipMenuButton_Click;
            // 
            // aboutStripMenuButton
            // 
            aboutStripMenuButton.Name = "aboutStripMenuButton";
            aboutStripMenuButton.Size = new Size(206, 43);
            aboutStripMenuButton.Text = "О программе";
            aboutStripMenuButton.Click += aboutStripMenuButton_Click;
            // 
            // closeStripMenuButton
            // 
            closeStripMenuButton.Name = "closeStripMenuButton";
            closeStripMenuButton.Size = new Size(116, 43);
            closeStripMenuButton.Text = "Выход";
            closeStripMenuButton.Click += closeStripMenuButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 68);
            label6.Name = "label6";
            label6.Size = new Size(273, 37);
            label6.TabIndex = 12;
            label6.Text = "Статус подключения";
            // 
            // connectionStatusIndicator
            // 
            connectionStatusIndicator.BackColor = Color.Red;
            connectionStatusIndicator.Location = new Point(308, 68);
            connectionStatusIndicator.Name = "connectionStatusIndicator";
            connectionStatusIndicator.Size = new Size(44, 43);
            connectionStatusIndicator.TabIndex = 13;
            // 
            // exportStripMenuButton
            // 
            exportStripMenuButton.Name = "exportStripMenuButton";
            exportStripMenuButton.Size = new Size(140, 43);
            exportStripMenuButton.Text = "Экспорт";
            exportStripMenuButton.Click += exportStripMenuButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 619);
            Controls.Add(connectionStatusIndicator);
            Controls.Add(label6);
            Controls.Add(menuStrip1);
            Controls.Add(dbNameTextBox);
            Controls.Add(label5);
            Controls.Add(passTextBox);
            Controls.Add(label4);
            Controls.Add(userTextBox);
            Controls.Add(label3);
            Controls.Add(portTextBox);
            Controls.Add(label2);
            Controls.Add(hostTextBox);
            Controls.Add(postgresConnectionButton);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Главное окно";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button postgresConnectionButton;
        private TextBox hostTextBox;
        private TextBox portTextBox;
        private Label label2;
        private TextBox userTextBox;
        private Label label3;
        private TextBox passTextBox;
        private Label label4;
        private TextBox dbNameTextBox;
        private Label label5;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem guidesStripMenuButton;
        private ToolStripMenuItem dataStripMenuData;
        private ToolStripMenuItem creditsStipMenuButton;
        private ToolStripMenuItem aboutStripMenuButton;
        private ToolStripMenuItem closeStripMenuButton;
        private Label label6;
        private Panel connectionStatusIndicator;
        private ToolStripMenuItem exportStripMenuButton;
    }
}
