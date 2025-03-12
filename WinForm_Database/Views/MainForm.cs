using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_Database.Models;
using WinForm_Database.Controllers;

namespace WinForm_Database
{
    public partial class MainForm: Form
    {
        private ExcelReadController _ExcelReadcontroller;
        private SQLiteSaveController _SQLiteSavecontroller;
        private ParquetSaveController _ParquetSavecontroller;
        private List<ExcelSheetData> _sheetsData;

        public MainForm()
        {
            InitializeComponent();
            _ExcelReadcontroller = new ExcelReadController();
            _SQLiteSavecontroller = new SQLiteSaveController();
            _ParquetSavecontroller = new ParquetSaveController();
        }

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _sheetsData = _ExcelReadcontroller.ReadExcelFile(openFileDialog.FileName);
                    MessageBox.Show("Excel file read successfully.");
                }
            }
        }

        private void btnSaveToSQLite_Click(object sender, EventArgs e)
        {
            if (_sheetsData != null)
            {
                var connectionString = "Data Source=AtRiskDatabaseFile.db;Version=3;";
                _SQLiteSavecontroller.SaveToSQLite(_sheetsData, connectionString);
                MessageBox.Show("Data saved to database successfully.");
            }
            else
            {
                MessageBox.Show("No data to save. Please read an Excel file first.");
            }
        }

        private void btnSaveToParquet_Click(object sender, EventArgs e)
        {
            if (_sheetsData != null)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Parquet Files|*.parquet";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _ParquetSavecontroller.SaveToParquet(_sheetsData, saveFileDialog.FileName);
                        MessageBox.Show("Data saved to Parquet file successfully.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to save. Please read an Excel file first.");
            }
        }
    }
}
