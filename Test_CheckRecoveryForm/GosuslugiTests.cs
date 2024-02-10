using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CheckRecoveryFormTests
{
    public class GosuslugiTests
    {
        protected IWebDriver driver;

        private readonly By _loginButton = By.CssSelector("button.login-button");
        private readonly By _loginIssueButton = By.CssSelector("div.mt-40 button.plain-button-inline");
        private readonly By _passwordRecoveryLink = By.CssSelector("li button.plain-button-inline");
        private readonly By _passwordRecoveryFormTitle = By.CssSelector("h3.title-h3");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void TestPasswordRecoveryFormOpening_ExpectedLoginRecoveryUrl()
        {
            string expectedUrl = "https://esia.gosuslugi.ru/login/recovery";

            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");
            driver.FindElement(_loginButton).Click();
            driver.FindElement(_loginIssueButton).Click();
            driver.FindElement(_passwordRecoveryLink).Click();
            driver.FindElement(_passwordRecoveryFormTitle);
            string url = driver.Url;

            Assert.That(url, Is.EqualTo(expectedUrl));
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
        }
    }
}