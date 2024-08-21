using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class CRUDForm : Form
    {

        List<ViewInfo> viewInfos = new List<ViewInfo>();

        private int currentPage = 1;
        private int totalRows = 0;
        private int rowsPerPage = 10;

        public CRUDForm()
        {
            InitializeComponent();
            setFullAccessMode();

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            viewInfos.Add(new ViewInfo("cars", "Автомобили"));
            viewInfos.Add(new ViewInfo("acts_of_work_performed", "АктыВыполненныхРабот"));
            viewInfos.Add(new ViewInfo("auto_models", "МоделиАвто"));
            viewInfos.Add(new ViewInfo("cities", "Города"));
            viewInfos.Add(new ViewInfo("clients", "Клиенты"));
            viewInfos.Add(new ViewInfo("countries", "Страны"));
            viewInfos.Add(new ViewInfo("employee_positions", "Должности"));
            viewInfos.Add(new ViewInfo("employees", "Сотрудники"));
            viewInfos.Add(new ViewInfo("orders", "Заказы"));
            viewInfos.Add(new ViewInfo("shipment_lists", "СпискиОтгрузки"));
            viewInfos.Add(new ViewInfo("shipment_units", "Грузы"));
            viewInfos.Add(new ViewInfo("statuses", "Статусы"));
        }

        public void setFullAccessMode()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }

        public void setReadMode()
        {
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            CreateUpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            this.Text += " (Read-Only Mode)";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostgresModule.setGridViewREAD(PostgresModule.getDataTable(comboBox1.Text), dataGridView1);
            comboBox2.Text = "";
            currentPage = 1;
            LoadPage();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostgresModule.setGridViewREAD(PostgresModule.getDataTable(comboBox2.Text), dataGridView1);
            CreateUpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            comboBox1.Text = "";
            currentPage = 1; 
            LoadPage();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CreateUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                object selected_id = dataGridView1.SelectedRows[0].Cells[0].Value;
                CreateUpdateForm createUpdateForm = new CreateUpdateForm(PostgresModule.getDataTable(comboBox1.Text), comboBox1.Text, selected_id, viewInfos);
                createUpdateForm.ShowDialog();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                CreateUpdateForm createUpdateForm = new CreateUpdateForm(PostgresModule.getDataTable(comboBox1.Text), comboBox1.Text, null, viewInfos);
                createUpdateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.GetType().ToString());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewInfo viewInfo = viewInfos.Find(view => view.ViewName == comboBox1.Text);

                PostgresModule.DeleteRows(dataGridView1, viewInfo.MainTableName);
                PostgresModule.setGridView(PostgresModule.getDataTable(comboBox1.Text), dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPage()
        {
            try
            {
                int startIndex = (currentPage - 1) * rowsPerPage;
                var dataTable = PostgresModule.getDataTable(comboBox1.Text);
                totalRows = dataTable.Rows.Count;
                var pageTable = dataTable.AsEnumerable()
                                         .Skip(startIndex)
                                         .Take(rowsPerPage)
                                         .CopyToDataTable();

                dataGridView1.DataSource = pageTable;
                UpdatePaginationButtons();
                
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                AdjustFormSizeToGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AdjustFormSizeToGrid()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.MinimumWidth = 100;
            }
            int width = dataGridView1.PreferredSize.Width;
            int height = dataGridView1.PreferredSize.Height;

            
            this.MinimumSize = new Size(Math.Max(width, this.MinimumSize.Width), Math.Max(height, this.MinimumSize.Height));

 
            this.Size = this.MinimumSize;
        }


        private void UpdatePaginationButtons()
        {
            prev_page_button.Enabled = currentPage > 1;
            next_page_button.Enabled = (currentPage * rowsPerPage) < totalRows;
        }

        private void next_page_button_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage();
        }

        private void prev_page_button_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }

    }
}
