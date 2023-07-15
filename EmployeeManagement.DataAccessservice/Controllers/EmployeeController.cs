using EmployeeManagement.Contracts;
using EmployeeManagement.DataAccessservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.DataAccessservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("GetEmployee")]
        public Employee GetEmployee(GetEmployeeRQ request)
        {
            return _employeeRepository.GetEmployee(request.Id);
        }

        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}