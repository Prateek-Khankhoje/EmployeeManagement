using EmployeeManagement.Contracts;

namespace EmployeeManagement.DataAccessservice.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        List<Employee> SearchEmployees(string searchCriteria);
        int SaveEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}
