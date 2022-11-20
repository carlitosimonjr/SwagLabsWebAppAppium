using CognizantSoftvision.Maqs.BaseAppiumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;
using System.Reflection.Emit;

namespace Tests
{
    /// <summary>
    /// AppiumTestsVSUnit test class with VSUnit
    /// </summary>
    [TestClass]
    public class SwagLabs : BaseAppiumTest
    {

        /// <summary>
        /// Verify adding of new contact
        /// </summary>
        [TestMethod]
        public void SignInOutTest()
        {
            string username = "standard_user";
            string password = "secret_sauce";
            string expectedErrorMessageForBlankUsername = "Epic sadface: Username is required";
            string expectedErrorMessageForInvalidCredential = "Epic sadface: Username and password do not match any user in this service";
            string headerTitle = "PRODUCTS";

            LoginPageModel loginPage = new LoginPageModel(this.TestObject);
            loginPage.OpenPage();
            loginPage.LoginWithInvalidCredentials("", "");

            SoftAssert.Assert(() => Assert.AreEqual(expectedErrorMessageForBlankUsername, loginPage.GetErrorMessage(), "Incorrect message"));

            loginPage.LoginWithInvalidCredentials("Not", "Valid");
            SoftAssert.Assert(() => Assert.AreEqual(expectedErrorMessageForInvalidCredential, loginPage.GetErrorMessage(), "Incorrect message"));

            ProductsPageModel productsPage = loginPage.LoginWithValidCredentials(username, password);
            SoftAssert.Assert(() => Assert.AreEqual(headerTitle, productsPage.GetHeaderTitle(), "Incorrect header title"));

            productsPage.TapHamburgerMenu();
            productsPage.TapLogoutOption();
            SoftAssert.Assert(() => Assert.IsTrue(loginPage.IsPageLoaded(), "Login button is missing"));

            SoftAssert.FailTestIfAssertFailed();
        }

        [TestMethod]
        public void CheckoutCartTest()
        {
            string username = "standard_user";
            string password = "secret_sauce";
            string productA = "Sauce Labs Bike Light";
            string firstname = "first";
            string lastname = "last";
            string postalcode = "911";
            string expectedErrorMessageForInvalidCredential = "Error: Postal Code is required";
            string expectedTotalPayment = "Total: $10.79";
            string expectedCompleteHeader = "THANK YOU FOR YOUR ORDER";
            string expectedCompleteMessage = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";

            LoginPageModel loginPage = new LoginPageModel(this.TestObject);
            loginPage.OpenPage();

            ProductsPageModel productsPage = loginPage.LoginWithValidCredentials(username, password);
            productsPage.OpenProductItemByName(productA);
            productsPage.TapAddButton();

            CartPageModel cartPage = productsPage.OpenCart();
            cartPage.TapCheckoutButton();
            cartPage.EnterFullname(firstname, lastname);
            cartPage.TapContinueButton();
            SoftAssert.Assert(() => Assert.AreEqual(expectedErrorMessageForInvalidCredential, cartPage.GetErrorMessage(), "Incorrect message"));

            cartPage.EnterPostalCode(postalcode);
            cartPage.TapContinueButton();
            SoftAssert.Assert(() => Assert.AreEqual(expectedTotalPayment, cartPage.GetTotalPayment(), "Incorrect total payment"));
            
            cartPage.TapFinishButton();
            SoftAssert.Assert(() => Assert.AreEqual(expectedCompleteHeader, cartPage.GetCompleteHeader(), "Incorrect complete header"));
            SoftAssert.Assert(() => Assert.AreEqual(expectedCompleteMessage, cartPage.GetCompleteMessage(), "Incorrect complete message"));

            SoftAssert.FailTestIfAssertFailed();
        }
    }
}
