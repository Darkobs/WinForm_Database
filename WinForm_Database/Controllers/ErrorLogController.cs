using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Database.Controllers
{
    public class ErrorLogController
    {
        public void LogException(Exception ex)
        {
            // Implement your logging logic here
            // For example, log to a file:
            File.AppendAllText("error.log", $"{DateTime.Now}: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
