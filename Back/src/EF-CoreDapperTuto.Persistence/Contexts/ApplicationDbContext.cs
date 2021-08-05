using Microsoft.EntityFrameworkCore;
using EF_CoreDapperTuto.Domain.Interfaces;
using System.Data;
using EF_CoreDapperTuto.Domain.Entities;

namespace EF_CoreDapperTuto.Persistence.Contexts
{
    /// <summary>
    /// Defines the parameters of the context to the DB
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        /// <summary>
        /// Injecting an EntityFrameworkCore.DbContextOptions object of
        /// type ApplicationDbContext as dependency
        /// </summary>
        /// <param name="options">An EntityFrameworkCore.DbContextOptions of
        /// type ApplicationDbContext </param>
        /// <returns></returns>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}