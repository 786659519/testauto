using System;
using System.Linq;
using Xunit;
using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit.Abstractions;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Demo_2
{
   



    public class selenium_test {

        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public selenium_test (ITestOutputHelper output)
        {
            this._output = output;
        }

       

        [Fact(DisplayName = "login")]
        public void Login() {

            IWebDriver drivers;
            Browser browser = new Browser();
            LoginPage login = new LoginPage();
            HomePage home = new HomePage();
            PurchasePage PurchasePage = new PurchasePage();
            NewPurchasePage Purchase = new NewPurchasePage();
            OldPurchasePage old = new OldPurchasePage();
            drivers = browser.Start();
          
            var f = login.title(drivers);
            login.click_user(drivers)
            .input_user(drivers, "autotest")
            .click_pass(drivers)
            .input_pass(drivers, "admin")
            .click_loginbtn(drivers);
            _output.WriteLine("网页标题是:" + f);
            //Assert.Equal<string>("科箭Power SCM云平台", f);
             //Assert.True(drivers.PageSource.Contains(login.success));
            Thread.Sleep(3000);
            // browser.Shutdown(drivers);
            home.Switch(drivers);
            Thread.Sleep(3000);
            home.click_purchase_order(drivers);
            PurchasePage.click_neworder(drivers);
            Purchase.click_supplier(drivers)
            .input_supplier(drivers, "自动化测试供应商");
            
            
            Thread.Sleep(1000);



            Purchase.Save_order(drivers);
            Thread.Sleep(2000);



            string save=PurchasePage.Save_success(drivers);
           
            //var Save_success = drivers.FindElement(By.XPath("/html/body/div[4]/div/h2"));
            //  _output.WriteLine("窗口内容:" + Save_success.Text);
            Assert.Equal<string>("成功", save);


           // Thread.Sleep(4000);
            old.Write_Comment(drivers, "自动化测试")
            .Submit_btn(drivers);
            Thread.Sleep(1000);



            // var comment = drivers.FindElement(By.XPath("//*[@id='app']/div/div[3]/div[2]/div[1]/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/p"));

            string comment = old.Comment(drivers);
            Assert.Equal<string>("自动化测试", comment);
            

            

           // var save_success = drivers.FindElement(By.XPath("/html/body/div[6]/div/div[1]/p"));
            // _output.WriteLine("窗口内容:" + Save_success.Text);

            Thread.Sleep(4000);
            Purchase.Delete_order(drivers)
            .Confirm_delete(drivers);
            Thread.Sleep(2000);

            string delete = PurchasePage.Delete(drivers);
             Assert.Equal<string>("删除成功", delete);


            Thread.Sleep(2000);
            browser.Shutdown(drivers);


        }






    }
}
