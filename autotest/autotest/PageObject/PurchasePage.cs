using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace autotest.PageObject
{
    public class PurchasePage
    {
        public IWebDriver driver;
        public PurchasePage(IWebDriver driver)
        {

            this.driver = driver;

        }
        By new_order = By.XPath("//*[@id='app']/div/div[3]/div[1]/div[1]/div[2]/button[2]"); //通过xpath定位新建采购订单
        By delete_success = By.XPath("/html/body/div[5]/div/div[1]/p");             //定位删除成功提示框

        public void Click_new_order() {
            Thread.Sleep(1000);
            driver.FindElement(new_order).Click();     //点击新建
            Thread.Sleep(2000);                         
            
        }
        public string Delete()
        {
            Thread.Sleep(2000);
            var delete = driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/p"));        //返回删除成功提示信息
            var Del = delete.Text;
            return Del;
        }


    }
}
