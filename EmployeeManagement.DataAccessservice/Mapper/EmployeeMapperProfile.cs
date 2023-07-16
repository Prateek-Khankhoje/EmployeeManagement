using EmployeeManagement.Contracts;
using EmployeeManagement.DataAccessservice.Models;

namespace EmployeeManagement.DataAccessservice.Mapper
{
    public class EmployeeMapperProfile: AutoMapper.Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
