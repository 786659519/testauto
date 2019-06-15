using autotest.Common;
using autotest.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace autotest.TestCase
{
   public class NewPurchase
    {
        [Fact(DisplayName = "新建采购订单")]
        [Description("登录成功后，在订单中心，新建采购订单，并保存。")]
        public void New_order()
        {
            Browser browser = new Browser();
            IWebDriver driver = browser.Start();
            LoginPage login = new LoginPage(driver);
            login.InputUsername("autotest")
                 .InputPassword("admin")
                 .SubmitLogin();
            HomePage home = new HomePage(driver);
            home.Switch();
            home.Click_purchase_order()
                .Click_new_order();
            PurchasePage purchase = new PurchasePage(driver);
            purchase.Click_new_order()
                    .InputSupplier("自动化测试供应商")
                    .Save();

        }
    }
}
