using CognizantSoftvision.Maqs.BaseAppiumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using CognizantSoftvision.Maqs.Utilities.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageModel
{
    /// <summary>
    /// Page object for ProductsPageModel
    /// </summary>
    public class ProductsPageModel : BaseAppiumPageModel
    {
        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        private LazyMobileElement HeaderTitle
        {
            get { return new LazyMobileElement(this.TestObject, By.CssSelector("div.header_secondary_container > span"), "Header Title"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        private LazyMobileElement HamburgerMenu
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("react-burger-menu-btn"), "Hamburger Menu"); }
        }

        /// <summary>
        /// The login button element 'By' finder
        /// </summary>
        private LazyMobileElement LogoutOption
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("logout_sidebar_link"), "Logout Option"); }
        }

        private IEnumerable<AppiumElement> ProductItems
        {
            get { return this.TestObject.AppiumDriver.FindElements(By.CssSelector("div.inventory_item_name")); }
        }

        private LazyMobileElement CartLink
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("shopping_cart_container"), "Cart Link"); }
        }

        private LazyMobileElement AddToCartButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("add-to-cart-sauce-labs-bike-light"), "Add To Cart Button"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The Appium test object</param>
        public ProductsPageModel(IAppiumTestObject testObject)
            : base(testObject)
        {
        }

        public string GetHeaderTitle()
        {
            return HeaderTitle.Text;
        }

        public void TapHamburgerMenu()
        {
            HamburgerMenu.Click();
        }

        public void TapLogoutOption()
        {
            LogoutOption.Click();
        }

        public void OpenProductItemByName(string name)
        {
            ProductItems.First(i => i.Text.Equals(name)).Click();
        }

        public void TapAddButton()
        {
            AddToCartButton.Click();    
        }

        public CartPageModel OpenCart()
        {
            CartLink.Click();
            return new CartPageModel(this.TestObject);
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the time is displayed</returns>
        public override bool IsPageLoaded()
        {
            return HeaderTitle.Exists;
        }
    }
}
