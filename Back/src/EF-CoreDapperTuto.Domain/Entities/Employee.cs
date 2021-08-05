using AspNetCoreHero.Abstractions.Domain;

namespace EF_CoreDapperTuto.Domain.Entities
{
    /// <summary>
    /// POCO class for the Employees DB table
    /// </summary>
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}