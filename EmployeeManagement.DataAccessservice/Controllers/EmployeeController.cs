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
        public GetEmployeeRS GetEmployee(GetEmployeeRQ request)
        {
            var emp = _employeeRepository.GetEmployee(request.Id);
            return new GetEmployeeRS { Employee = emp };
        }

        [HttpGet("GetAllEmployees")]
        public GetEmployeesRS GetAllEmployees()
        {
            var response = _employeeRepository.GetAllEmployees();
            return new GetEmployeesRS {  Employees = response };
        }

        [HttpPost("SearchEmployees")]
        public GetEmployeesRS SearchEmployees(SearchEmployeeRQ request)
        {
            var employees = _employeeRepository.SearchEmployees(request.SearchCriteria);
            return new GetEmployeesRS { Employees = employees };
        }

        [HttpPost("DeleteEmployee")]
        public BaseContractRS DeleteEmployee(DeleteEmployeeRQ request)
        {
            return new BaseContractRS() { Success = _employeeRepository.DeleteEmployee(request.Id) };
        }
    }
}