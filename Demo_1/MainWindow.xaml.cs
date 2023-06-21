using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OfficeOpenXml;
using System.IO;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json;

namespace Demo_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            // An man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;

            // connect dn trang web can kiem thu
            IWebDriver driver = new ChromeDriver(chrome);
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/pages/index.html");

            List<Employee> dsNV = FileIO.InportJsonFile("C:/Users/phamn/Desktop/JsonFiles/InsertTesting.json");

            InsertTesting.TC001_001(driver);
            driver.Navigate().Refresh();
            InsertTesting.TC001_002(driver, dsNV);
            driver.Navigate().Refresh();
            InsertTesting.TC001_003(driver, dsNV);
            driver.Navigate().Refresh();
            InsertTesting.TC001_004(driver, dsNV);
            driver.Navigate().Refresh();
            InsertTesting.TC001_005(driver, dsNV);
            driver.Navigate().Refresh();
            InsertTesting.TC001_006(driver, dsNV);
            driver.Navigate().Refresh();
            InsertTesting.TC001_007(driver, dsNV);

            driver.Quit();
            driver.Dispose();
        }

        private void CheckEditBtn_Click(object sender, RoutedEventArgs e)
        {
            // An man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;

            // connect dn trang web can kiem thu
            IWebDriver driver = new ChromeDriver(chrome);
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/pages/index.html");

            List<Employee> dsNV = FileIO.InportJsonFile("C:/Users/phamn/Desktop/JsonFiles/UpdateTesting.json");

            EditTesting.TC002_001(driver);
            driver.Navigate().Refresh();
            EditTesting.TC002_002(driver);
            driver.Navigate().Refresh();
            EditTesting.TC002_003(driver, dsNV);
            driver.Navigate().Refresh();
            EditTesting.TC002_004(driver, dsNV);

            driver.Quit();
            driver.Dispose();
        }

        private void CheckDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // An man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;

            // connect dn trang web can kiem thu
            IWebDriver driver = new ChromeDriver(chrome);
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/pages/index.html");

            DeleteTesting.TC003_001(driver);
            driver.Navigate().Refresh();
            DeleteTesting.TC003_002(driver);
            driver.Navigate().Refresh();
            DeleteTesting.TC003_003(driver);

            driver.Quit();
            driver.Dispose();
        }

        private void CheckFilterAndPaging_Click(object sender, RoutedEventArgs e)
        {
            // An man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;

            // connect dn trang web can kiem thu
            IWebDriver driver = new ChromeDriver(chrome);
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/pages/index.html");

            List<string> dsKeyword = FileIO.InportJsonFileString("C:/Users/phamn/Desktop/JsonFiles/SearchTesting.json");

            FilterAndSearchTesting.TC004_001(driver);
            driver.Navigate().Refresh();
            FilterAndSearchTesting.TC004_002(driver);
            driver.Navigate().Refresh();
            FilterAndSearchTesting.TC004_003(driver);
            driver.Navigate().Refresh();
            FilterAndSearchTesting.TC004_004(driver, dsKeyword);
            driver.Navigate().Refresh();
            FilterAndSearchTesting.TC004_005(driver, dsKeyword);

            driver.Quit();
            driver.Dispose();
        }
    }
}