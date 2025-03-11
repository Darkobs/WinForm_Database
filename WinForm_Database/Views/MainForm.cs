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
        private ExcelToSQLiteController _controller;
        private List<ExcelSheetData> _sheetsData;

        public MainForm()
        {
            InitializeComponent();
            _controller = new ExcelToSQLiteController();
        }

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _sheetsData = _controller.ReadExcelFile(openFileDialog.FileName);
                    MessageBox.Show("Excel file read successfully.");
                }
            }
        }

        private void btnSaveToSQLite_Click(object sender, EventArgs e)
        {
            if (_sheetsData != null)
            {
                var connectionString = "Data Source=AtRiskDatabaseFile.db;Version=3;";
                _controller.SaveToSQLite(_sheetsData, connectionString);
                MessageBox.Show("Data saved to database successfully.");
            }
            else
            {
                MessageBox.Show("No data to save. Please read an Excel file first.");
            }
        }
    }
}
