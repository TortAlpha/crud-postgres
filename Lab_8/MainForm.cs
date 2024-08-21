namespace Lab_8
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void postgresConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                string host = hostTextBox.Text;
                string port = portTextBox.Text;
                string user = userTextBox.Text;
                string pass = passTextBox.Text;
                string dbName = dbNameTextBox.Text;

                PostgresModule.OpenConnection(host, port, user, pass, dbName);

                if (PostgresModule.getConnectionStatus() == true)
                {
                    connectionStatusIndicator.BackColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guidesStripMenuButton_Click(object sender, EventArgs e)
        {
            try
            {
                CRUDForm crudForm = new CRUDForm();
                crudForm.setFullAccessMode();
                crudForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataStripMenuData_Click(object sender, EventArgs e)
        {
            try
            {
                CRUDForm crudForm = new CRUDForm();
                crudForm.setFullAccessMode();
                crudForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creditsStipMenuButton_Click(object sender, EventArgs e)
        {
            try
            {
                CRUDForm crudForm = new CRUDForm();
                crudForm.setReadMode();
                crudForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutStripMenuButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void closeStripMenuButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportStripMenuButton_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm();
            exportForm.ShowDialog();
        }
    }
}
