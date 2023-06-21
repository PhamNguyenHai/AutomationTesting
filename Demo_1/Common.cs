using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1
{
    public class Common
    {
        public static bool CheckElementDisplayed(IWebDriver driver, string cssSelector)
        {
            try
            {
                IWebElement formElement = driver.FindElement(By.CssSelector(cssSelector));
                if (formElement.Displayed == true)
                    return true;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void ClickElement(IWebDriver driver, string cssSelector)
        {
            IWebElement closeBtnElement = driver.FindElement(By.CssSelector(cssSelector));
            closeBtnElement.Click();
        }
    }
}