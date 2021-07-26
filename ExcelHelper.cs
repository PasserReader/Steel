using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;


namespace WindowsApplication.Utility
{
    static class ExcelHelper
    {

        public enum FileState { Exist, Missing }

        public static string ReadFile(string path, string sheetName = "Sheet1")
        {
            string content = "";

            try
            {
                XSSFWorkbook file = new XSSFWorkbook(path);

                if (file == null)
                    return "Can't find any correct files";
                ISheet sheet = file.GetSheet(sheetName);
                if (sheet == null)
                    return "Can't find any correct sheets";


                for (int r = 0; r < sheet.LastRowNum; r++)
                {
                    IRow row = sheet.GetRow(r);
                    for (int c = 0; c < row.LastCellNum; c++)
                    {
                        content += row.GetCell(c).ToString() + ", ";
                    }
                    content += "\n";
                }

                file.Close();
            }
            catch
            {

            }
            
            return content;
        }



        public static List<string> ReadFileByList(string path, string sheetName = "Sheet1")
        {
            List<string> lines = new List<string>();

            try
            {
                XSSFWorkbook file = new XSSFWorkbook(path);

                if (file == null)
                    return null;
                ISheet sheet = file.GetSheet(sheetName);
                if (sheet == null)
                    return null;


                for (int r = 0; r < sheet.LastRowNum; r++)
                {
                    IRow row = sheet.GetRow(r);
                    for (int c = 0; c < row.LastCellNum; c++)
                    {
                        lines.Add(row.GetCell(c).ToString());
                    }
                }

                file.Close();
            }
            catch
            {

            }

            return lines;
        }


        public static void WriteFile(string path, string sheetName = "Sheet1")
        {
            
        }
    }
}
