using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2
{
   public class LoginPage 
    {
       // public string success = "货品模块增加虚拟货品字段";
        public string username = "USER_ID";
        public string password = "USER_PASS";
        public string loginbtn = "login_button";

        public LoginPage click_user(IWebDriver driver)
        {
            driver.FindElement(By.Id(username)).Click();
            return this;
        }   //点击用户名

        public LoginPage input_user(IWebDriver driver, String key_word)
        {
            driver.FindElement(By.Id(username)).Clear();
            driver.FindElement(By.Id(username)).SendKeys(key_word);

            return this;

        } //用户名输入账号

        public LoginPage click_pass(IWebDriver driver)
        {
            driver.FindElement(By.Id(password)).Click();
            return this;
        } //点击密码

        public LoginPage input_pass(IWebDriver driver, String key_word)
        {
            driver.FindElement(By.Id(password)).Clear();
            driver.FindElement(By.Id(password)).SendKeys(key_word);
            return this;
        } //输入密码
        public LoginPage click_loginbtn(IWebDriver driver)
        {
            driver.FindElement(By.Id(loginbtn)).Click();
            return this;
        } //登录



        //获取网页标题
       public String title(IWebDriver driver)
        {

            return driver.Title;
        }
        


    }
}
