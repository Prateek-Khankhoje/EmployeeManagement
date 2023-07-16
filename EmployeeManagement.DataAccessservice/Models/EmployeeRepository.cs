using EmployeeManagement.Contracts;

namespace EmployeeManagement.DataAccessservice.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _allEmployees = new List<Employee>()
        {
            new Employee(){Id=1, Age=10, FirstName="First1", LastName="Last", EmailId="first1@last.com" },
            new Employee(){Id=2, Age=10, FirstName="First2", LastName="Last", EmailId="first2@last.com" },
            new Employee(){Id=3, Age=10, FirstName="First3", LastName="Last", EmailId="first3@last.com" },
            new Employee(){Id=4, Age=10, FirstName="First4", LastName="Last", EmailId="first4@last.com" }
        };
        public Employee GetEmployee(int id)
        {
            return _allEmployees.FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _allEmployees;
        }

        public int SaveEmployee(Employee employee)
        {
            employee.Id = _allEmployees.Max(x => x.Id) + 1;
            _allEmployees.Add(employee);

            return (int)_allEmployees.Find( x => x.Id == employee.Id).Id;
        }

        public int UpdateEmployee(Employee employee)
        {
            _allEmployees[_allEmployees.FindIndex(x => x.Id == employee.Id)] = employee;
            return (int)_allEmployees.Find(x => x.Id == employee.Id).Id;
        }

        public bool DeleteEmployee(int id)
        {
            _allEmployees.Remove(_allEmployees.Find(x => x.Id == id));
            return true;
        }

        public List<Employee> SearchEmployees(string? searchCriteria)
        {
            List<Employee> response;
            if (String.IsNullOrEmpty(searchCriteria))
            {
                response = _allEmployees;
            }
            else
            {
            response = _allEmployees.Where(x => x.FirstName.Contains(searchCriteria) || x.LastName.Contains(searchCriteria)).ToList();                
            }
            return response;
        }
    }
}
