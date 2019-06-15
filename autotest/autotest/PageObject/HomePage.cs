using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace autotest.PageObject
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By order_center = By.XPath("//div/div[1]/div[1]/ul[2]/li/div");    //订单中心
        By purchase_order = By.XPath("/html/body/div[2]/ul/div[2]/li/a");  //采购订单
        public PurchasePage Click_purchase_order()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Frame("iframeApp");                         //进入到frame
            driver.FindElement(order_center).Click();                //点击订单中心
            Thread.Sleep(3000);
            driver.FindElement(purchase_order).Click();             //点击采购订单
            return new PurchasePage(driver);                        //返回采购订单页面对象
        }
        public HomePage Switch()                       //根据标题切换句柄
        {


            Thread.Sleep(3000);
            
            var oldWinHandle = driver.CurrentWindowHandle;
            foreach (var winHandle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(winHandle);
                if (driver.Title.Contains("科箭Power SCM云平台"))
                {
                    break;
                }
            }
            return this;
        }
        public String Success() {

            driver.SwitchTo().Frame("iframeApp");
            var success = driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div/p[1]"));        //返回登录失败的提示信息
            var suc =success.Text;
            return suc;

        }
    }
}
