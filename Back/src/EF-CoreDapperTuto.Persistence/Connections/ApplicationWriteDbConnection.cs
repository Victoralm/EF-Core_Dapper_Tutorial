using Dapper;
using EF_CoreDapperTuto.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EF_CoreDapperTuto.Persistence.Connections
{
    /// <summary>
    /// Implements the write operations on the DB
    /// </summary>
    public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
    {
        /// <summary>
        /// Shares the connections between Entity Framework Core and Dapper
        /// </summary>
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Injecting an
        /// EF_CoreDapperTuto.Persistence.Contexts.ApplicationDbContext object
        /// as dependency
        /// </summary>
        /// <param name="context">An EF_CoreDapperTuto.Persistence.Contexts.ApplicationDbContext object</param>
        public ApplicationWriteDbConnection(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            // Returns a Dapper result of the query
            return await context.Connection.ExecuteAsync(sql, param, transaction);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            // Returns a Dapper result of the query
            return (await context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            // Returns a Dapper result of the query
            return await context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Connection.QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}