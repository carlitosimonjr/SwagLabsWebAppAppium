using CognizantSoftvision.Maqs.BaseAppiumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace PageModel
{
    /// <summary>
    /// Page object for CartPageModel
    /// </summary>
    public class CartPageModel : BaseAppiumPageModel
    {
        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        private LazyMobileElement CheckoutButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("checkout"), "Checkout Button"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        private LazyMobileElement FirstNameInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("first-name"), "FirstName Field"); }
        }

        private LazyMobileElement LastNameInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("last-name"), "LastName Field"); }
        }

        private LazyMobileElement PostalCodeInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("postal-code"), "Postal Code Field"); }
        }

        private LazyMobileElement ContinueButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("continue"), "Continue Button"); }
        }

        private LazyMobileElement ErrorMessage
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("div.error-message-container.error"), "Error Message"); }
        }

        private LazyMobileElement TotalPayment
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("div.summary_total_label"), "Total Payment"); }
        }

        private LazyMobileElement FinishButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("finish"), "Finish Button"); }
        }

        private LazyMobileElement CompleteHeader
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("h2.complete-header"), "Complete Header"); }
        }

        private LazyMobileElement CompleteMessage
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("div.complete-text"), "Complete Text"); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CartPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The Appium test object</param>
        public CartPageModel(IAppiumTestObject testObject)
            : base(testObject)
        {
        }

        public void TapCheckoutButton()
        {
            CheckoutButton.Click();
        }

        public void EnterFullname(string firstname, string lastname)
        {
            FirstNameInput.SendKeys(firstname);
            LastNameInput.SendKeys(lastname);
        }

        public void EnterPostalCode(string postalcode)
        {
            PostalCodeInput.SendKeys(postalcode);
        }

        public void TapContinueButton()
        {
            ContinueButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public string GetTotalPayment()
        {
            return TotalPayment.Text;
        }

        public void TapFinishButton()
        {
            FinishButton.Click();
        }

        public string GetCompleteHeader()
        {
            return CompleteHeader.Text;
        }

        public string GetCompleteMessage()
        {
            return CompleteMessage.Text;
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the time is displayed</returns>
        public override bool IsPageLoaded()
        {
            return CheckoutButton.Exists;
        }
    }
}
