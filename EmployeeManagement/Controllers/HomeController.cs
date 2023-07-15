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

        #region Configs
        private string GetAllEmployeesMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetAllEmployeesMethod"); } }
        private string SearchEmployeesMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:SearchEmployeesMethod"); } }
        #endregion
        public HomeController(IStandardHttpClient standardHttpClient, IConfiguration config)
        {
            _httpClient = standardHttpClient;
            _config = config;
        }
        
        public IActionResult Index(string search) {
            var request = new SearchEmployeeRQ()
            {
                SearchCriteria = search
            };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<List<Employee>>(SearchEmployeesMethod, request));
            var model = task.Result;
            return View(model);
        }
    }
}
