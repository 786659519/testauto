
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Demo_2
{
    public class BaiduPage 
    {

        public String search_bar_id = "kw";
        public String search_box_id = "kw";
        public String search_button_name = "wd";







        public void click_Search_Bar(IWebDriver driver)
        {
            driver.FindElement(By.Id(search_bar_id)).Click();
           
        }   //点击搜索栏

        public void input_Search_Box(IWebDriver driver, String key_word)
        {
            driver.FindElement(By.Id(search_box_id)).Clear();
            driver.FindElement(By.Id(search_box_id)).SendKeys(key_word);
           
        } //搜索框输入



        public void click_Search_Button(IWebDriver driver)
        {
            driver.FindElement(By.Name(search_button_name)).Click();
            
        }
        //点击百度一下

      /*  public String Title2(IWebDriver driver) {

            return driver.Title;
        }*/
        
























    }
}
