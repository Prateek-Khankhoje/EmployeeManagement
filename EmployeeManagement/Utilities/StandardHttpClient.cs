using System.Text.Json;

namespace EmployeeManagement.Utilities
{
    public class StandardHttpClient : IStandardHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly System.Net.Http.HttpClient _httpClient;

        public StandardHttpClient(IHttpClientFactory httpClientFactory, IConfiguration config) {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_config.GetValue<string>("EmployeeDataAccessService:BaseURL"));
        }

        public async Task<T> HttpGetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if(response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.NoContent) {
                throw new Exception($"Invalid response from endpoint '{url}' with response code '{response.StatusCode}'");
            }

            var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            return resultObject;
        }

        public async Task<T> HttpPostAsync<T>(string url, Object postData)
        {
            var requestMessage= new HttpRequestMessage(HttpMethod.Post, url);
            var requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(postData);

            requestMessage.Content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Invalid response from endpoint '{url}' with response code '{response.StatusCode}'");
            }
            var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            return resultObject;
        }
    }
}
