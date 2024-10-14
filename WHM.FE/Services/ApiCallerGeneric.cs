using System.Text;
using System.Text.Json;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Services
{
    public class ApiCallerGeneric : IApiCallerGeneric
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiCallerGeneric(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetApiData<T>(string url, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var dataObjects = JsonSerializer.Deserialize<T>(data, options);

                return dataObjects;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            return default(T?);
        }


        /// <summary>
        /// From body request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestObject"></param>
        /// <param name="apiFactoryName"></param>
        /// <returns></returns>
        public async Task<bool> PostApi<T>(string url, T requestObject, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            if (requestObject is null)
            {
                return false;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var objectSerialize = JsonSerializer.Serialize<T>(requestObject, options);

            var content = new StringContent(objectSerialize, encoding: Encoding.UTF8,
                                    "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                //var responseStream = await response.Content.ReadAsStreamAsync();
                //StreamReader streamReader = new StreamReader(responseStream);
                //string data = await streamReader.ReadToEndAsync();

                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }

        public async Task<TOut?> PostApi<T, TOut>(string url, T requestObject, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            if (requestObject is null)
            {
                return default(TOut);
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var objectSerialize = JsonSerializer.Serialize<T>(requestObject, options);

            var content = new StringContent(objectSerialize, encoding: Encoding.UTF8,
                                    "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var dataObjects = JsonSerializer.Deserialize<TOut>(data, options);

                return dataObjects;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return default(TOut);
        }

        /// <summary>
        /// From form request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formContent"></param>
        /// <param name="apiFactoryName"></param>
        /// <returns></returns>
        public async Task<bool> PostApiFormData(string url, FormUrlEncodedContent formContent, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            if (formContent is null)
            {
                return false;
            }

            HttpResponseMessage response = await client.PostAsync(url, formContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }

        public async Task<bool> PutData<T>(string url, T objectRequest, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            if (objectRequest is null)
            {
                return false;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var objectSerialize = JsonSerializer.Serialize<T>(objectRequest, options);

            var content = new StringContent(objectSerialize, encoding: Encoding.UTF8,
                                    "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }

        public async Task<bool> DeleteData<T>(string url, string apiFactoryName)
        {
            HttpClient client = _httpClientFactory.CreateClient(apiFactoryName);

            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }
    }
}
