using System;
using OpenQA.Selenium;
using System.Threading;

namespace autotest.PageObject
{
    public class NewPurchasePage
    {
        public IWebDriver driver;

        public NewPurchasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By supplier = By.XPath("//div/div[3]/div[2]/div[1]/div/div/div[1]/div[2]/div[11]/div[2]/div/input"); //定位供应商代码输入框
        By save_success = By.XPath("/html/body/div[4]/div/h2");                       //定位保存成功的提示框

        By save = By.XPath("//*[@id='app']/div/div[3]/div[1]/div[2]/button[2]");      //通过xpath定位保存按钮
        public NewPurchasePage InputSupplier(String suppliername)                     //输入供应商代码
        {
            Thread.Sleep(2000);
            driver.FindElement(supplier ).Click();
            driver.FindElement(supplier).SendKeys(suppliername);
            Thread.Sleep(1000);
            return this;
        }

        public void Save() {                                      //保存新建的采购订单

            Thread.Sleep(2000);
            driver.FindElement(save).Click();
            Thread.Sleep(2000);

        }
        public string Save_success()
        {
            Thread.Sleep(2000);
            var Save_success = driver.FindElement(save_success);                 //返回保存成功的信息
            var save_1 = Save_success.Text;
            return save_1;
        }
    }
}
