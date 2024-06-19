using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace RStudents.Tests
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

        public bool IsElementUndisplayed(string elementId)
        {
            return !(_wait.Until(d => d.FindElement(By.Id(elementId))).Displayed);
        }

        public void SendKeys(string elementId, string keys)
        {
            _wait.Until(d => d.FindElement(By.Id(elementId))).SendKeys(keys);
        }

        public void Click(string selector, SelectorType selectorType)
        {
            By bySelector;

            switch (selectorType)
            {
                case SelectorType.CssSelector:
                    bySelector = By.CssSelector(selector);
                    break;
                case SelectorType.Id:
                    bySelector = By.Id(selector);
                    break;
                default:
                    throw new ArgumentException("Invalid selector type");
            }

            _wait.Until(d => d.FindElement(bySelector)).Click();
        }

        public bool IsTextDisplayedInElement(string elementId, string text)
        {
            try
            {
                var element = _driver.FindElement(By.Id(elementId));
                return element.Text.Contains(text);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsTextDisplayedUnderElement(string containerId, string text)
        {
            try
            {
                var container = _driver.FindElement(By.Id(containerId));
                var elements = container.FindElements(By.XPath(".//*"));
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool AreTextsDisplayedUnderElement(string containerId, List<string> texts)
        {
            try
            {
                var container = _driver.FindElement(By.Id(containerId));
                var elements = container.FindElements(By.XPath(".//*"));
                foreach (var text in texts)
                {
                    bool textFound = false;
                    foreach (var element in elements)
                    {
                        if (element.Text.Contains(text))
                        {
                            textFound = true;
                            break;
                        }
                    }
                    if (!textFound)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool AreTextsUndisplayedUnderElement(string containerId, List<string> texts)
        {
            try
            {
                var container = _driver.FindElement(By.Id(containerId));
                var elements = container.FindElements(By.XPath(".//*"));
                foreach (var text in texts)
                {
                    foreach (var element in elements)
                    {
                        if (element.Text.Contains(text))
                        {
                            return false; // Jeśli znajdziemy którykolwiek z tekstów, zwróć false
                        }
                    }
                }
                return true; // Żaden z tekstów nie został znaleziony
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }



        public void WaitForAlert()
        {
            _wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

    }
}
