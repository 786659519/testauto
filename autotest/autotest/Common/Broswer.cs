using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace autotest.Common
{
    public class Browser
    {
        public IWebDriver driver;

        public IWebDriver Start()
        {

            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");  //加载web驱动
            driver.Url = "https://app.360scm.com/scm.cloud.web/login";
            driver.Manage().Window.Maximize();
            return  driver;
        }

        public void Max()
        {            //最大化浏览器

            driver.Manage().Window.Maximize();

        }

        public void Close()
        {               //关闭网页

            driver.Close();
        }

        public void Quit()                  //关闭浏览器
        {
            driver.Quit();
        }
        public String Title()
        {
            var a = driver.Title;              //获得网页标题
            return a;
        }
        
    }
}
