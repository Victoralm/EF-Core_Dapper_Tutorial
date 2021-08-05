using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EF_CoreDapperTuto.Domain.Interfaces
{
    /// <summary>
    /// Sets the template for the read operations on the DB (Should be at Persistance layer)
    /// </summary>
    public interface IApplicationReadDbConnection
    {
        /// <summary>
        /// Asynchronously sends a plain string <paramref name="sql"/> query through Dapper
        /// </summary>
        /// <param name="sql">A plain string sql query</param>
        /// <param name="param">An object containing a <a href="https://www.mssqltips.com/sqlservertip/2981/using-parameters-for-sql-server-queries-and-stored-procedures/">parametrized</a> query procedure</param>
        /// <param name="transaction">Represents a <a href="https://docs.microsoft.com/en-us/dotnet/api/system.data.idbtransaction?view=net-5.0">transaction</a> to be performed at a data source, and is implemented by .NET data providers that access relational databases.</param>
        /// <param name="cancellationToken">Propagates <a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-5.0">notification</a> that operations should be canceled.</param>
        /// <typeparam name="T">A generic type</typeparam>
        /// <returns>A List of all records found by the <paramref name="sql"/> query</returns>
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously sends a plain string <paramref name="sql"/> query through Dapper,
        /// idealized to return a single record
        /// </summary>
        /// <param name="sql">A plain string sql query</param>
        /// <param name="param">An object containing a <a href="https://www.mssqltips.com/sqlservertip/2981/using-parameters-for-sql-server-queries-and-stored-procedures/">parametrized</a> query procedure</param>
        /// <param name="transaction">Represents a <a href="https://docs.microsoft.com/en-us/dotnet/api/system.data.idbtransaction?view=net-5.0">transaction</a> to be performed at a data source, and is implemented by .NET data providers that access relational databases.</param>
        /// <param name="cancellationToken">Propagates <a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-5.0">notification</a> that operations should be canceled.</param>
        /// <typeparam name="T">A generic type</typeparam>
        /// <returns>A single record from the DB found by the <paramref name="sql"/> query</returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously sends a plain string <paramref name="sql"/> query through Dapper,
        /// idealized to return a single record
        /// </summary>
        /// <param name="sql">A plain string sql query</param>
        /// <param name="param">An object containing a <a href="https://www.mssqltips.com/sqlservertip/2981/using-parameters-for-sql-server-queries-and-stored-procedures/">parametrized</a> query procedure</param>
        /// <param name="transaction">Represents a <a href="https://docs.microsoft.com/en-us/dotnet/api/system.data.idbtransaction?view=net-5.0">transaction</a> to be performed at a data source, and is implemented by .NET data providers that access relational databases.</param>
        /// <param name="cancellationToken">Propagates <a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-5.0">notification</a> that operations should be canceled.</param>
        /// <typeparam name="T">A generic type</typeparam>
        /// <returns>A single record from the DB found by the <paramref name="sql"/> query</returns>
        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}