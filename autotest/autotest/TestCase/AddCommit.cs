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
    public class AddCommit
    {
        [Fact(DisplayName = "添加采购订单评论")]
        [Description("登录成功后，在订单中心，新建采购订单，并保存，保存成功后，在评论区添加新的评论")]
        public void Add_Commit()
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
            generated.InputCommit("自动化测试");
            generated.Submit();
            string comment = generated.Comment();    
            Assert.Equal("自动化测试", comment);       //断言是否操作成功
            browser.Quit();

        }
    }
}