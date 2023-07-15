using System.Text.Json;

namespace EmployeeManagement.Utilities
{
    public class StandardHttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        public readonly System.Net.Http.HttpClient httpClient;

        public StandardHttpClientHelper(IHttpClientFactory httpClientFactory, IConfiguration config) {
            _httpClientFactory = httpClientFactory;
            _config = config;
            httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_config.GetValue<string>("EmployeeDataAccessService:BaseURL"));
        }
    }
}
