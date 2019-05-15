using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2
{
   public class Browser
    {

        public IWebDriver driver;




        public IWebDriver Start() {

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://app.360scm.com/scm.cloud.web/login";
            //driver.Url = "http://www.baidu.com";
            driver.Manage().Window.Maximize();
            //System.Threading.Thread.Sleep(10);
            
            return driver;
        }
        public void Shutdown(IWebDriver driver) {

            driver.Quit();
        }
    }
}
