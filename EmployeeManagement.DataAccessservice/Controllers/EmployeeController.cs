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

        [HttpPost("SearchEmployees")]
        public List<Employee> SearchEmployees(SearchEmployeeRQ request)
        {
            return _employeeRepository.SearchEmployees(request.SearchCriteria);
        }

        [HttpPost("DeleteEmployee")]
        public BaseContractRS DeleteEmployee(DeleteEmployeeRQ request)
        {
            return new BaseContractRS() { Success = _employeeRepository.DeleteEmployee(request.Id) };
        }
    }
}