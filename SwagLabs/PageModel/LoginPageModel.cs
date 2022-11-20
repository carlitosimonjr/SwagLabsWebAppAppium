using CognizantSoftvision.Maqs.BaseAppiumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace PageModel
{
    /// <summary>
    /// Page object for LoginPageModel
    /// </summary>
    public class LoginPageModel : BaseAppiumPageModel
    {

        private static readonly string PageUrl = "https://saucedemo.com";
        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        private LazyMobileElement UserNameInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("user-name"), "User Name Field"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        private LazyMobileElement PasswordInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("password"), "Password Field"); }
        }

        /// <summary>
        /// The login button element 'By' finder
        /// </summary>
        private LazyMobileElement LoginButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("login-button"), "Login Button"); }
        }

        private LazyMobileElement ErrorMessage
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("div.error-message-container.error"), "Error Message"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The Appium test object</param>
        public LoginPageModel(IAppiumTestObject testObject)
            : base(testObject)
        {
        }

        public void OpenPage()
        {
            this.TestObject.AppiumDriver.Navigate().GoToUrl(PageUrl);
        }

        public void EnterCredentials(string userName, string password)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(userName);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void LoginWithInvalidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();
        }

        public ProductsPageModel LoginWithValidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();
            return new ProductsPageModel(this.TestObject);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the time is displayed</returns>
        public override bool IsPageLoaded()
        {
            return LoginButton.Exists;
        }
    }
}
