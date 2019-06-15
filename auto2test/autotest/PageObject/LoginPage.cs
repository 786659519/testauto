using OpenQA.Selenium;
using System;
using System.Threading;

namespace autotest.PageObject
{
    public class LoginPage
    {

      /*  public string name = "USER_ID";
        public string passwd = "USER_PASS";
        public string login = "login_button";*/
        public IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By usernameLocator = By.Id("USER_ID");              // 用户名
        By passwordLocator = By.Id("USER_PASS");                  //密码
        By loginButtonLocator = By.Id("login_button");                 //登录按钮
        public LoginPage InputUsername(String username)               //输入用户名
        {
            //driver.FindElement(By.Id(username)).Click();
            driver.FindElement(usernameLocator).SendKeys(username);
            //driver.FindElement(By.Id(username)).SendKeys(username);
            return this;
        }
        public LoginPage InputPassword(String password)                 //输入密码
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public HomePage SubmitLogin()                                   //登录成功
        {
            driver.FindElement(loginButtonLocator).Click();
            return new HomePage(driver);
        }
        public void SubmitLoginExpectingFailure()                        //登录失败
        {
            driver.FindElement(loginButtonLocator).Click();

        }
        public HomePage LoginAs(String username, String password)            //登录
        {
            InputUsername(username);
            InputPassword(password);
            return SubmitLogin();
        }
        public String Login_Fail()
        {
            var fail = driver.FindElement(By.XPath("//*[@id='login']/div[2]/div/div[6]/a[5]"));        //登录页忘记密码元素对象的定位   返回忘记密码的字符串
            string failq = fail.Text; 
            return failq;
        }
             
    }
}
