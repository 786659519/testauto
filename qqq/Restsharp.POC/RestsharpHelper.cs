using RestSharp;


/*namespace RestSharp_2
{
    public class RestsharpHelper
    {
        public string baseUrl;         //基地址


        public IRestClient client;    //请求客户端


        public string relativeUrl;   //相对地址


        public IRestRequest request;   // 请求


        public IRestResponse response ;    //响应


        public RestsharpHelper (string baseUrl)                      //基地址封装
        {
            this.baseUrl = baseUrl;
            var client = new RestClient(this.baseUrl);
        }


        public RestsharpHelper Get(string relativeUrl, Method GET)           //get
        {

            this.relativeUrl = relativeUrl;
            var requestPost = new RestRequest(this.relativeUrl, Method.GET);
        }
        public RestsharpHelper(string relativeUrl, Method POST)                //post
        {                   

            this.relativeUrl = relativeUrl;
            var requestPost = new RestRequest(this.relativeUrl, Method.POST);
        }

        public RestsharpHelper(string relativeUrl, Method PUT)               //put
        { 

            this.relativeUrl = relativeUrl;
            var requestPost = new RestRequest(this.relativeUrl, Method.PUT);
        }

        public RestsharpHelper(string relativeUrl, Method.DELETE)            //delete
        {

            this.relativeUrl = relativeUrl;
            var requestPost = new RestRequest(this.relativeUrl, Method.DELETE);
        }

        public IRestResponse Execute(IRestRequest request)                    //执行请求封装
        {
            var response = client.Execute(request);
           

            return response;
        }





    }
}  */
namespace RestSharp_2
{
    public class RestApi<T> where T: new()
    {


        public T Get(string url, object pars)
        {
            var type = Method.GET;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Post(string url, object pars)
        {
            var type = Method.POST;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Delete(string url, object pars)
        {
            var type = Method.DELETE;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Put(string url, object pars)
        {
            var type = Method.PUT;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
 
        private static IRestResponse<T> GetApiInfo(string url, object pars, Method type)
        {
            var request = new RestRequest(type); 
            if (pars != null)
                request.AddObject(pars);
            var client = new RestClient(url);
            client.CookieContainer = new System.Net.CookieContainer();
            IRestResponse<T>reval = client.Execute<T>(request);
         
            return  reval;
        }
    }
} 
