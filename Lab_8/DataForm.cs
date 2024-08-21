using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (PostgresModule.getConnectionStatus() == true)
                {
                    connectionStatusIndicator.BackColor = Color.Green;
                }
                else
                {
                    connectionStatusIndicator.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PostgresModule.setGridView(this, comboBox1, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (PostgresModule.getConnectionStatus() == true)
            {
                connectionStatusIndicator.BackColor = Color.Green;
            }
            else
            {
                connectionStatusIndicator.BackColor = Color.Red;
            }
        }
    }
}
