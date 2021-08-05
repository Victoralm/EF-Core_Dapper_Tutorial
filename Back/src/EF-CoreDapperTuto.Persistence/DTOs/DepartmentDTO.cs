using System.ComponentModel.DataAnnotations;

namespace EF_CoreDapperTuto.Persistence.DTOs
{
    /// <summary>
    /// Data Transfer Object for the POCO class Department
    /// </summary>
    public class DepartmentDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}