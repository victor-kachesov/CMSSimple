using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.StorageServices.Common
{
    public class DbMapper
    {
        public DbMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Task<IEnumerable<T>> QueryMultipleAsync<T>(string query, object param = null)
        {
            return WithConnection(connection => connection.QueryAsync<T>(query, param), query, param);
        }

        public Task<T> QuerySingleOrDefaultAsync<T>(string query, object param = null)
        {
            return WithConnection(connection => connection.QueryFirstOrDefaultAsync<T>(query, param), query, param);
        }

        public async Task<int> ExecuteOrThrowAsync(string query, object param = null)
        {
            var affectedRowCount = await WithConnection(connection => connection.ExecuteAsync(query, param), query, param);

            if (affectedRowCount == 0)
            {
                throw new InvalidOperationException("No one row was changed");
            }

            return affectedRowCount;
        }


        public Task<int> ExecuteAsync(string query, object param = null)
        {
            return WithConnection(connection => connection.ExecuteAsync(query, param), query, param);
        }

        private IDbConnection GetDbConnection()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(_connectionString);

            var connection = new SqlConnection(connectionStringBuilder.ToString());

            return connection;
        }

        private async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> func, string query, object param = null)
        {
            using (var connection = GetDbConnection())
            {
                return await func(connection);
            }
        }
    }
}
