using AutoMapper;
using EmployeeManagement.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.DataAccessservice.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SQLEmployeeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool DeleteEmployee(int id)
        {
            var emp = _context.Employees.Find(id);
            if(emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }else 
                { return false; }
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return _mapper.Map<List<Employee>>(_context.Employees);
        }

        public Employee GetEmployee(int id)
        {
            var result = _context.Employees.Find(id);
            return _mapper.Map<Employee>(result);
        }

        public int SaveEmployee(Employee employee)
        {
            int empId;
            var existingEmp = _context.Employees.Where(x => x.FirstName.Equals(employee.FirstName) && x.LastName.Equals(employee.LastName) && x.EmailId.Equals(employee.EmailId)).ToList();
            if ( existingEmp.Count == 0)
            {
                var emp = _mapper.Map<EmployeeModel>(employee);
                _context.Employees.Add(emp);
                _context.SaveChanges();
                empId = emp.Id;
            }
            else
            {
                throw new Exception("Employee already exists with the same details");
            }
            return empId;
        }

        public List<Employee> SearchEmployees(string searchCriteria)
        {
            List<EmployeeModel> result = new List<EmployeeModel>();
            if (string.IsNullOrEmpty(searchCriteria))
            {
                result = _context.Employees.ToList();
            }
            else
            {
                result = _context.Employees.Where(x => x.FirstName.Contains(searchCriteria) || x.LastName.Contains(searchCriteria)).ToList();
            }
            return _mapper.Map<List<Employee>>(result);
        }

        public int UpdateEmployee(Employee employee)
        {
            int empId;
            var existingEmp = _context.Employees.Where(x => x.FirstName.Equals(employee.FirstName) && x.LastName.Equals(employee.LastName) && x.EmailId.Equals(employee.EmailId) && !x.Id.Equals(employee.Id)).ToList();
            if (existingEmp.Count == 0)
            {
                var emp = _context.Employees.Attach(_mapper.Map<EmployeeModel>(employee));
                emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                empId = (int)employee.Id;
            }
            else
            {
                throw new Exception("Employee already exists with the same details");
            }
            return empId;

        }
    }
}
