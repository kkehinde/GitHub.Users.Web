using GitHub.Users.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitHub.Users.HttpClient
{
    public class HttpServiceClient : IHttpServiceClient
    {
        private System.Net.Http.HttpClient _httpClient;
        private static readonly object locker = new object();
        private string _githubEndpoint;

        public HttpServiceClient()
        {
            _githubEndpoint = ConfigurationManager.AppSettings["github-users-endpoint"];
            _httpClient = CreateHttpClient(_githubEndpoint);
        }
        private System.Net.Http.HttpClient CreateHttpClient(string baseAddress)
        {
            var httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(baseAddress) };

            var productValue = new ProductInfoHeaderValue("User-Agent", "GitHub.Users.Web");

            httpClient.DefaultRequestHeaders.UserAgent.Add(productValue);
               return httpClient;
        }


        #region public- methods

        public async Task<RawUserData> GetUserEndpoint(string endpoint)
        {
            HttpResponseMessage response = null;
                response = _httpClient.GetAsync(endpoint).Result;


            if (!response.IsSuccessStatusCode)
                throw await CreateRequestException(response);


            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RawUserData>(data);


        }

        public async Task<List<UserRepo>> GetRepoEndpoint(string endpoint)
        {
            HttpResponseMessage response = null;
          
                response = _httpClient.GetAsync(endpoint).Result;

            if (!response.IsSuccessStatusCode)
                throw await CreateRequestException(response);


            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UserRepo>>(data);

        }


        #endregion

        private async Task<HttpRequestException> CreateRequestException(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var exception = new HttpRequestException($"Failed Response from the API: {responseContent}");
            exception.Data.Add("ResponseContent", responseContent);

            return exception;
        }

    }
}
