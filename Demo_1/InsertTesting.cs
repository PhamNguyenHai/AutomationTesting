using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_1
{
    public class InsertTesting
    {
        private const string Path = "C:/Users/phamn/Desktop/TestCases_MISA_Cukcuk.xlsx";

        public static void TC001_001(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;
                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Lay element input ma nv tu sinh
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode"));

                    // Xoa ma nv tu sinh
                    EmployeeCode.Clear();

                    // lay nut luu save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Check
                    ReadOnlyCollection<IWebElement> invalidElements = driver.FindElements(By.CssSelector(".invalid"));
                    ReadOnlyCollection<IWebElement> errorMessages = driver.FindElements(By.CssSelector(".invalid .error-message"));
                    if (invalidElements.Count != 5 || errorMessages.Count != 5)
                        TestResult = false;

                    // Dung 2s truoc khi tat form
                    Thread.Sleep(2000);

                    // Tat form
                    if (Common.CheckElementDisplayed(driver, ".close-btn"))
                        Common.ClickElement(driver, ".close-btn");
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_002(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                // Check form co display khong
                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[0];

                    // Select cac element
                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));

                    // Nhap du lieu
                    employeeName.SendKeys(data.EmployeeName);
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Check
                    IWebElement invalidElement = driver.FindElement(By.CssSelector(".invalid"));
                    IWebElement errorMessage = invalidElement.FindElement(By.CssSelector(".error-message"));

                    if (invalidElement == null || errorMessage.Text == null)
                        TestResult = false;

                    // Dung 2s truoc khi tat form
                    Thread.Sleep(2000);

                    // Tat form
                    if (Common.CheckElementDisplayed(driver, ".close-btn"))
                        Common.ClickElement(driver, ".close-btn");
                }
                else
                    TestResult = false;
                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F3");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_003(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[1];

                    // Select cac element
                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Nhap du lieu
                    employeeName.SendKeys(data.EmployeeName);
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Check
                    ReadOnlyCollection<IWebElement> invalidElements = driver.FindElements(By.CssSelector(".invalid"));
                    ReadOnlyCollection<IWebElement> errorMessages = driver.FindElements(By.CssSelector(".invalid .error-message"));

                    if (invalidElements.Count != 3 || errorMessages.Count != 3)
                        TestResult = false;

                    // Dung 2s truoc khi tat form
                    Thread.Sleep(2000);

                    // Tat form
                    if (Common.CheckElementDisplayed(driver, ".close-btn"))
                        Common.ClickElement(driver, ".close-btn");
                }
                else
                    TestResult = false;
                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F4");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_004(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[2];

                    // Select cac element
                    IWebElement employeeCode = driver.FindElement(By.Id("employeeCode"));
                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Xu ly ma nv
                    string employeeCodeValue = employeeCode.GetAttribute("value");
                    int number = int.Parse(employeeCodeValue.Replace("NV", "")) - 1;
                    employeeCodeValue = "NV" + number;

                    // Nhap du lieu
                    employeeCode.Clear();
                    employeeCode.SendKeys(employeeCodeValue);
                    employeeName.SendKeys(data.EmployeeName);
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Check Pop-up xac nhan them xuat hien
                    if (!Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                        TestResult = false;
                    else
                    {
                        // Click nut OK Pop-up xac nhan them
                        Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                        Thread.Sleep(1000);

                        // Pop-up canh bao trung ma
                        IWebElement DangerElementPopUpMessage = driver.FindElement(By.CssSelector(".dialog.dialog--danger .dialog-message"));
                        if (!Common.CheckElementDisplayed(driver, ".dialog.dialog--danger") || DangerElementPopUpMessage.Text != "Mã nhân viên đã tồn tại")
                            TestResult = false;

                        // Tat Pop-up
                        Common.ClickElement(driver, ".dialog.dialog--danger .cancel-btn.close-btn");

                        // Dung 2s truoc khi tat form
                        Thread.Sleep(1000);

                        // Tat form
                        if (Common.CheckElementDisplayed(driver, ".close-btn"))
                            Common.ClickElement(driver, ".close-btn");
                    }
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F5");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_005(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[2];

                    // Select cac element
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode")); // Lay manv de ti ktra xem nhan vien da duoc them vao bang chua
                                                                                          // Lay ra manv de sau khi them ktra
                    string MaNV = EmployeeCode.GetAttribute("value");

                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Nhap du lieu
                    employeeName.SendKeys(data.EmployeeName);
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Pop-up xac nhan them xuat hien click OK
                    Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                    Thread.Sleep(1000);

                    // Check
                    IWebElement SuccessElementPopUpMessage = driver.FindElement(By.CssSelector(".dialog.dialog--success .dialog-message"));
                    IWebElement rowEmployeeAfterAdded = driver.FindElement(By.CssSelector(".content-table table tbody td"));
                    if (!Common.CheckElementDisplayed(driver, ".dialog.dialog--success") || !SuccessElementPopUpMessage.Text.Contains("Đã thêm thành công nhân viên có mã") || rowEmployeeAfterAdded.Text != MaNV)
                        TestResult = false;

                    // Tat pop-up them thanh cong
                    Common.ClickElement(driver, ".dialog.dialog--success .cancel-btn.close-btn");

                    // Dung 1s truoc khi tat form
                    Thread.Sleep(1000);

                    // Khong can tat form vi khi them se tu tat
                    // Ktra Tat form
                    if (Common.CheckElementDisplayed(driver, ".close-btn"))
                    {
                        TestResult = false;
                        Common.ClickElement(driver, ".close-btn");
                    }
                }
                else
                    TestResult = false;
                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F6");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_006(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");
                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode")); // Lay manv de ti ktra xem nhan vien da duoc them vao bang chua
                                                                                          // Lay ra manv de sau khi them ktra
                    string MaNV = EmployeeCode.GetAttribute("value");

                    //Data de nhap du lieu
                    Employee data = dsNV[3];

                    // Select cac element
                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement dateOfBirth = driver.FindElement(By.Id("dateOfBirth"));
                    IWebElement gender = driver.FindElement(By.Id("gender"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement identityIssuedDate = driver.FindElement(By.Id("identityIssuedDate"));
                    IWebElement identityIssuedPlace = driver.FindElement(By.Id("identityIssuedPlace"));
                    IWebElement employeeEmail = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    IWebElement position = driver.FindElement(By.Id("positionID"));
                    IWebElement department = driver.FindElement(By.Id("departmentID"));
                    IWebElement taxCode = driver.FindElement(By.Id("taxCode"));
                    IWebElement salary = driver.FindElement(By.Id("salary"));
                    IWebElement joiningDate = driver.FindElement(By.Id("joiningDate"));
                    IWebElement workStatus = driver.FindElement(By.Id("workStatus"));

                    // Nhap du lieu
                    employeeName.SendKeys(data.EmployeeName);
                    dateOfBirth.SendKeys(data.DateOfBirth.ToString());
                    gender.SendKeys(data.Gender == 0 ? "Nam" : data.Gender == 1 ? "Nữ" : "Khác");
                    identityNumber.SendKeys(data.IdentityNumber);
                    identityIssuedDate.SendKeys(data.IdentityIssuedDate.ToString());
                    identityIssuedPlace.SendKeys(data.IdentityIssuedPlace);
                    employeeEmail.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    position.SendKeys(data.PositionName);
                    department.SendKeys(data.DepartmentName);
                    taxCode.SendKeys(data.TaxCode);
                    salary.SendKeys(data.Salary.ToString());
                    joiningDate.SendKeys(data.JoiningDate.ToString());
                    workStatus.SendKeys(data.WorkStatus == 0 ? "Đã nghỉ" : data.WorkStatus == 1 ? "Đang làm" : "Thử việc");

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Pop-up xac nhan them xuat hien click OK
                    Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                    Thread.Sleep(1000);

                    // Check
                    IWebElement SuccessElementPopUpMessage = driver.FindElement(By.CssSelector(".dialog.dialog--success .dialog-message"));
                    IWebElement rowEmployeeAfterAdded = driver.FindElement(By.CssSelector(".content-table table tbody td"));
                    if (!Common.CheckElementDisplayed(driver, ".dialog.dialog--success") || !SuccessElementPopUpMessage.Text.Contains("Đã thêm thành công nhân viên có mã") || rowEmployeeAfterAdded.Text != MaNV)
                        TestResult = false;

                    // Tat pop-up them thanh cong
                    Common.ClickElement(driver, ".dialog.dialog--success .cancel-btn.close-btn");

                    // Dung 1s truoc khi tat form
                    Thread.Sleep(1000);

                    // Khong can tat form vi khi them se tu tat
                    // Ktra Tat form
                    if (Common.CheckElementDisplayed(driver, ".close-btn"))
                    {
                        TestResult = false;
                        Common.ClickElement(driver, ".close-btn");
                    }
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F7");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC001_007(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                Common.ClickElement(driver, ".insert-btn");

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[4];

                    IWebElement employeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Nhap du lieu
                    employeeName.SendKeys(data.EmployeeName);
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Check
                    bool invalidElement = Common.CheckElementDisplayed(driver, ".invalid");
                    bool errorMessage = Common.CheckElementDisplayed(driver, ".error-message");

                    if (!invalidElement || !errorMessage)
                        TestResult = false;
                }
                else
                    TestResult = false;
                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F8");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}