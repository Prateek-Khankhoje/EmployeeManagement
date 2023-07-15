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
        private readonly IStandardHttpClient _httpClient;
        private readonly IConfiguration _config;

        private string GetAllEmployeesMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetAllEmployeesMethod"); } }
        public HomeController(IStandardHttpClient standardHttpClient, IConfiguration config)
        {
            _httpClient = standardHttpClient;
            _config = config;
        }
        public IActionResult Index()
        {
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpGetAsync<List<Employee>>(GetAllEmployeesMethod));
            var model = task.Result;
            return View(model);
        }

        
    }
}
