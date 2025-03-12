using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Database.Models;
using System.IO;

namespace WinForm_Database.Controllers
{
    public class SQLiteSaveController
    {
        private ErrorLogController _ErrorLogController;
        public void SaveToSQLite(List<ExcelSheetData> sheetsData, string connectionString)
        {
            _ErrorLogController = new ErrorLogController();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    foreach (var sheetData in sheetsData)
                    {
                        var createTableQuery = $"CREATE TABLE IF NOT EXISTS {sheetData.SheetName} (";
                        foreach (DataColumn column in sheetData.Data.Columns)
                        {
                            createTableQuery += $"\"{column.ColumnName}\" TEXT,";
                        }
                        createTableQuery = createTableQuery.TrimEnd(',') + ");";
                        using (var command = new SQLiteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        foreach (DataRow row in sheetData.Data.Rows)
                        {
                            var insertQuery = $"INSERT INTO {sheetData.SheetName} VALUES (";
                            foreach (var item in row.ItemArray)
                            {
                                insertQuery += $"'{item}',";
                            }
                            insertQuery = insertQuery.TrimEnd(',') + ");";
                            using (var command = new SQLiteCommand(insertQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            catch (SQLiteException ex)
            {
                // Log the exception
                _ErrorLogController.LogException(ex);
                // Inform the user
                throw new ApplicationException("An error occurred while saving data to the database.", ex);
            }
            catch (Exception ex)
            {
                // Log the exception
                _ErrorLogController.LogException(ex);
                // Inform the user
                throw new ApplicationException("An unexpected error occurred.", ex);
            }
        }
    }
}
