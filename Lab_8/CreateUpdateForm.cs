using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace Lab_8
{
    public partial class CreateUpdateForm : Form
    {
        List<ViewInfo> viewInfos = new List<ViewInfo>();

        DataTable dataTable1 = new DataTable();
        string SourceView = "";
        bool update = false;
        Dictionary<string, object> arguments = new Dictionary<string, object>();

        public CreateUpdateForm(DataTable dataTable, string TableName, object? selected_id, List<ViewInfo> viewInfos)
        {

            InitializeComponent();
           

            SourceView = TableName;
            this.viewInfos = viewInfos;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns.Clear();
            
            dataGridView1.AllowUserToAddRows = true;

            string condition = " LIMIT 0";
            if (selected_id != null)
            {
                update = true;
                condition = $" WHERE ( {dataTable.Columns[0].ColumnName} = {selected_id} )";
            }
            PostgresModule.setGridView(PostgresModule.getDataTable(SourceView, condition), dataGridView1);

            
            dataGridView1.Rows[0].Cells[0].ReadOnly = true;
            
        }

        private void AdjustFormSizeToGrid()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.MinimumWidth = 100;
            }
            int width = dataGridView1.PreferredSize.Width;
            int height = dataGridView1.PreferredSize.Height;


            this.MinimumSize = new Size(Math.Max(width, this.MinimumSize.Width), Math.Max(height, 200));


            this.Size = this.MinimumSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //отменить
            Close();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //сохранить

            try
            { 
                ViewInfo viewInfo = viewInfos.Find(view => view.ViewName == SourceView);

                if (update)
                {
                    PostgresModule.UpdateRows(dataGridView1, viewInfo, arguments);
                }
                else
                {
                    if (viewInfo.MainTableName == "cars")
                    {
                        PostgresModule.InsertRowsWithID(dataGridView1, viewInfo, arguments);
                    }
                    else
                    {
                        PostgresModule.InsertRows(dataGridView1, viewInfo, arguments);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nОшибка записи");
            }
           

            Close();
            Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name[0] == '_')
                {
                    ChooseForm chooseForm = new ChooseForm(dataGridView1.Columns[e.ColumnIndex].Name, e);
                    chooseForm.OnRowSelected += ChooseForm_OnRowSelected;
                    chooseForm.ShowDialog();
                }
            }
        }

        private void ChooseForm_OnRowSelected(object chosen_field_id, string src_field,  object ret_field_val, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ret_field_val;
            arguments.Add(src_field, chosen_field_id);
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
        }

    }
}
