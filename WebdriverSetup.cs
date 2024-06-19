using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RStudents.Tests
{
    public class WebDriverSetup
    {
        protected IWebDriver? driver;
        protected WebDriverWait? wait;
        protected NavigationHelper? navigationHelper;
        protected AssertsHelper assertsHelper;


        [SetUp]
        public void SetUp()
        {
            try
            {
                Console.WriteLine("Starting GeckoDriver...");

                // Ścieżka do GeckoDrivera
                //var service = FirefoxDriverService.CreateDefaultService(@"C:\Users\akasi\source\repos\RStudentsTest\Drivers\geckodriver-v0.34.0-win32\geckodriver.exe");

                // Opcje Firefoxa
                // var options = new FirefoxOptions();

                // Uruchomienie GeckoDrivera
                // driver = new FirefoxDriver(options);
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                navigationHelper = new NavigationHelper(driver, wait);
                assertsHelper = new AssertsHelper(driver, wait);
                Console.WriteLine("GeckoDriver started successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during WebDriver setup: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                Console.WriteLine("Closing GeckoDriver...");
                driver?.Quit();
                Console.WriteLine("GeckoDriver closed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during WebDriver teardown: {ex.Message}");
            }
            finally
            {
                driver?.Dispose();
                Console.WriteLine("GeckoDriver disposed.");
            }
        }

    }
}
