using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.DataAccessservice.Mapper;
using EmployeeManagement.DataAccessservice.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccessService.UnitTest
{
    public class Tests
    {
        private AppDbContext _dbContext;
        private IEmployeeRepository _employeeRepository;
        private AppDbContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;
            return new AppDbContext(options);
        }

        [SetUp] 
        public void SetUp() { 
            _dbContext = GetMemoryContext();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Employees.Add(new EmployeeModel() { Id = 1, FirstName = "Tom", LastName = "Hanks", EmailId = "TomHanks@gmail.com", Age = 50 });
            _dbContext.Employees.Add(new EmployeeModel() { Id = 2, FirstName = "Matt", LastName = "Damon", EmailId = "MattDamon@gmail.com", Age = 40 });
            _dbContext.Employees.Add(new EmployeeModel() { Id = 3, FirstName = "Morgan", LastName = "Freeman", EmailId = "MorganFreeman@gmail.com", Age = 70 });
            _dbContext.SaveChanges();
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new EmployeeMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _employeeRepository = new SQLEmployeeRepository(_dbContext, mapper);
        }

        [Test]
        public void Test_SaveEmployee()
        {
            var employee = new Employee()
            { FirstName = "Tom", LastName = "Hanks", EmailId = "TomHanks@gmail.com", Age = 50 };

            var response = _employeeRepository.SaveEmployee(employee);

            Assert.IsTrue(response != null && response > 0);
        }

        [Test]
        public void Test_GetEmployee() {
            var response = _employeeRepository.GetEmployee(1);

            Assert.IsTrue(response.FirstName == "Tom" && response.LastName == "Hanks");
        }

        [Test]
        public void Test_GetAllEmployee()
        {
            var response = _employeeRepository.GetAllEmployees();

            Assert.IsTrue(response.Count == 3);
        }

        [Test]
        public void Test_DeleteEmployee()
        {
            var response = _employeeRepository.DeleteEmployee(2);

            Assert.IsTrue(response);
        }

        [Test]
        public void Test_SearchEmployee()
        {
            var response = _employeeRepository.SearchEmployees("Tom");

            Assert.IsTrue(response.Count > 0);
        }

        
    }
}