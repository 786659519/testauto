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

            //IRestResponse �ӿ��а���������Զ�̷��񷵻ص���Ϣ�����Է���ͷ��Ϣ��header���������ݣ�content����HTTP״̬�ȡ�

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
            request.AddParameter("desc", " ����");
            request.AddParameter("who", "10086");
            request.AddParameter("type", "Android");
            request.AddParameter("debug", "true");
            IRestResponse response = client.Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        /* string contents = response.Content;//��ȡ��Ӧ����
         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
         JObject jo = (JObject)JsonConvert.DeserializeObject(contents);
         Output.WriteLine("��Ӧ����Ϊ��" + jo);
         Assert.Equal("�ϴ�, �����ύ����һ������!","msg");*/
        /// </summary>

        [Fact(DisplayName = "selenium01")]
        public void CheckNavBar_GetElements()
        {
            _output.WriteLine("Step 00 : ׼���������ݡ�");
            var testDatas = new List<string>() { "��ҳ", "����", "��ѡ", "����" };      //׼����������

            _output.WriteLine("Step 01 : ������������򿪲���԰��ҳ��");
            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : Ѱ����Ҫ����ҳ��Ԫ�ء�");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkNavList = driver.FindElements(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));

            _output.WriteLine("Step 03 : ��鵼����������Ϣ��");
            for (var i = 0; i < lnkNavList.Count; i++)
            {
                Assert.Equal<string>(testDatas[i], lnkNavList[i].Text);
            }
            _output.WriteLine("Step 04 : �ر��������");
            driver.Close();
        }
        [Fact(DisplayName = "selenium02")]    //��������
        public void CheckNavBar_GetElement()
        {
            _output.WriteLine("Step 01 : ������������򿪲���԰��ҳ��");
            IWebDriver driver = new ChromeDriver(@"C:\Users\asus\Desktop\chromedriver_win32");
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : Ѱ����Ҫ����ҳ��Ԫ�ء�");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkHome = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));
            var lnkEssence = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[2]/a"));
            var lnkCandidate = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[3]/a"));
            var lnkNews = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[4]/a"));

            _output.WriteLine("Step 03 : ��鵼����������Ϣ��");
            Assert.Equal<string>("��ҳ", lnkHome.Text);
            Assert.Equal<string>("����", lnkEssence.Text);            //�ж��ַ����Ƿ���ȡ�
            Assert.Equal<string>("��ѡ", lnkCandidate.Text);
            Assert.Equal<string>("����", lnkNews.Text);

            _output.WriteLine("Step 04 : �ر��������");
            driver.Close();
        }


    }

}


    
       


           
        





