using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RStudentsTest
{
    public class AssertsHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AssertsHelper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        public bool IsElementDisplayed(string elementId)
        {
            return _wait.Until(d => d.FindElement(By.Id(elementId))).Displayed;
        }
    }
}
