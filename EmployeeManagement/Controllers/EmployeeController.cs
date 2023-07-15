using EmployeeManagement.Contracts;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IStandardHttpClient _httpClient;
        private readonly IConfiguration _config;

        private string GetEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetEmployeeMethod"); } }
        public EmployeeController(IStandardHttpClient standardHttpClient, IConfiguration config)
        {
            _httpClient = standardHttpClient;
            _config = config;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id )
        {
            var request = new GetEmployeeRQ()
            {
                Id = id
            };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<Employee>(GetEmployeeMethod, request));
            var emp = task.Result;
            return View(emp);
        }
    }
}
