using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;

namespace Client.Services
{

    public class HttpClientExtensions : HttpClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _memoryCache;

        public HttpClientExtensions(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }


        private async Task<HttpResponseMessage> ConfigRequest(HttpMethod httpMethod, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _memoryCache.Get<string>("token"));
            var client = _clientFactory.CreateClient("Resources");
            return await client.SendAsync(request);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await ConfigRequest(HttpMethod.Get, url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
          
            else
            {
                Console.WriteLine(@$"Response unavailable at url: {url}");
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(serializedData);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _memoryCache.Get<string>("token"));
            var client = _clientFactory.CreateClient("Resources");
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            else
            {
                Console.WriteLine(@$"Response unavailable at url: {url}");
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Content = new StringContent(serializedData);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _memoryCache.Get<string>("token"));
            var client = _clientFactory.CreateClient("Resources");
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            else
            {
                Console.WriteLine(@$"Response unavailable at url: {url}");
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }

        public async Task<T> DeleteAsync<T>(string url, object data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(serializedData);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _memoryCache.Get<string>("token"));
            var client = _clientFactory.CreateClient("Resources");
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            else
            {
                Console.WriteLine(@$"Response unavailable at url: {url}");
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }
    }
}