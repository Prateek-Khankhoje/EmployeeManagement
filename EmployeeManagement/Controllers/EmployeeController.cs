using EmployeeManagement.Contracts;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IStandardHttpClient _httpClient;
        private readonly IConfiguration _config;

        #region Configs
        private string DeleteEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:DeleteEmployeeMethod"); } }
        private string GetEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetEmployeeMethod"); } }
        #endregion
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

        public IActionResult Delete(int id)
        {
            var request = new DeleteEmployeeRQ() { Id = id };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<BaseContractRS>(DeleteEmployeeMethod, request));
            var emp = task.Result;
            return RedirectToAction("Index");
        }
    }
}
