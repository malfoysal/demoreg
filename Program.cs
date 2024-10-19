using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class demoregistration

{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();

        ExtentReports extentReports = new ExtentReports();

        ExtentSparkReporter reportpath = new ExtentSparkReporter(@"D:\ReportLocation\Report.html");
        extentReports.AttachReporter(reportpath);

        ExtentTest test = extentReports.CreateTest("login test", "this is our first test case");


        driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");

        test.Log(Status.Info, "open browser");

        Console.WriteLine("Open browser");


        driver.Manage().Window.Maximize();
        IWebElement loginButton = driver.FindElement(By.CssSelector("#loginPanel > form > div:nth-child(5) > input"));
        if (loginButton.Displayed)
        {
            Console.WriteLine("true");
            driver.FindElement(By.CssSelector("#loginPanel > p:nth-child(3) > a")).Click();
        }
        else
        {
            Console.WriteLine("false");
        }

        driver.FindElement(By.CssSelector("#customer\\.firstName")).SendKeys("don");
        driver.FindElement(By.CssSelector("#customer\\.lastName")).SendKeys("jee");

        driver.Quit();
        extentReports.Flush();
    }
}
