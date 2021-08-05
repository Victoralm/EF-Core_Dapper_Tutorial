using Dapper;
using EF_CoreDapperTuto.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EF_CoreDapperTuto.Persistence.Connections
{
    /// <summary>
    /// Implements the read operations on the DB
    /// </summary>
    public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
    {
        /// <summary>
        /// Stores the DB connection string from appSettings.json
        /// </summary>
        private readonly IDbConnection connection;

        /// <summary>
        /// Injecting a Microsoft.Extensions.Configuration.IConfiguration object as depency
        /// </summary>
        /// <param name="configuration">A Microsoft.Extensions.Configuration.IConfiguration object</param>
        public ApplicationReadDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }

        /// <summary>
        /// Used to free / end the query.
        /// </summary>
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}