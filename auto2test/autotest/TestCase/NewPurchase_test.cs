using autotest.Common;
using autotest.PageObject;
using OpenQA.Selenium;
using System.ComponentModel;
using System.Threading;
using Xunit;

namespace autotest.TestCase
{
    public class NewPurchase_test
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
            home.Switch()
            .Click_purchase_order();
            PurchasePage purchase = new PurchasePage(driver);
            purchase.Click_new_order();
            NewPurchasePage newpurchase = new NewPurchasePage(driver);
            newpurchase.InputSupplier("自动化测试供应商")
                       .Save();
           // Thread.Sleep(2000);
            string save = newpurchase.Save_success();    //将返回的信息 赋值给save
            Assert.Equal("成功", save);       //断言是否操作成功
            browser.Quit();

        }
    }
}
