using EF_CoreDapperTuto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EF_CoreDapperTuto.Domain.Interfaces
{
    /// <summary>
    /// Sets the DB Context
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Stores the connection with the DB. To be used by Dapper. (Should be
        /// at Persistance layer)
        /// </summary>
        /// <value></value>
        public IDbConnection Connection { get; }

        /// <summary>
        /// Stores <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.databasefacade?view=efcore-5.0">DB related</a> information and operations for a
        /// contex. To be used by Dapper.
        /// </summary>
        /// <value></value>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Stores the <a
        /// href="https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset-1?view=entity-framework-6.2.0">DbSet</a>
        /// of type EF_CoreDapperTuto.Domain.Entities.Employee
        /// </summary>
        /// <value></value>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Stores the <a href="https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset-1?view=entity-framework-6.2.0">DbSet</a> of type EF_CoreDapperTuto.Domain.Entities.Department
        /// </summary>
        /// <value></value>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Asynchronously saves changes to the Db
        /// </summary>
        /// <param name="cancellationToken">Propagates <a heref="Ref: https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-5.0">notification</a> that operations should be canceled.</param>
        /// <returns>An int, indicating "whatever"</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}