using EmployeeManagement.Contracts;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeController(StandardHttpClientHelper standardHttpClientHelper)
        {
            _httpClient = standardHttpClientHelper.httpClient;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id )
        {
            var emp = new Employee()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                EmailId = "Test@Email.com",
                Age = 10,
            };
            return View(emp);
        }
    }
}
