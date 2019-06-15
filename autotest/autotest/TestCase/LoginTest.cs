using System;
using Xunit;
using OpenQA.Selenium;
using System.ComponentModel;
using autotest.Common;
using autotest.PageObject;
using System.Threading;
using Xunit.Abstractions;

namespace autotest

{

   



        public class LoginTest
        {
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public LoginTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        [Fact(DisplayName = "登录成功")]
            [Description("输入正确的密码，登录成功")]
            public void Login_Success()
            {
                Browser browser = new Browser();
                IWebDriver driver = browser.Start();
                LoginPage login = new LoginPage(driver);
                HomePage home = new HomePage(driver);
                login.InputUsername("autotest")                      //输入账号
                     .InputPassword("admin")                          //输入密码
                     .SubmitLogin();                                  //点击登录
                   home.Switch();
            String suc = home.Success();
          //  _output.WriteLine("网页标题是:" + suc);
            Assert.Equal("欢迎使用 OMS订单管理系统！", suc);
          
             //browser.Quit();                            //断言主页面 某元素的text
        }



            [Fact(DisplayName = "登录失败")]
            [Description("输入错误的密码，登录失败")]
            public void Login_Failure()
            {
                Browser browser = new Browser();
                IWebDriver driver = browser.Start();
                LoginPage login = new LoginPage(driver);
                login.InputUsername("autote2s")
                     .InputPassword("123")
                     .SubmitLoginExpectingFailure();
                String fails = login.Login_Fail();              //断言Login页的某元素Text                                                    
              Assert.Equal("找回密码", fails);
                // browser.Quit();                         //退出浏览器
            }
        }





    }


