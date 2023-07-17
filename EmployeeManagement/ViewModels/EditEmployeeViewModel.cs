﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EditEmployeeViewModel
    {
        [Required]
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
