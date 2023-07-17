using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Contracts
{
    public class Employee
    {
        public int? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
    }
}