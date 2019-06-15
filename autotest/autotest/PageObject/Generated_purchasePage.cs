using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;

namespace autotest.PageObject
{
    public class Generated_purchasePage
    {
        private IWebDriver driver;

        public Generated_purchasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By commit = By.XPath("//div/div/form/div[1]/div/div/textarea");            //通过xpath定位评论输入框
        By Submit_commit = By.XPath("//div[2]/div/div/form/div[2]/div/button");    //定位提交评论按钮
        By generated_commit = By.XPath("//*[@id='app']/div/div[3]/div[2]/div[1]/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/p"); //定位生成的评论位置
        By delete_order = By.XPath("//div/div[3]/div[1]/div[2]/button[3]/span"); //定位删除按钮
        By confirm_delete = By.XPath("/html/body/div[4]/div/div[3]/button[2]");//定位确认删除按钮
        

        public void InputCommit(string commits)                  //编写评论
        {
            driver.FindElement(By.XPath("//div/div/form/div[1]/div/div/textarea")).Click();
            driver.FindElement(commit).SendKeys(commits);
           
        }

        public Generated_purchasePage Submit()                                    //提交评论
        {

            driver.FindElement(Submit_commit).Click();                                     
            return this;
        }

        public string Comment()
        {
            var comment = driver.FindElement(generated_commit);                 //返回评论内容
            var Com = comment.Text;
            return Com;
        }

        public void Delete_order() {                                     //删除订单
            Thread.Sleep(2000);
            driver.FindElement(delete_order).Click();
            driver.FindElement(confirm_delete).Click();
            
        }
       
    }
}
