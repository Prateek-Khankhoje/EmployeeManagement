using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DataAccessservice.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        public int Id { get; set; }
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
