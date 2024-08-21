using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_8
{
    class PostgresModule
    {
        public static NpgsqlConnection _connection = null;

        public static void OpenConnection(string host, string port, string user, string pass, string db)
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open) _connection.Close();
                _connection.Dispose();
            }
            _connection = new NpgsqlConnection(@"Server=" + host + ";Port=" + port + ";User Id=" + user + ";Password=" + pass + ";DataBase=" + db);
            _connection.Open();
            if (_connection.State == System.Data.ConnectionState.Open) MessageBox.Show("Connected!");
            else MessageBox.Show("Not connected!");


        }

        public static bool getConnectionStatus()
        {
            try
            {
                if (_connection != null)
                {
                    return _connection.State == System.Data.ConnectionState.Open;
                }
                throw new Exception("No connection!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static DataTable? getSqlComResult(string sql_com)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = sql_com;

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return dataTable;
        }

        public static DataTable? getDataTable(string tableName)
        {
            try
            {
                string sql_com = "SELECT * FROM public." + tableName;
                return getSqlComResult(sql_com);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
                return null;
            }
        }

        public static DataTable? getDataTable(string tableName, string condtition)
        {
            try
            {
                string sql_com = "SELECT * FROM public." + tableName + condtition;
                return getSqlComResult(sql_com);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
                return null;
            }
        }

        public static void DeleteRows(DataGridView dataGridView, string table)
        {
            try
            {
                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    
                    // SQL шаблон для удаления
                    DataTable dt = getDataTable(table, " LIMIT 0");

                    string sqlTemplate = $"DELETE FROM {table} WHERE {dt.Columns[0].ColumnName} = @Id";

                    command.CommandText = sqlTemplate;
                    NpgsqlParameter idParam = new NpgsqlParameter("@Id", DbType.Object); // Используем DbType.Object для общности
                    command.Parameters.Add(idParam);

                    // Удаление каждой выбранной строки
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        object id = row.Cells[0].Value;
                        idParam.Value = id ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Выбранные записи успешно удалены.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления записей: " + ex.Message);
            }
        }

        public static void InsertRowsWithID(DataGridView dataGridView, ViewInfo viewInfo, Dictionary<string, object> arguments)
        {
            try
            {
                DataTable Table_template = getDataTable(viewInfo.MainTableName, " LIMIT 0");
                string sql_com = $"INSERT INTO {viewInfo.MainTableName} (";
                string valuesClause = "VALUES (";

                List<string> columnNames = new List<string>();

                foreach (DataColumn el in Table_template.Columns)
                {
                    sql_com += (sql_com.EndsWith("(") ? "" : ", ") + el.ColumnName;
                    valuesClause += (valuesClause.EndsWith("(") ? "" : ", ") + "@" + el.ColumnName;
                    columnNames.Add(el.ColumnName);
                }
                sql_com += ") " + valuesClause + ")";
                MessageBox.Show(sql_com);
                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = sql_com;

                    var resultDict = new Dictionary<string, object>();
                    foreach (var kvp in arguments)
                    {
                        string key = kvp.Key;
                        object value1 = kvp.Value;

                        if (arguments.ContainsKey(key))
                        {
                            string value2 = viewInfo.TableViewCorrelationInfo[key];
                            resultDict[value2] = value1;
                        }
                    }

                    for (int i = 0; i < columnNames.Count; ++i)
                    {
                        if (resultDict.Keys.Contains(columnNames[i]))
                        {
                            object value = resultDict[columnNames[i]];
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }
                        else
                        {
                            var value = dataGridView.Rows[0].Cells[i].Value;
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }

                    }
                    
                    int res = command.ExecuteNonQuery();
                    if (res > -1) MessageBox.Show("Запись успешно добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления записи: " + ex.Message);
            }
        }

        public static void InsertRows(DataGridView dataGridView, ViewInfo viewInfo, Dictionary<string, object> arguments)
        {
            try
            {
                DataTable Table_template = getDataTable(viewInfo.MainTableName, " LIMIT 0");
                string sql_com = $"INSERT INTO {viewInfo.MainTableName} (";
                string valuesClause = "VALUES (";

                bool first = true;
                List<string> columnNames = new List<string>();

                foreach (DataColumn el in Table_template.Columns)
                {
                    if (first)
                    {
                        first = false; // Пропускаем первый столбец, так как предполагается, что он serial типа
                        continue;
                    }
                    sql_com += (sql_com.EndsWith("(") ? "" : ", ") + el.ColumnName;
                    valuesClause += (valuesClause.EndsWith("(") ? "" : ", ") + "@" + el.ColumnName;
                    columnNames.Add(el.ColumnName); 
                }
                sql_com += ") " + valuesClause + ")";

                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = sql_com;

                    var resultDict = new Dictionary<string, object>();
                    
                    foreach (var kvp in arguments)
                    {
                        string key = kvp.Key;          
                        object value1 = kvp.Value;     

                        if (arguments.ContainsKey(key))  
                        {
                            string value2 = viewInfo.TableViewCorrelationInfo[key];  
                            resultDict[value2] = value1;
                        }
                    }


                    for (int i = 0; i < columnNames.Count; ++i)
                    {
                        if (resultDict.Keys.Contains(columnNames[i]))
                        {
                            object value = resultDict[columnNames[i]];
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }
                        else
                        {
                            var value = dataGridView.Rows[0].Cells[i + 1].Value;
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }
                        
                    }
                    
                    int res = command.ExecuteNonQuery();
                    if (res > -1) MessageBox.Show("Запись успешно добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления записи: " + ex.Message);
            }
        }

        public static TKey FindKeyByValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value)
        {
            foreach (var pair in dictionary)
            {
                if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                    return pair.Key;
            }
            return default(TKey);
        }

        public static void UpdateRows(DataGridView dataGridView, ViewInfo viewInfo, Dictionary<string, object> arguments)
        {
            try
            {
                DataTable Table_template = getDataTable(viewInfo.MainTableName, " LIMIT 0");
                string sql_com = $"UPDATE {viewInfo.MainTableName} SET ";
                List<string> columnNames = new List<string>();

                // Собираем имена столбцов для SQL запроса
                foreach (DataColumn el in Table_template.Columns)
                {
                    columnNames.Add(el.ColumnName);
                }
         
                string keyColumn = columnNames[0];
                

                bool first = true;
                for (int i = 1; i < columnNames.Count; i++)
                {
                    if (!first) sql_com += ", ";
                    sql_com += columnNames[i] + " = @" + columnNames[i];
                    first = false;
                }

                sql_com += " WHERE " + keyColumn + " = @" + keyColumn;


                string this_table_name = viewInfo.MainTableName;
                string sql_temp = $"SELECT * FROM {this_table_name} WHERE {viewInfo.TableViewCorrelationInfo[dataGridView.Columns[0].Name]} = {dataGridView.Rows[0].Cells[0].Value}";
                if (this_table_name == "cars")
                {
                    sql_temp = $"SELECT * FROM {this_table_name} WHERE \"{viewInfo.TableViewCorrelationInfo[dataGridView.Columns[0].Name]}\" = '{dataGridView.Rows[0].Cells[0].Value}'";
                }
                DataTable temp_dt = getSqlComResult(sql_temp);

                bool skip1 = true;
                foreach(DataColumn col in temp_dt.Columns)
                {
                    if (skip1) { skip1 = false; continue; }
                    
                    if (col.ColumnName.Contains("id"))
                    {
                        object currentValue;
                        string field_name = FindKeyByValue<string, string>(viewInfo.TableViewCorrelationInfo, col.ColumnName);
                        if (arguments.TryGetValue(field_name, out currentValue))
                        {
                            arguments[field_name] = currentValue;
                        }
                        else
                        {
                            arguments.Add(field_name, temp_dt.Rows[0][col]); 
                        }
                    }
                }

                string debug = "";

                foreach(var pair in arguments)
                {
                    debug += $"{pair.Key} : {pair.Value}\n";
                }
                MessageBox.Show(debug);

                var resultDict = new Dictionary<string, object>();

                foreach (var kvp in arguments)
                {
                    string key = kvp.Key;
                    object value1 = kvp.Value;

                    if (arguments.ContainsKey(key))
                    {
                        string value2 = viewInfo.TableViewCorrelationInfo[key];
                        resultDict[value2] = value1;
                    }
                }

                

                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = sql_com;

                    for (int i = 0; i < columnNames.Count; ++i) 
                    {
                    
                        if (resultDict.Keys.Contains(columnNames[i]))
                        {
                            object value = resultDict[columnNames[i]];
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }
                        else
                        {
                            var value = dataGridView.Rows[0].Cells[i].Value;
                            command.Parameters.AddWithValue("@" + columnNames[i], value ?? DBNull.Value);
                        }
                    }
                    int res = command.ExecuteNonQuery();
                    if (res > 0) MessageBox.Show("Запись успешно обновлена");
                    else MessageBox.Show("Обновление не выполнено. Проверьте данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления записи: " + ex.Message);
            }
        }

        public static void setGridView(DataTable dataTable, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Columns.Clear();

                if (dataTable == null)
                    throw new Exception("Ошибка чтения таблицы с данными.");

                foreach (DataColumn column in dataTable.Columns)
                {
                    column.ReadOnly = false;
                }
                
                dataGridView.DataSource = dataTable;

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
            }
        }

        public static void setGridViewREAD(DataTable dataTable, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Columns.Clear();

                if (dataTable == null)
                    throw new Exception("Ошибка чтения таблицы с данными.");

                dataGridView.DataSource = dataTable;

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex.Message);
            }
        }

        public static string getViewByField(string field)
        {
            switch (field) {
                case "_Страна":
                    return "Страны";
                case "_Город":
                    return "Города";
                case "_Должность":
                    return "Должности";
                case "_Статус":
                    return "Статусы";
                case "_Модель":
                    return "МоделиАвто";
                case "_ОтветсвенныйСотрудник":
                    return "Сотрудники";
                case "_ГосНомерАвтомобиля":
                    return "Автомобили";
                case "_ИдентификаторСпискаОтгрузки":
                    return "СпискиОтгрузки";
                case "_Клиент":
                    return "Клиенты";
                case "_ИдентификаторАкта":
                    return "АктыВыполненныхРабот";
                case "_ИдентификаторЕдиницыОтгрузки":
                    return "Грузы";
                default:
                    return "";
            }
        }

        public static string getRetFieldBySrcField(string field)
        {
            switch (field)
            {
                case "_Страна":
                    return " (Название) ";
                case "_Город":
                    return " (Название) ";
                case "_Модель":
                    return " (Название) ";
                case "_Должность":
                    return " (Название) ";
                case "_Статус":
                    return " (Описание) ";
                case "_ОтветсвенныйСотрудник":
                    return " (Имя, Фамилия) ";
                case "_Клиент":
                    return " (Имя, Фамилия) ";
                case "_ГосНомерАвтомобиля":
                    return " (РегистрационныйНомер) ";
                case "_ИдентификаторЕдиницыОтгрузки":
                    return " (ИдентификаторЕдиницыОтгрузки) ";
                case "_ИдентификаторСпискаОтгрузки":
                    return " (ИдентификаторСпискаОтгрузки) ";
                case "_ИдентификаторАкта":
                    return " (ИдентификаторАкта) ";
                default:
                    return "";
            }
        }

        public static List<List<string>> Select_all(string table_view)
        {
            List<List<string>> list = new List<List<string>>();
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = _connection.CreateCommand();
                    com.CommandText = "Select * from public." + table_view;
                    NpgsqlDataReader dt = com.ExecuteReader(CommandBehavior.Default);
                    bool add_names = false;
                    while (dt.Read())
                    {
                        try
                        {
                            if (!add_names)
                            {
                                List<string> list_names = new List<string>();
                                for (int i = 0; i < dt.FieldCount; i++)
                                {
                                    list_names.Add(dt.GetName(i));
                                }
                                list.Add(list_names);
                                add_names = true;
                            }
                            List<string> inside_list = new List<string>();
                            for (int i = 0; i < dt.FieldCount; i++)
                            {
                                inside_list.Add(dt.GetValue(i).ToString());
                            }
                            list.Add(inside_list);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    dt.Close();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
            return list;
        }
    }
}
