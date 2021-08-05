using EF_CoreDapperTuto.Domain.Entities;
using EF_CoreDapperTuto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EF_CoreDapperTuto.API.Controllers
{
    /// <summary>
    /// Receives the HTTP requests relative to the Employees
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Makes a reference to the class EF_CoreDapperTuto.Persistence.Contexts.ApplicationDbContext
        /// </summary>
        /// <value></value>
        public IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Makes a reference to the class EF_CoreDapperTuto.Persistence.Connections.ApplicationReadDbConnection
        /// </summary>
        /// <value></value>
        public IApplicationReadDbConnection ReadDbConnection { get; }

        /// <summary>
        /// Makes a reference to the class EF_CoreDapperTuto.Persistence.Connections.ApplicationWriteDbConnection
        /// </summary>
        /// <value></value>
        public IApplicationWriteDbConnection WriteDbConnection { get; }

        /// <summary>
        /// Injecting dependencies on the constructor
        /// </summary>
        /// <param name="dbContext">An object of tpe EF_CoreDapperTut.Domain.ApplicationDbContext</param>
        /// <param name="readDbConnection">An object of tpe EF_CoreDapperTuto.Domain.ApplicationReadDbConnection</param>
        /// <param name="writeDbConnection">An object of tpe EF_CoreDapperTuto.Domain.ApplicationWriteDbConnection</param>
        public EmployeeController(IApplicationDbContext dbContext, IApplicationReadDbConnection readDbConnection, IApplicationWriteDbConnection writeDbConnection)
        {
            this.DbContext = dbContext;
            this.ReadDbConnection = readDbConnection;
            this.WriteDbConnection = writeDbConnection;
        }

        /// <summary>
        /// Deals with get HTTP requests without parameters
        /// </summary>
        /// <returns>An Ok HTTP response containing an array of all the records available from the Employees DB table</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var query = $"SELECT * FROM Employees";
            var employees = await this.ReadDbConnection.QueryAsync<Employee>(query);
            return Ok(employees);
        }

        /// <summary>
        /// Deals with get HTTP requests by Id
        /// </summary>
        /// <param name="id">The Id of a desired record from the Employees DB table</param>
        /// <returns>An Ok HTTP response containing a List of all the records from the Employees DB table that matches the given <paramref name="id"/></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllEmployeesById(int id)
        {
            var employees = await this.DbContext.Employees.Include(a => a.Department).Where(a => a.Id == id).ToListAsync();
            return Ok(employees);
        }
    }
}