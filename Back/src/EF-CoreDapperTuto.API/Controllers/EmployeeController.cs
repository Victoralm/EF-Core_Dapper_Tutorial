using EF_CoreDapperTuto.Domain.Entities;
using EF_CoreDapperTuto.Domain.Interfaces;
using EF_CoreDapperTuto.Persistence.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
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

        /// <summary>
        /// Deals with post HTTP requests
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns>An Ok HTTP response containing the Id of the new generated
        /// record on Employees table</returns>
        [HttpPost]
        public async Task<IActionResult> AddNewEmployeeWithDepartment(EmployeeDTO employeeDto)
        {
            this.DbContext.Connection.Open();
            using (var transaction = this.DbContext.Connection.BeginTransaction())
            {
                try
                {
                    this.DbContext.Database.UseTransaction(transaction as DbTransaction);
                    //Check if Department Exists (By Name)
                    bool DepartmentExists = await this.DbContext.Departments.AnyAsync(a => a.Name == employeeDto.Department.Name);
                    if(DepartmentExists)
                    {
                        throw new Exception("Department Already Exists");
                    }
                    //Add Department
                    var addDepartmentQuery = $"INSERT INTO Departments(Name,Description) VALUES('{employeeDto.Department.Name}','{employeeDto.Department.Description}');SELECT CAST(SCOPE_IDENTITY() as int)";
                    var departmentId = await this.WriteDbConnection.QuerySingleAsync<int>(addDepartmentQuery, transaction: transaction);
                    //Check if Department Id is not Zero.
                    if(departmentId == 0)
                    {
                        throw new Exception("Department Id");
                    }
                    //Add Employee
                    var employee = new Employee
                    {
                        DepartmentId = departmentId,
                        Name = employeeDto.Name,
                        Email = employeeDto.Email
                    };
                    await this.DbContext.Employees.AddAsync(employee);
                    await this.DbContext.SaveChangesAsync(default);
                    //Commmit
                    transaction.Commit();
                    //Return EmployeeId
                    return Ok(employee.Id);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    this.DbContext.Connection.Close();
                }
            }
        }
    }
}