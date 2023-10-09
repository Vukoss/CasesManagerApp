using System;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using Dapper;

namespace CaseManagerLibrary.Data.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                var output = await connection.QueryAsync<T>(sql, parameters);
                return output.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}

