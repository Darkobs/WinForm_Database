using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Database.Models;
using Parquet;
using Parquet.Data;
using System.Data;
using System.Drawing.Printing;

namespace WinForm_Database.Controllers
{
    public class ParquetSaveController
    {
        private ErrorLogController _ErrorLogController;

        public void SaveToParquet(List<ExcelSheetData> sheetsData, string filePath)
        {
            _ErrorLogController = new ErrorLogController();

            try
            {
                foreach (var sheet in sheetsData)
                {
                    var table = sheet.Data;

                    var fields = new List<DataField>();

                    foreach (System.Data.DataColumn column in table.Columns)
                    {
                        fields.Add(new DataField(column.ColumnName, column.DataType));
                    }

                    var schema = new Schema(fields);
                    var parquetRows = new List<Parquet.Data.Rows.Row>();

                    foreach (System.Data.DataRow row in table.Rows)
                    {
                        parquetRows.Add(new Parquet.Data.Rows.Row(row.ItemArray));
                    }

                    using (Stream fs = System.IO.File.OpenWrite(filePath))
                    {
                        using (var parquetWriter = new ParquetWriter(schema, fs))
                        {
                            using (var groupWriter = parquetWriter.CreateRowGroup())
                            {
                                foreach (var field in fields)
                                {
                                    var columnData = parquetRows.Select(r => r.Values[fields.IndexOf(field)]).ToArray();
                                    if (field.DataType == DataType.String)
                                    {
                                        columnData = columnData.Cast<string>().ToArray();
                                    }
                                    groupWriter.WriteColumn(new Parquet.Data.DataColumn(field, columnData));
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ErrorLogController.LogException(ex);
                throw;
            }
        }

    }


}
