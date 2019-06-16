using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace RestSharp_1
{


    /// <summary>
    /// Restsharp
    /// </summary>

            
        //封装方法，封装RestHelper

    public class Demo_Restsharp
    {
        public ITestOutputHelper _output;              
        public ITestOutputHelper Output { get { return this._output; } }
        public Demo_Restsharp(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// 测试用例
        /// </summary>  
        [Fact]
        public void Test_For_RestsharpDemo01()
        {
            
            RestResponseCookie cookie = Login();//登陆获取cookie
            string token = GetToken(cookie);//通过cookie获取token
            string id = CreateShippingOrder(token);//新建OMS出库订单
         //   QueryShippingOrder(cookie);//查询WMS出库订单
            QueryOrder(token);   //查询OMS出库订单
        }
        ///
        public RestResponseCookie Login()
        {
            IRestHelper rest = new IRestHelper();
            var client= rest.AddUrl("http://app.360scm.com/SCM.Cloud.Web");
                                                    

           
            client.CookieContainer = new CookieContainer();//存储cookie1

            var requestPost = rest.RequestPost("/Login/Login");

                            

            rest.AddPostHeaderx(requestPost);
         
            requestPost.AddParameter("userid", "autotest");
            requestPost.AddParameter("password", "1c5f4612b9c19b343c89e896298efb32");

            IRestResponse response = client.Execute(requestPost);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);//判断响应码

            var cookie = response.Cookies.First(x => x.Name == "SSID");//获取cookie        r3ofvovmquvzqjine2sbfkgg
            return cookie;
        }

        private string GetToken(RestResponseCookie cookie)
        {


            IRestHelper rest = new IRestHelper();
            //var client = new RestClient("http://testxaoms.360scm.com:81/api");
            var client = rest.AddUrl("https://oms2.360scm.com/api");
            var newCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);//将登陆获取的cookie赋值给new出来的新cookie
            client.CookieContainer = new CookieContainer(); //存储cookie
            client.CookieContainer.Add(newCookie);//存储新cookie

           // var requestPost = new RestRequest("/SCMBaseService/GetTokenAndRightBySsid", Method.POST);
            var requestPost = rest.RequestPost("/SCMBaseService/GetTokenAndRightBySsid");
            rest.AddPostHeaderjson(requestPost);
            //requestPost.AddHeader("Content-Type", "application/json;charset=UTF-8");
            requestPost.AddParameter("login", "{\"v\":{\"ssid\":null,\"SysId\":\"OMS7\"},\"lg\":\"zh_cn\",\"tk\":null}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPost);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
           
            string contents = response.Content;//获取响应内容
            JObject jo = (JObject)JsonConvert.DeserializeObject(contents);//Json字符串转Json对象
            string v = jo["v"].ToString();//获取Json对象中“v”的数据
            JObject viewModel = (JObject)JsonConvert.DeserializeObject(v);
            string token = viewModel["Token"].ToString();
            return token;
        }

        private string CreateShippingOrder(string token)
        {
            // var client = new RestClient("http://testxaoms.360scm.com:81/api/");
            IRestHelper rest = new IRestHelper();
            var client = rest.AddUrl("https://oms2.360scm.com/api/");
            // var requestPost = new RestRequest("SCMOMSService/SaveShipping", Method.POST);
            var requestPost = rest.RequestPost("SCMOMSService/SaveShipping");
            rest.AddPostHeaderjson(requestPost);
            //requestPost.AddHeader("Content-Type", "application/json;charset=UTF-8");
            requestPost.AddParameter("login", "{\"v\":{\"isEdit\":false,\"ShippingArgs\":{\"ExternalOrderId\":\"123456\",\"WorkTypeSc\":\"W\",\"OrderFromSc\":\"Hand\",\"OrderTypeSc\":\"10\",\"WhId\":\"wh1\",\"WhName\":\"西安仓\",\"CustomerId\":\"自动化测试客户\",\"CustomerName\":\"自动化测试客户-勿删\",\"OwnerId\":\"自动化测试货主\",\"OwnerName\":\"自动化测试货主-勿删\",\"OrderDate\":\"2018-09-20 15:21:28\",\"DomainName\":\"PUBLIC\",\"CustomerGid\":\"autotest.PUBLIC.自动化测试客户\",\"OwnerGid\":\"autotest.PUBLIC.自动化测试货主\",\"OrderEquipmentTypes\":[{}],\"OrderPackageDetails\":[{}]}},\"lg\":\"zh_cn\",\"tk\":\"" + token + "\"}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(requestPost);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string contents = response.Content;
            JObject jo = (JObject)JsonConvert.DeserializeObject(contents);
            string v = jo["v"].ToString();
            JObject viewModel = (JObject)JsonConvert.DeserializeObject(v);
            string id = viewModel["ShippingOrderId"].ToString();
            Output.WriteLine("OMS出库订单Id：" + id);
            return id;
        }
        /*private void QueryShippingOrder(RestResponseCookie cookie)
        {

            IRestHelper rest = new IRestHelper();
            var client = rest.AddUrl("http://testxa.360scm.com/SCM.WMS7.WebUI/");
            //var client = new RestClient("http://testxa.360scm.com/SCM.WMS7.WebUI/");
            var newCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
            client.CookieContainer = new CookieContainer();
            client.CookieContainer.Add(newCookie);


            var requestPost = rest.RequestPost("ShippingOrder/GetQueryModeList");
            //var requestPost = new RestRequest("ShippingOrder/GetQueryModeList", Method.POST);
            requestPost.AddUrlSegment("defsort", "SHIPPING_ORDER_ID%20DESC");
             rest.AddPostHeaderx(requestPost);
            //requestPost.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            //requestPost.AddHeader("Referer", "http://testxa.360scm.com");
            requestPost.AddHeader("Referer", "http://testxa.360scm.com/SCM.WMS7.WebUI/ShippingOrder/List");
            requestPost.AddParameter("login", "igt=Y&page=1&rows=1&filters=%7B%22groupOp%22%3A%22AND%22%2C%22rules%22%3A%5B%7B%22field%22%3A%22SHIPPING_ORDER_ID%22%2C%22op%22%3A%22eq%22%2C%22data%22%3A%22180920000005%22%7D%5D%7D", ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPost);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string contents = response.Content;
            JObject jo = (JObject)JsonConvert.DeserializeObject(contents);
            string rows = jo["rows"].ToString();
            JArray ja = (JArray)JsonConvert.DeserializeObject(rows);//Json字符串数组转Json对象数组
            string id = ja[0]["id"].ToString();
            Assert.Equal("180920000005", id);
        }
        //SH-190508000121*/
        private void QueryOrder(string token) {



            var client = new RestClient("https://oms2.360scm.com/api/");


            /*var newCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
            client.CookieContainer = new CookieContainer();
            client.CookieContainer.Add(newCookie);
            */

            var requestPost = new RestRequest("SCMOMSService/GetShippingList", Method.POST);

            requestPost.AddHeader("Content-Type", "application/json;charset=UTF-8");

          //  requestPost.AddParameter("login", "{\"v\":{\"QueryModel\":{\"Items\":[{\"Field\":\"ShippingOrderId\",\"Method\":\"Contains\",\"Value\":\"190515000043\",\"OrGroup\":\"ShippingOrderId\"},{\"Field\":\"CreatedDate\",\"Method\":\"GreaterThanOrEqual\",\"Value\":\"2019 - 02 - 09 09:13:02\"},{\"Field\":\"CreatedDate\",\"Method\":\"LessThanOrEqual\",\"Value\":\"2019 - 05 - 11 09:13:02\"}]},\"PageInfo\":{\"CurrentPage\":1,\"PageSize\":20,\"SortField\":\"CreatedDate\",\"SortDirection\":\"DESC\",\"IsPaging\":true,\"IsGetTotalCount\":false}},\"lg\":\"zh_cn\",\"tk\":\"" + token + "\"}", ParameterType.RequestBody);
              requestPost.AddParameter("login", "{\"v\":{\"QueryModel\":{\"Items\":[{\"Field\":\"ShippingOrderId\",\"Method\":\"Contains\",\"Value\":\"190515000043\",\"OrGroup\":\"ShippingOrderId\"},{\"Field\":\"CreatedDate\",\"Method\":\"GreaterThanOrEqual\",\"Value\":\"2019 - 02 - 14 10:37:16\"},{\"Field\":\"CreatedDate\",\"Method\":\"LessThanOrEqual\",\"Value\":\"2019 - 05 - 16 10:37:16\"}]},\"PageInfo\":{\"CurrentPage\":1,\"PageSize\":20,\"SortField\":\"CreatedDate\",\"SortDirection\":\"DESC\",\"IsPaging\":true,\"IsGetTotalCount\":false}},\"lg\":\"zh_cn\",\"tk\":\"" + token + "\"}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(requestPost);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           /* string contents = response.Content;
            JObject jo = (JObject)JsonConvert.DeserializeObject(contents);
            string v = jo["v"].ToString();             /////错误
            JObject Ids = (JObject)JsonConvert.DeserializeObject(v);
            string lv = Ids["ListValue"].ToString();
            JArray lvo = (JArray)JsonConvert.DeserializeObject(lv);
            string id = lvo[0]["ShippingOrderId"].ToString();*/
            string contents = response.Content;
            JObject jo = (JObject)JsonConvert.DeserializeObject(contents); //Json字符串转Json对象
            string v = jo["v"].ToString();        //获取Json对象中“v”的数据
            JObject Ids = (JObject)JsonConvert.DeserializeObject(v);
            string ListValue = Ids["ListValue"].ToString();  //获取Json对象v中“ListValue”的数据
            JArray ja = (JArray)JsonConvert.DeserializeObject(ListValue);
            string id = ja[0]["ShippingOrderId"].ToString();
            Assert.Equal("190515000043", id);
        }

    }
}
