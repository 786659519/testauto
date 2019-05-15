using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo_2
{
     public class OldPurchasePage
    {

        public string Comment(IWebDriver driver)
        {



            var comment = driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div[2]/div[1]/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/p"));        //定位评论
            var Com = comment.Text;
            return Com;
        }
        public OldPurchasePage Write_Comment(IWebDriver driver, String comment)
        {
            driver.FindElement(By.XPath("//div/div/form/div[1]/div/div/textarea")).Click();
            driver.FindElement(By.XPath("//div/div/form/div[1]/div/div/textarea")).SendKeys(comment);


            return this;
        }
        public OldPurchasePage Submit_btn(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[2]/div/div/form/div[2]/div/button")).Click();
            return this;

        }
    }
}
