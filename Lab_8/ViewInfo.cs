using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class ViewInfo
    {
        public string ViewName { get; set; }
        public string MainTableName { get; set; }
        public Dictionary<string, string> TableViewCorrelationInfo { get; set; }
        // view_field <-> table_field 

        public ViewInfo() { }
        
        public ViewInfo(string mainTableName , string viewName)
        {
                ViewName = viewName;
                MainTableName = mainTableName;
                TableViewCorrelationInfo = new Dictionary<string, string>();

                string TABLE_sql_com = $"SELECT * FROM {MainTableName} LIMIT 0";
                string VIEW_sql_com = $"SELECT * FROM {ViewName} LIMIT 0";

                var tableSchema = PostgresModule.getSqlComResult(TABLE_sql_com);
                var viewSchema = PostgresModule.getSqlComResult(VIEW_sql_com);
            
                if (tableSchema != null && viewSchema != null)
                {
                    for (int i = 0; i < tableSchema.Columns.Count; ++i)
                    {
                        string tn = tableSchema.Columns[i].ColumnName;
                        string vn = viewSchema.Columns[i].ColumnName;
                        TableViewCorrelationInfo.Add(vn, tn);
                    }
                }
            
            
        }
        

         public string getTableFieldByViewField(string viewName) 
         {
            return TableViewCorrelationInfo[viewName];
         }

        public bool ifViewContainsField(string field)
        {
            foreach (var el in TableViewCorrelationInfo.Keys)
            {
                if (el == field) return true;
            }
            return false;
        }
        
    }

}
