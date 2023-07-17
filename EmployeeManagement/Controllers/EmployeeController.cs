using EmployeeManagement.Contracts;
using EmployeeManagement.Utilities;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IStandardHttpClient _httpClient;
        private readonly IConfiguration _config;

        #region Configs
        private string DeleteEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:DeleteEmployeeMethod"); } }
        private string GetEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:GetEmployeeMethod"); } }
        private string SaveEmployeeMethod { get { return _config.GetValue<string>("EmployeeDataAccessService:SaveEmployeeMethod"); } }
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
            if(id == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var request = new GetEmployeeRQ()
            {
                Id = id
            };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<GetEmployeeRS>(GetEmployeeMethod, request));
            var emp = task.Result.Employee;
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var request = new DeleteEmployeeRQ() { Id = id };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<BaseContractRS>(DeleteEmployeeMethod, request));
            var emp = task.Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new SaveEmployeeRQ()
                {
                    Employee = new Employee()
                    {
                        Id = null,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Age = model.Age,
                        EmailId = model.EmailId
                    }
                };

                var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<SaveEmployeeRS>(SaveEmployeeMethod, request));
                var apiResponse = task.Result;
                if (!string.IsNullOrEmpty(apiResponse.Error))
                {
                    ModelState.AddModelError("FirstName", apiResponse.Error);
                    ModelState.AddModelError("LastName", apiResponse.Error);
                    ModelState.AddModelError("EmailId", apiResponse.Error);
                    return View(model);
                }
                var empId = apiResponse.Id;
                return RedirectToAction("Details", new { id = empId });
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = new GetEmployeeRQ()
            {
                Id = id
            };
            var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<GetEmployeeRS>(GetEmployeeMethod, request));
            var emp = task.Result.Employee;
            var model = new EditEmployeeViewModel()
            {
                Id = (int)emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Age = emp.Age,
                EmailId = emp.EmailId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new SaveEmployeeRQ()
                {
                    Employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Age = model.Age,
                        EmailId = model.EmailId
                    }
                };

                var task = System.Threading.Tasks.Task.Run(async () => await _httpClient.HttpPostAsync<SaveEmployeeRS>(SaveEmployeeMethod, request));
                var apiResponse = task.Result;
                if (!string.IsNullOrEmpty(apiResponse.Error))
                {
                    ModelState.AddModelError("FirstName", apiResponse.Error);
                    ModelState.AddModelError("LastName", apiResponse.Error);
                    ModelState.AddModelError("EmailId", apiResponse.Error);
                    return View(model);
                }
                var empId = apiResponse.Id;
                return RedirectToAction("Details", new { id = empId });
            }
            else
            {
                return View(model);
            }
        }
    }
}
