using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_2
{
   public class PurchasePage
    {
       
        public void click_neworder(IWebDriver driver)
        {

            //driver.SwitchTo().Frame("iframeApp");
            //driver.FindElement(By.XPath("//div[@id="daodream - launcher"]/div[1]")).Click();
            driver.FindElement(By.XPath("//div/div[3]/div[1]/div[1]/div[2]/button[2]")).Click();
            Thread.Sleep(3000);
        }
       public string Save_success(IWebDriver driver) {



            var Save_success = driver.FindElement(By.XPath("/html/body/div[4]/div/h2"));           //保存成功
            var save_1 = Save_success.Text;
            return save_1;
        }


        /*public string Comment(IWebDriver driver)
        {



            var comment = driver.FindElement(By.XPath("//*[@id='app']/div/div[3]/div[2]/div[1]/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/p"));        //定位评论
            var Com = comment.Text;
            return Com;
        }*/


        public string Delete(IWebDriver driver)
       {



           var delete= driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/p"));        //删除
           var Del = delete.Text;
           return Del;
       }






    }
}
