using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_1
{
    public class EditTesting
    {
        private const string Path = "C:/Users/phamn/Desktop/TestCases_MISA_Cukcuk.xlsx";

        public static void TC002_001(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;
                // Mo form them
                IWebElement elementRow = driver.FindElement(By.CssSelector(".content-table table tbody tr"));
                Actions dbclickRow = new Actions(driver);
                dbclickRow.DoubleClick(elementRow).Perform();

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Xu ly de lay ra ma nhan vien da ton tai
                    string MaNVTonTai = driver.FindElement(By.CssSelector(".content-table table tbody tr:nth-child(2) td")).Text;

                    // Xoa manv cu va thay bang ma bi trung
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode"));
                    EmployeeCode.Clear();
                    EmployeeCode.SendKeys(MaNVTonTai);

                    // click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Pop-up xac nhan them xuat hien click OK
                    if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                    {
                        Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                        // Nghi 1s
                        Thread.Sleep(1000);

                        // Check
                        IWebElement DangerElementPopUp = driver.FindElement(By.CssSelector(".dialog.dialog--danger"));
                        IWebElement DangerElementPopUpMessage = DangerElementPopUp.FindElement(By.CssSelector(".dialog-message"));

                        if (!Common.CheckElementDisplayed(driver, ".dialog.dialog--danger") || DangerElementPopUpMessage.Text != "Bạn đã cập nhật sang mã nhân viên đã tồn tại")
                            TestResult = false;

                        // Tat pop-up canh bao trung ma
                        Common.ClickElement(driver, ".dialog.dialog--danger .cancel-btn.close-btn");

                        // Dung 2s truoc khi tat form
                        Thread.Sleep(2000);

                        // Tat form
                        Common.ClickElement(driver, ".form-close-btn.close-btn");
                    }
                    else
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

        public static void TC002_002(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;

                // Mo form them
                IWebElement elementRow = driver.FindElement(By.CssSelector(".content-table table tbody tr"));
                Actions dbclickRow = new Actions(driver);
                dbclickRow.DoubleClick(elementRow).Perform();

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Chon cac truong bat buoc nhap
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode"));
                    IWebElement EmployeeName = driver.FindElement(By.Id("employeeName"));
                    IWebElement IdentityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement Email = driver.FindElement(By.Id("email"));
                    IWebElement PhoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Xoa gia tri cac truong do
                    EmployeeCode.Clear();
                    EmployeeName.Clear();
                    IdentityNumber.Clear();
                    Email.Clear();
                    PhoneNumber.Clear();

                    // Click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Lay ra tat ca cac truong co bao loi
                    ReadOnlyCollection<IWebElement> invalidElements = driver.FindElements(By.CssSelector(".invalid"));
                    ReadOnlyCollection<IWebElement> errorMessages = driver.FindElements(By.CssSelector(".invalid .error-message"));

                    // Check
                    if (invalidElements.Count != 5 || errorMessages.Count != 5)
                        TestResult = false;

                    // Dung 2s truoc khi tat form
                    Thread.Sleep(2000);

                    // Tat form
                    Common.ClickElement(driver, ".form-footer .close-btn");
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F9");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC002_003(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;
                // Mo form them
                IWebElement elementRow = driver.FindElement(By.CssSelector(".content-table table tbody tr"));
                Actions dbclickRow = new Actions(driver);
                dbclickRow.DoubleClick(elementRow).Perform();

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    // Data de nhap vao form
                    Employee data = dsNV[0];

                    // Chon cac truong bat buoc nhap
                    IWebElement identityNumber = driver.FindElement(By.Id("identityNumber"));
                    IWebElement email = driver.FindElement(By.Id("email"));
                    IWebElement phoneNumber = driver.FindElement(By.Id("phoneNumber"));

                    // Doi gia tri cac truong
                    identityNumber.Clear();
                    email.Clear();
                    phoneNumber.Clear();
                    identityNumber.SendKeys(data.IdentityNumber);
                    email.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    // nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Lay ra tat ca cac truong co bao loi
                    ReadOnlyCollection<IWebElement> invalidElements = driver.FindElements(By.CssSelector(".invalid"));
                    ReadOnlyCollection<IWebElement> errorMessages = driver.FindElements(By.CssSelector(".invalid .error-message"));

                    // Check
                    if (invalidElements.Count != 3 || errorMessages.Count != 3)
                        TestResult = false;

                    // Dung 2s truoc khi tat form
                    Thread.Sleep(2000);

                    // Tat form
                    Common.ClickElement(driver, ".form-footer .close-btn");
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F10");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC002_004(IWebDriver driver, List<Employee> dsNV)
        {
            try
            {
                bool TestResult = true;
                // Mo form them
                IWebElement elementRow = driver.FindElement(By.CssSelector(".content-table table tbody tr"));
                Actions dbclickRow = new Actions(driver);
                dbclickRow.DoubleClick(elementRow).Perform();

                if (Common.CheckElementDisplayed(driver, ".form"))
                {
                    IWebElement EmployeeCode = driver.FindElement(By.Id("employeeCode")); // Lay manv de ti ktra xem nhan vien da duoc update vao bang chua
                                                                                          // Lay ra manv de sau khi them ktra
                    string MaNV = EmployeeCode.GetAttribute("value");

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

                    // Data de nhap vao form
                    Employee data = dsNV[1];

                    // Xoa het cac truong
                    employeeName.Clear();
                    dateOfBirth.Clear();
                    identityNumber.Clear();
                    identityIssuedDate.Clear();
                    identityIssuedPlace.Clear();
                    employeeEmail.Clear();
                    phoneNumber.Clear();
                    taxCode.Clear();
                    salary.Clear();
                    joiningDate.Clear();

                    // update data
                    employeeName.SendKeys(data.EmployeeName);
                    dateOfBirth.SendKeys(data.DateOfBirth.ToString());
                    gender.SendKeys(data.Gender == 0 ? "Nam" : data.Gender == 1 ? "Nữ" : data.Gender == 2 ? "Khác" : "");
                    identityNumber.SendKeys(data.IdentityNumber);
                    identityIssuedDate.SendKeys(data.IdentityIssuedDate.ToString());
                    identityIssuedPlace.SendKeys((data.IdentityIssuedPlace == null ? "" : data.IdentityIssuedPlace));
                    employeeEmail.SendKeys(data.Email);
                    phoneNumber.SendKeys(data.PhoneNumber);

                    position.SendKeys(data.PositionName);
                    department.SendKeys(data.DepartmentName);
                    Thread.Sleep(5000);
                    taxCode.SendKeys((data.TaxCode == null ? "" : data.TaxCode));
                    salary.SendKeys(data.Salary.ToString());
                    joiningDate.SendKeys(data.JoiningDate.ToString());
                    workStatus.SendKeys(data.WorkStatus == 0 ? "Đã nghỉ" : data.WorkStatus == 1 ? "Đang làm" : data.WorkStatus == 2 ? "Thử việc" : "");

                    // click nut save
                    Common.ClickElement(driver, ".form-footer .save-btn");

                    // Pop-up xac nhan them xuat hien click OK
                    Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                    // Nghi 1s
                    Thread.Sleep(1000);

                    // Check
                    IWebElement SuccessElementPopUpMessage = driver.FindElement(By.CssSelector(".dialog.dialog--success .dialog-message"));
                    // Ktra nhan vien da duoc update vao row chua
                    ReadOnlyCollection<IWebElement> result = driver.FindElements(By.CssSelector(".content-table table tbody tr:nth-child(1) td"));

                    bool check = false;
                    if (result[0].Text == MaNV
                        && result[1].Text == data.EmployeeName
                        && result[2].Text == (data.Gender == 0 ? "Nam" : data.Gender == 1 ? "Nữ" : "Khác")
                        && DateTime.ParseExact(result[3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString() == data.DateOfBirth.ToString()
                        && result[4].Text == data.PhoneNumber
                        && result[5].Text == data.Email
                        && result[6].Text == data.PositionName
                        && result[7].Text == data.DepartmentName
                        && result[8].Text.Replace(".", "").Contains(data.Salary.ToString())
                        && (data.WorkStatus == 0 ? "Đã nghỉ" : data.WorkStatus == 1 ? "Đang làm" : "Thử việc").Contains(result[9].Text)
                        )
                        check = true;

                    if (!check || !Common.CheckElementDisplayed(driver, ".dialog.dialog--success") || !SuccessElementPopUpMessage.Text.Contains("Đã cập nhật thành công nhân viên có mã"))
                        TestResult = false;

                    // Dung 1s truoc khi tat form
                    Thread.Sleep(1000);

                    Common.ClickElement(driver, ".dialog.dialog--success .cancel-btn.close-btn");
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F11");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}