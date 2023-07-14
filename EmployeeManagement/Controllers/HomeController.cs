using EmployeeManagement.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Employee>();
            model.Add(new Employee() { Id = 1 , FirstName ="Test", LastName="Test", EmailId="Test@Email.com", Age=10 });
            model.Add(new Employee() { Id = 2, FirstName = "Test2", LastName = "Test2", EmailId = "Test2@Email.com", Age = 20 });
            return View(model);
        }

        
    }
}
