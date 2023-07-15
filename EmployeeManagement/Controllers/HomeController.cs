using EmployeeManagement.Contracts;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        private string GetAllEmployeesMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetAllEmployeesMethod"); } }
        public HomeController(StandardHttpClientHelper httpClientHelper, IConfiguration config)
        {
            _httpClient = httpClientHelper.httpClient;
            _config = config;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(GetAllEmployeesMethod);
            string str = await response.Content.ReadAsStringAsync();
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(str);
            return View(model);
        }

        
    }
}
