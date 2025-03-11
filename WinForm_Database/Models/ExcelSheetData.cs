using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Database.Models
{
    public class ExcelSheetData
    {
        public string SheetName { get; set; }
        public DataTable Data { get; set; }
    }
}
