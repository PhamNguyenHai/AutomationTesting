using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1
{
    public class FileIO
    {
        public static void ExportExcelFile(string path, string value, string cell)
        {
            try
            {
                // Mở file Excel
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    // Chọn sheet 1
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                    // Ghi dữ liệu vào ô trong worksheet
                    worksheet.Cells[cell].Value = value;

                    // Lưu file
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<Employee> InportJsonFile(string path)
        {
            // Đường dẫn đến tệp tin JSON
            string filePath = path;

            // Đọc nội dung tệp tin JSON
            string jsonContent = File.ReadAllText(filePath);

            // Chuyển đổi JSON thành thành đối tượng Employee
            return JsonConvert.DeserializeObject<List<Employee>>(jsonContent);
        }

        public static List<string> InportJsonFileString(string path)
        {
            // Đường dẫn đến tệp tin JSON
            string filePath = path;

            // Đọc nội dung tệp tin JSON
            string jsonContent = File.ReadAllText(filePath);

            // Chuyển đổi JSON thành thành đối tượng Employee
            return JsonConvert.DeserializeObject<List<string>>(jsonContent);
        }
    }
}