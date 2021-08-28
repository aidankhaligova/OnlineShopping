using OnlineShopping.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Helpers
{
    public static class Helper
    {
        public static void Log(Exception ex)
        {
            Directory.CreateDirectory(Constants.LOGFILEFOLDER);

            using (var writer = File.AppendText(Constants.LOGFILEPATH))
            {
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
                writer.WriteLine();
            }
        }
    }
}
