using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_8
{
    public partial class ChooseForm : Form
    {
        public delegate void SelectedRowHandler(object chosen_field, string src_field, object ret_field_val, DataGridViewCellEventArgs e);
        public event SelectedRowHandler OnRowSelected;
        public DataGridViewCellEventArgs src_e;
        private string src_field;

        public ChooseForm(string field_name, DataGridViewCellEventArgs src_e)
        {
            InitializeComponent();
            this.src_e = src_e;
            src_field = field_name;

            PostgresModule.setGridViewREAD(PostgresModule.getDataTable(PostgresModule.getViewByField(field_name)), dataGridView1);
            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    object chosen_field_id = row.Cells[0].Value;

                    string ret_field = PostgresModule.getRetFieldBySrcField(src_field);


                    string sql_com = $"SELECT {ret_field} FROM {PostgresModule.getViewByField(src_field)}" +
                        $" WHERE ({PostgresModule.getDataTable(PostgresModule.getViewByField(src_field)).Columns[0].ColumnName} = {chosen_field_id})";
                    
                    if (src_field == "_ГосНомерАвтомобиля")
                    {
                        sql_com = $"SELECT {ret_field} FROM {PostgresModule.getViewByField(src_field)}" +
                        $" WHERE (\"{PostgresModule.getDataTable(PostgresModule.getViewByField(src_field)).Columns[0].ColumnName}\" = '{chosen_field_id}')";
                    }

                    DataTable valueDt = PostgresModule.getSqlComResult(sql_com);

                    object ret_field_val = valueDt.Rows[0][0];
                    if (ret_field.Contains(','))
                    {
                        object[] array = valueDt.Rows[0][0] as object[];
                        ret_field_val = string.Join(" ", array.Select(x => x.ToString()));
                    }
                    
                    OnRowSelected?.Invoke(chosen_field_id, src_field, ret_field_val, src_e);
                    Close();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
