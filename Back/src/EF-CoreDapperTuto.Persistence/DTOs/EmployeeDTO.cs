using System.ComponentModel.DataAnnotations;

namespace EF_CoreDapperTuto.Persistence.DTOs
{
    /// <summary>
    /// Data Transfer Object for the POCO class Employee
    /// </summary>
    public class EmployeeDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DepartmentDTO Department { get; set; }
    }
}