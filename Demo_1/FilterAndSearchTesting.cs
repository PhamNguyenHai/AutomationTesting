using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Demo_1
{
    public class FilterAndSearchTesting
    {
        private const string Path = "C:/Users/phamn/Desktop/TestCases_MISA_Cukcuk.xlsx";

        public static void TC004_001(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;
                IWebElement EmployeeNumberCbb = driver.FindElement(By.Id("filter-employees-number"));

                // Khởi tạo đối tượng Select để tương tác với combobox
                SelectElement select = new SelectElement(EmployeeNumberCbb);

                // Lấy danh sách tất cả các giá trị trong combobox
                IList<IWebElement> options = select.Options;

                // Duyệt qua từng giá trị trong combobox
                foreach (IWebElement option in options)
                {
                    // Lấy giá trị của option
                    string value = option.GetAttribute("value");
                    // Chọn giá trị trong combobox
                    select.SelectByValue(value);

                    // Lấy ra danh sách nhân viên trong bảng

                    ReadOnlyCollection<IWebElement> EmployeesNumberInTable = driver.FindElements(By.CssSelector("tale tbody tr"));
                    if (EmployeesNumberInTable.Count > int.Parse(value))
                    {
                        TestResult = false;
                        break;
                    }
                }

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F16");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC004_002(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;
                IWebElement PositionCbb = driver.FindElement(By.Id("filter-cbb-position"));

                // Khởi tạo đối tượng Select để tương tác với combobox
                SelectElement select = new SelectElement(PositionCbb);

                // Lấy danh sách tất cả các giá trị trong combobox
                IList<IWebElement> options = select.Options;

                // Duyệt qua từng giá trị trong combobox
                foreach (IWebElement option in options)
                {
                    // Lấy giá trị của option
                    string value = option.GetAttribute("value");
                    // Chọn giá trị trong combobox
                    select.SelectByValue(value);

                    if (option == options[0])
                        continue;
                    else
                    {
                        // Lấy ra danh sách nhân viên trong bảng
                        IList<IWebElement> EmployeeRowsInTable = driver.FindElements(By.CssSelector("tbody tr"));
                        foreach (var employeeRow in EmployeeRowsInTable)
                        {
                            IWebElement rowElement = employeeRow.FindElement(By.CssSelector("td:nth-child(7)"));
                            string rowText = rowElement.Text;
                            if (!rowText.Equals(option.Text))
                            {
                                TestResult = false;
                                break;
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
                //select.SelectByIndex(0);

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F17");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC004_003(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;
                IWebElement DepartmentCbb = driver.FindElement(By.Id("filter-cbb-department"));

                // Khởi tạo đối tượng Select để tương tác với combobox
                SelectElement select = new SelectElement(DepartmentCbb);

                // Lấy danh sách tất cả các giá trị trong combobox
                IList<IWebElement> options = select.Options;

                // Duyệt qua từng giá trị trong combobox
                foreach (IWebElement option in options)
                {
                    // Lấy giá trị của option
                    string value = option.GetAttribute("value");
                    // Chọn giá trị trong combobox
                    select.SelectByValue(value);

                    if (option == options[0])
                        continue;
                    else
                    {
                        // Lấy ra danh sách nhân viên trong bảng
                        IList<IWebElement> EmployeeRowsInTable = driver.FindElements(By.CssSelector("tbody tr"));
                        foreach (var employeeRow in EmployeeRowsInTable)
                        {
                            IWebElement rowElement = employeeRow.FindElement(By.CssSelector("td:nth-child(8)"));
                            string rowText = rowElement.Text;
                            if (!rowText.Equals(option.Text))
                            {
                                TestResult = false;
                                break;
                            }
                        }
                    }

                    Thread.Sleep(1000);
                }
                select.SelectByIndex(0);

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F18");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC004_004(IWebDriver driver, List<string> dsKeyword)
        {
            try
            {
                bool TestResult = true;
                IWebElement searchingInput = driver.FindElement(By.Id("filter-text-input"));

                // truyền từ khóa vào
                searchingInput.SendKeys(dsKeyword[0]);
                Common.ClickElement(driver, ".header");

                IList<IWebElement> EmployeeRowsInTable = driver.FindElements(By.CssSelector("tbody tr"));
                if (EmployeeRowsInTable.Count > 0)
                    TestResult = false;

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F19");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC004_005(IWebDriver driver, List<string> dsKeyword)
        {
            try
            {
                bool TestResult = true;
                IWebElement searchingInput = driver.FindElement(By.Id("filter-text-input"));

                // truyền từ khóa vào
                for (int i = 1; i < dsKeyword.Count; i++)
                {
                    searchingInput.Clear();
                    searchingInput.SendKeys(dsKeyword[i]);
                    Common.ClickElement(driver, ".header");
                    IList<IWebElement> EmployeeRowsInTable = driver.FindElements(By.CssSelector("tbody tr"));
                    foreach (var EmployeeRow in EmployeeRowsInTable)
                    {
                        string MaNV = EmployeeRow.FindElement(By.CssSelector("td:nth-child(1)")).Text;
                        string TenNV = EmployeeRow.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                        string SDT = EmployeeRow.FindElement(By.CssSelector("td:nth-child(5)")).Text;

                        //bool kq1 = dsKeyword[i].Contains(MaNV);
                        //bool kq2 = dsKeyword[i].Contains(TenNV);
                        //bool kq3 = dsKeyword[i].Contains(SDT);
                        if (!MaNV.Contains(dsKeyword[i]) && !TenNV.Contains(dsKeyword[i]) && !SDT.Contains(dsKeyword[i]))
                        {
                            TestResult = false;
                            break;
                        }
                    }

                    if (TestResult == false)
                        break;
                }

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F20");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}