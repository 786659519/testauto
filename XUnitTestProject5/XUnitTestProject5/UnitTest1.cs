using System;
using Xunit;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text;
using System.IO;
using Xunit.Abstractions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json; 
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;


namespace XUnitTestProject5
{
    public class UnitTest1
    {

        private ITestOutputHelper _output;
        public ITestOutputHelper Output { get { return this._output; } }
        public UnitTest1 (ITestOutputHelper output)
        {
            this._output = output;
        }
    
       


        [Fact(DisplayName = "apitest1")]
        public void Test1()
        {

            var client = new RestClient("http://wcf.open.cnblogs.com/blog");
            var request = new RestRequest("48HoursTopViewPosts/2", Method.GET);

            IRestResponse response = client.Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //IRestResponse 接口中包含了所有远程服务返回的信息，可以访问头信息（header）数据内容（content）、HTTP状态等。

        }
        [Fact(DisplayName = "apitest2")]
        public void Test2() {

            var client = new RestClient("http://wcf.open.cnblogs.com/blog");
            var request = new RestRequest("bloggers/recommend/2/10",Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }
        [Fact(DisplayName = "apitest3")]
        public void Test3()
        {
            var client = new RestClient("https://gank.io/api");
            var request = new RestRequest("/add2gank", Method.POST);
            request.AddParameter("url", "https://gank.io/api/add2gank");
            request.AddParameter("desc", " 搜索");
            request.AddParameter("who", "10086");
            request.AddParameter("type", "Android");
            request.AddParameter("debug", "true");
            IRestResponse response = client.Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        /* string contents = response.Content;//获取响应内容
         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
         JObject jo = (JObject)JsonConvert.DeserializeObject(contents);
         Output.WriteLine("响应内容为：" + jo);
         Assert.Equal("老大, 所有提交数据一切正常!","msg");*/
        /// </summary>

        [Fact(DisplayName = "selenium01")]
        public void CheckNavBar_GetElements()
        {
            _output.WriteLine("Step 00 : 准备测试数据。");
            var testDatas = new List<string>() { "首页", "精华", "候选", "新闻" };      //准备测试数据

            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkNavList = driver.FindElements(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));

            _output.WriteLine("Step 03 : 检查导航条文字信息。");
            for (var i = 0; i < lnkNavList.Count; i++)
            {
                Assert.Equal<string>(testDatas[i], lnkNavList[i].Text);
            }
            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }
        [Fact(DisplayName = "selenium02")]    //测试名称
        public void CheckNavBar_GetElement()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkHome = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));
            var lnkEssence = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[2]/a"));
            var lnkCandidate = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[3]/a"));
            var lnkNews = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[4]/a"));

            _output.WriteLine("Step 03 : 检查导航条文字信息。");
            Assert.Equal<string>("首页", lnkHome.Text);
            Assert.Equal<string>("精华", lnkEssence.Text);            //判断字符串是否相等。
            Assert.Equal<string>("候选", lnkCandidate.Text);
            Assert.Equal<string>("新闻", lnkNews.Text);

            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }


    }

}


    
       


           
        





