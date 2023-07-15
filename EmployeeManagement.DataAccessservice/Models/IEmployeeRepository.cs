using EmployeeManagement.Contracts;

namespace EmployeeManagement.DataAccessservice.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
    }
}
