using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo_2
{
    class NewPurchasePage
    {
        


        public NewPurchasePage click_supplier(IWebDriver driver)
        {

            driver.FindElement(By.XPath("//div/div[3]/div[2]/div[1]/div/div/div[1]/div[2]/div[11]/div[2]/div/input")).Click();
            return this;
        }   //点击供应商代码
        public NewPurchasePage input_supplier(IWebDriver driver, String key_word)
        {

            driver.FindElement(By.XPath("//div/div[3]/div[2]/div[1]/div/div/div[1]/div[2]/div[11]/div[2]/div/input")).SendKeys(key_word);
            // driver.FindElement(By.Id(username)).SendKeys(key_word);

            return this;

        } //输入供应商代码

        public void Save_order(IWebDriver driver) {

            driver.FindElement(By.XPath("//div/div[3]/div[1]/div[2]/button[2]")).Click();

        } //保存采购订单

        public NewPurchasePage Delete_order(IWebDriver driver) {

            driver.FindElement(By.XPath("//div/div[3]/div[1]/div[2]/button[3]/span")).Click();

            return this;
        }
        public void Confirm_delete(IWebDriver driver) {
            driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[2]")).Click();
        }
       /* public NewPurchasePage Write_Comment(IWebDriver driver,String comment) {
            driver.FindElement(By.XPath("//div/div/form/div[1]/div/div/textarea")).Click();
            driver.FindElement(By.XPath("//div/div/form/div[1]/div/div/textarea")).SendKeys(comment);


            return this;
        }
        public NewPurchasePage Submit_btn(IWebDriver driver) {
            driver.FindElement(By.XPath("//div[2]/div/div/form/div[2]/div/button")).Click();
            return this;

        }*/
       
       
 
    }
}
