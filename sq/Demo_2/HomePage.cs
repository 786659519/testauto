using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_2
{
    class HomePage
    {


        public void Switch(IWebDriver driver)
        {


            //Actions action = new Actions(driver);
            //action.KeyDown(Keys.Control).SendKeys("w").KeyUp(Keys.Control).KeyUp("w").Perform();
            /* ITargetLocator locator = driver.SwitchTo();
             driver=locator.Window("科箭Power SCM云平台");
             driver.Quit();*/
            var oldWinHandle = driver.CurrentWindowHandle;
            foreach (var winHandle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(winHandle);
                if (driver.Title.Contains("科箭Power SCM云平台"))
                {
                    break;
                }
            }

        }              //////根据标题获取句柄

        public void click_purchase_order(IWebDriver driver)
        {

            driver.SwitchTo().Frame("iframeApp");
            //driver.FindElement(By.XPath("//div[@id="daodream - launcher"]/div[1]")).Click();
            driver.FindElement(By.XPath("//div/div[1]/div[1]/ul[2]/li/div")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[2]/ul/div[2]/li/a")).Click();
            Thread.Sleep(5000);

        }

    }
}
