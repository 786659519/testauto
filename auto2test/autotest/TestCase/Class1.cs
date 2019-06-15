using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace autotest.TestCase
{
    public class Class1
    {
        [Fact(DisplayName = "登录失败2")]
        [Description("输入错误的密码，登录失败")]
        public void Login_Failure()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");  //加载web驱动
            driver.Url = "https://app.360scm.com/scm.cloud.web/login";
            driver.Manage().Window.Maximize();
            var fail = driver.FindElement(By.XPath("//*[@id='login']/div[2]/div/div[6]/a[5]"));        //登录页忘记密码元素对象的定位   返回忘记密码的字符串
            string failq = fail.Text;
                       //断言Login页的某元素Text   
                                                            //   _output.WriteLine("网页标题是:" + fails);
            Assert.Equal("找回密码", failq);
                                  //退出浏览器
        }
    }
}
