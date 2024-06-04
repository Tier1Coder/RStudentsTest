using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RStudents.Tests
{
    public class NavigationHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public NavigationHelper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void GoToHomePage()
        {
            Console.WriteLine("Navigating to Home Page");
            _driver.Navigate().GoToUrl(Urls.HomePage);
            _wait.Until(d => d.Url == Urls.HomePage);
        }

        public void GoToStudentsPage()
        {
            Console.WriteLine("Navigating to Students Page");
            _driver.Navigate().GoToUrl(Urls.StudentsPage);
            _wait.Until(d => d.Url == Urls.StudentsPage);
        }
        public void GoToCreateStudentPage()
        {
            Console.WriteLine("Navigating to Create Student Page");
            _driver.Navigate().GoToUrl(Urls.CreateStudentPage);
            _wait.Until(d => d.Url == Urls.CreateStudentPage);
        }
    }
}
