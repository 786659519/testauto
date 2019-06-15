using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestSharp_1

{
  public  class IRestHelper
    {
        public string baseUrl;   //基地址 服务器地址

        public string resource;  //接口路径

        public string name;     //header.参数  名称 

       // public object value;

        public RestClient AddUrl(string baseUrl) {

            var client = new RestClient(baseUrl);

            return client;
        }
        public void SaveCookie(RestClient client) {                             //存储cookie

            client.CookieContainer = new CookieContainer();

            
        }


        public RestRequest RequestPost(string resource) {

            var requestPost = new RestRequest(resource, Method.POST);       //post
            return requestPost;
        }

        public RestRequest RequestGet(string resource)
        {

            var requestGet = new RestRequest(resource, Method.GET);      //get 
            return requestGet;
        }

        public RestRequest RequestPut(string resource)
        {
            
            var requestPut = new RestRequest(resource, Method.PUT);      //put
            return requestPut;
        }

        public RestRequest RequestDelete(string resource)
        {

            var requestDelete = new RestRequest(resource, Method.DELETE);      //delete
            return requestDelete;
        }

       public IRestHelper AddPostHeaderx(RestRequest requestPost) {

            requestPost.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            return this;
        }
        public IRestHelper AddGetHeaderx(RestRequest requestGet)
        {

            requestGet.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            return this;
        }
        public IRestHelper AddPutHeaderx(RestRequest requestPut)
        {

            requestPut.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            return this;
        }
        public IRestHelper AddDeleteHeaderx(RestRequest requestDelete)
        {

            requestDelete.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            return this;
        }

        public IRestHelper AddPostHeaderjson(RestRequest requestPost)
        {

            requestPost.AddHeader("Content-Type", "application/json;charset=UTF-8");
            return this;
        }
        public IRestHelper AddGetHeaderjson(RestRequest requestGet)
        {

            requestGet.AddHeader("Content-Type", "application/json;charset=UTF-8");
            return this;
        }
        public IRestHelper AddPutHeaderjson(RestRequest requestPut)
        {

            requestPut.AddHeader("Content-Type", "application/json;charset=UTF-8");
            return this;
        }
        public IRestHelper AddDeleteHeaderjson(RestRequest requestDelete)
        {

            requestDelete.AddHeader("Content-Type", "application/json;charset=UTF-8");
            return this;
        }

      /*  public void AddParameter(RestRequest requestPost, string name, object value) {   //post加参数

            requestPost.AddParameter(name,value);

        }
       /* public void AddParameter(RestRequest requestPost, string name, object value, ParameterType type)
        {   //post加参数

            requestPost.AddParameter(name, value, ParameterType type);
           

        }*/

    }
}
