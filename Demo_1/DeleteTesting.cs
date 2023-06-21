using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_1
{
    public class DeleteTesting
    {
        private const string Path = "C:/Users/phamn/Desktop/TestCases_MISA_Cukcuk.xlsx";

        public static void TC003_001(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;

                // Click vao row thu 2 trong bang
                Common.ClickElement(driver, ".delete-btn");

                Thread.Sleep(1000);

                if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                {
                    // Click nut OK o pop-up
                    Common.ClickElement(driver, ".dialog.dialog--infor .cancel-btn.close-btn");

                    if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                        TestResult = false;
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, TestResult ? "Pass" : "Fail", "F12");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC003_002(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;

                //Lay manv cua nhan vien o dong thu 2 de ti ktra
                string employeeCode = driver.FindElement(By.CssSelector(".content-table  tbody tr:nth-child(2) td")).Text;

                // Click vao row thu 2 trong bang
                Common.ClickElement(driver, ".content-table  tbody tr:nth-child(2) td");

                Thread.Sleep(1000);

                // Click vao nut xoa
                Common.ClickElement(driver, ".delete-btn");

                if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                {
                    // Click nut OK Pop-up xac nhan xoa
                    Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                    Thread.Sleep(1000);

                    // Check Pop-up xac nhan xoa con ton tai khong
                    if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                        TestResult = false;
                    else
                    {
                        if (Common.CheckElementDisplayed(driver, ".dialog.dialog--success"))
                        {
                            // Click nut OK Pop-up xoa thanh cong
                            Common.ClickElement(driver, ".dialog.dialog--success .cancel-btn.close-btn");

                            Thread.Sleep(1000);

                            // Check Pop-up xac xoa thanh cong ton tai khong
                            if (Common.CheckElementDisplayed(driver, ".dialog.dialog--success"))
                                TestResult = false;
                            else
                            {
                                IWebElement hihi = driver.FindElement(By.CssSelector(".content-table  tbody tr:nth-child(2) td"));
                                if (hihi.Text == employeeCode)
                                    TestResult = false;
                            }
                        }
                        else
                            TestResult = false;
                    }
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F13");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TC003_003(IWebDriver driver)
        {
            try
            {
                bool TestResult = true;

                //Lay manv cua nhan vien o dong thu 1 de ti ktra
                string employeeCode = driver.FindElement(By.CssSelector(".content-table  tbody tr:nth-child(1) td")).Text;

                // Click vao row thu 1 trong bang
                Common.ClickElement(driver, ".content-table  tbody tr:nth-child(1) td");

                Thread.Sleep(1000);

                // Click vao nut xoa
                Common.ClickElement(driver, ".delete-btn");

                if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                {
                    // Click nut OK Pop-up xac nhan xoa
                    Common.ClickElement(driver, ".dialog.dialog--infor .conform-btn");

                    Thread.Sleep(1000);

                    // Check Pop-up xac nhan xoa con ton tai khong
                    if (Common.CheckElementDisplayed(driver, ".dialog.dialog--infor"))
                        TestResult = false;
                    else
                    {
                        if (Common.CheckElementDisplayed(driver, ".dialog.dialog--success"))
                        {
                            // Click nut OK Pop-up xoa thanh cong
                            Common.ClickElement(driver, ".dialog.dialog--success .cancel-btn.close-btn");

                            Thread.Sleep(1000);

                            // Check Pop-up xac xoa thanh cong ton tai khong
                            if (Common.CheckElementDisplayed(driver, ".dialog.dialog--success"))
                                TestResult = false;
                            else
                            {
                                IWebElement hihi = driver.FindElement(By.CssSelector(".content-table  tbody tr:nth-child(1) td"));
                                if (hihi.Text == employeeCode)
                                    TestResult = false;
                            }
                        }
                        else
                            TestResult = false;
                    }
                }
                else
                    TestResult = false;

                FileIO.ExportExcelFile(Path, (TestResult == true ? "Pass" : "Fail"), "F14");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}