using System;
using Xunit;
using OpenQA.Selenium;
using System.ComponentModel;
using autotest.Common;
using autotest.PageObject;

namespace autotest

{
      public class LoginTest
    {
        [Fact(DisplayName = "��¼�ɹ�")]
        [Description("������ȷ�����룬��¼�ɹ�")]
        public void Login_Success()
        {
            Browser browser = new Browser();
            IWebDriver driver = browser.Start();
            LoginPage login = new LoginPage(driver);
            HomePage home = new HomePage(driver);
            login.InputUsername("autotest")
                 .InputPassword("admin")
                 .SubmitLogin();
            var suc = home.Success();
            Assert.Equal("��ӭʹ�� OMS��������ϵͳ��", suc);
            browser.Quit();                            //������ҳ�� ĳԪ�ص�text
        }



        [Fact(DisplayName = "��¼ʧ��")]
        [Description("�����������룬��¼ʧ��")]
        public void Login_Failure()
        {
            Browser browser = new Browser();
            IWebDriver driver = browser.Start();
            LoginPage login = new LoginPage(driver);
            login.InputUsername("autote2s")
                 .InputPassword("123")
                 .SubmitLoginExpectingFailure();
             String fails = login.Login_Fail();              //����Loginҳ��ĳԪ��Text   
             //   _output.WriteLine("��ҳ������:" + fails);
             Assert.Equal("�һ�����", fails);
             browser.Quit();                         //�˳������
        }
    }







}
