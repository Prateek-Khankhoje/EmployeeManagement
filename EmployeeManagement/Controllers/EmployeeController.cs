using EmployeeManagement.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details()
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
