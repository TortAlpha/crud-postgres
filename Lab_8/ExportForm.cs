using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab_8
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void exportHTMLRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (exportHTMLRadioButton.Checked)
                exportXMLRadioButton.Checked = false;
        }

        private void exportXMLRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (exportXMLRadioButton.Checked)
                exportHTMLRadioButton.Checked = false;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportHTMLRadioButton.Checked)
                {
                    saveFileDialog1.DefaultExt = "html";
                    saveFileDialog1.Filter = "Hyper text|*.html";
                    saveFileDialog1.Title = "Export HTML";
                    ExportToHTML(comboBox1.Text);
                }
                if (exportXMLRadioButton.Checked)
                {
                    saveFileDialog1.DefaultExt = "xls";
                    saveFileDialog1.Filter = "Excel|*.xls";
                    saveFileDialog1.Title = "Export Excel";
                    ExportToExcel(comboBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ExportToExcel(string name)
        {
            List<List<string>> table = PostgresModule.Select_all(name); saveFileDialog1.FileName = name;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream Stream1 = new FileStream(saveFileDialog1.FileName, FileMode.Create); try
                {
                    StreamWriter StreamWriterStream1 = new StreamWriter(Stream1, Encoding.Unicode);
                    foreach (string Column in table[0]) StreamWriterStream1.Write(Column + "\t");
                    StreamWriterStream1.WriteLine(); bool skip1 = true;
                    foreach (List<string> Row in table)
                    {
                        if (skip1) skip1 = false;
                        else
                        {
                            foreach (object Entity in Row)
                            {
                                StreamWriterStream1.Write(Entity.ToString() + "\t");
                            }
                            StreamWriterStream1.WriteLine();
                        }
                    }
                    StreamWriterStream1.Flush();
                }
                catch
                {
                    MessageBox.Show("При передаче данных возникла ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Stream1.Close();
                Process.Start(Stream1.Name);
            }
        }

        void ExportToHTML(string name)
        {
            List<List<string>> table = PostgresModule.Select_all(name); saveFileDialog1.FileName = name;
            int i, j;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream Stream1 = new FileStream(saveFileDialog1.FileName, FileMode.Create); try
                {
                    StreamWriter StreamWriter1 = new StreamWriter(Stream1);
                    StreamWriter1.WriteLine("<html>");
                    StreamWriter1.WriteLine("<head>");
                    StreamWriter1.WriteLine("<meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\">");
                    StreamWriter1.WriteLine("<title>" + name + "</title>"); StreamWriter1.WriteLine("</head>");
                    StreamWriter1.WriteLine("<body bgcolor=\"800000\">"); StreamWriter1.WriteLine("<table align=\"center\" cols =0 cellspacing =0>"); StreamWriter1.WriteLine("<tr>");
                    StreamWriter1.WriteLine("</td>");
                    StreamWriter1.WriteLine("</tr>");
                    StreamWriter1.WriteLine("<tr>");
                    for (j = 0; j < table[0].Count; j++)
                    {
                        StreamWriter1.WriteLine("<td><font face=\"Verdana\"size=\"2\" color=\"#ffffff\"><p align=\"center\"><b>");
                        StreamWriter1.WriteLine("" + table[0][j]);
                        StreamWriter1.WriteLine("</b></font></td>");
                    }
                    StreamWriter1.WriteLine("</tr>"); for (i = 1; i < table.Count; i++)
                    {
                        if ((i % 2 - 1) == 0)
                        {
                            StreamWriter1.WriteLine("<tr bgcolor=\"3399\">"); for (j = 0; j < table[i].Count; j++)
                            {
                                StreamWriter1.WriteLine("<td><font face=\"Verdana\"size=\"2\" color=\"#000000\"><p align=\"center\">");
                                StreamWriter1.WriteLine("" + table[i][j]);
                                StreamWriter1.WriteLine("</font></td>");
                            }
                            StreamWriter1.WriteLine("</tr>");
                        }
                        else
                        {
                            StreamWriter1.WriteLine("<tr>"); for (j = 0; j < table[i].Count; j++)
                            {
                                StreamWriter1.WriteLine("<td><font face=\"Verdana\"size=\"2\" color=\"#ffffff\"><p align=\"center\">");
                                StreamWriter1.WriteLine("" + table[i][j]);
                                StreamWriter1.WriteLine("</font></td>");
                            }
                            StreamWriter1.WriteLine("</tr>");
                        }
                    }
                    StreamWriter1.WriteLine("</table></center></body></html>"); StreamWriter1.Flush();
                }
                catch
                {
                    MessageBox.Show("При передаче данных возникла ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Stream1.Close();
                Process.Start(Stream1.Name);
            }
        }
    }
}
