using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace DigiArticle.Web.Controllers
{
    public class BaseController : Controller
    {
        private static string _webApiUrl;

        public BaseController(IConfiguration configuration)
        {
            if (_webApiUrl == null)
            {
                _webApiUrl = configuration.GetSection("WebApiBaseUri").Value.ToString();
            }
        }

        public HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(_webApiUrl)
            };
        }

        public string CreateRequestUri(string action, string controller = null)
        {
            return controller == null 
                ? $"{this.ControllerContext.RouteData.Values["controller"].ToString()}/{action}" 
                : $"{controller}/{action}";
        }

        public T Get<T>(string methodName, string controller = null)
        {
            using (HttpClient _httpClient = CreateHttpClient())
            {
                var requestUri = CreateRequestUri(methodName, controller);
                var response = _httpClient.GetAsync(requestUri).Result;
                return response.Content.ReadAsAsync<T>().Result;
            }
        }

        public T Post<T>(string methodName, object requestData, string controller = null)
        {
            using (HttpClient _httpClient = CreateHttpClient())
            {
                var requestUri = CreateRequestUri(methodName, controller);
                var response = _httpClient.PostAsJsonAsync(requestUri, requestData).Result;
                return response.Content.ReadAsAsync<T>().Result;
            }
        }
    }
}