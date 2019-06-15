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
   public class Delete_order
    {
        [Fact(DisplayName = "删除新建采购订单")]
        [Description("登录成功后，在订单中心，新建采购订单，并保存，保存成功后，删除新建的采购订单")]
        public void Delete()
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

            Generated_purchasePage generated = new Generated_purchasePage(driver);
            generated.Delete_order();             //删除订单
                
            string delete= purchase.Delete();    //将返回的信息 赋值给delete
            Assert.Equal("删除成功", delete);       //断言是否操作成功
            //browser.Quit();


        }
    }
}
