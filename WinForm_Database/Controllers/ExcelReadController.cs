using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using WinForm_Database.Models;

namespace WinForm_Database.Controllers
{
    public class ExcelReadController
    {
        private ErrorLogController _ErrorLogController;
        public List<ExcelSheetData> ReadExcelFile(string filePath)
        {
            var sheetsData = new List<ExcelSheetData>();
            _ErrorLogController = new ErrorLogController();

            try
            {
                // If you use EPPlus in a noncommercial context
                // according to the Polyform Noncommercial license:
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        var dataTable = new DataTable(sheet.Name);
                        foreach (var headerCell in sheet.Cells[1, 1, 1, sheet.Dimension.End.Column])
                        {
                            dataTable.Columns.Add(headerCell.Text);
                        }

                        for (var rowNum = 2; rowNum <= sheet.Dimension.End.Row; rowNum++)
                        {
                            var row = dataTable.NewRow();
                            for (var colNum = 1; colNum <= sheet.Dimension.End.Column; colNum++)
                            {
                                row[colNum - 1] = sheet.Cells[rowNum, colNum].Text;
                            }
                            dataTable.Rows.Add(row);
                        }

                        sheetsData.Add(new ExcelSheetData { SheetName = sheet.Name, Data = dataTable });
                    }
                }
            }

            catch (IOException ex)
            {
                // Log the exception (e.g., to a file or logging system)
                _ErrorLogController.LogException(ex);
                // Inform the user
                throw new ApplicationException("An error occurred while reading the Excel file.", ex);
            }
            catch (Exception ex)
            {
                // Log the exception
                _ErrorLogController.LogException(ex);
                // Inform the user
                throw new ApplicationException("An unexpected error occurred.", ex);
            }

            return sheetsData;
        }
    }
}
