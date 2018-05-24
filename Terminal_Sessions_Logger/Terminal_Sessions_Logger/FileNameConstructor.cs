using System;
using System.IO;

namespace Terminal_Sessions_Logger
{
    internal class FileNameConstructor
    {
        internal static string GetPath()
        {
            try
            {
                //Get Default Directory Path
                //string _path = Directory.GetCurrentDirectory();
                string _path = @"\\svaakntnas597\shared\Information Security\CitrixReports\";
                if (Directory.Exists(_path + "\\Logs"))
                {
                    _path += "\\Logs\\" + (DateTime.Now.ToString("dd_MM_yyyy")) + ".csv";
                    return _path;
                }
                else
                {
                    Directory.CreateDirectory(_path + "\\Logs");
                    _path += "\\Logs\\" + (DateTime.Now.ToString("dd_MM_yyyy")) + ".csv";
                    return _path;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
