using Da.Inferfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Da.Services
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly IConfiguration _config;
        public AsyncRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection {
            get {
                return new SqlConnection(_config.GetConnectionString("dbConnection"));
            }
        }

        public async Task Delete(T entity)
        {
            using IDbConnection conn = Connection;
            await conn.DeleteAsync(entity);
        }

        public async Task<T> GetById(int id)
        {
            using IDbConnection conn = Connection;
            return await conn.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetList()
        {
            using IDbConnection conn = Connection;
            return await conn.GetListAsync<T>();
        }

        public async Task<int?> Insert(T entity)
        {
            using IDbConnection conn = Connection;
            return await conn.InsertAsync(entity);
        }

        public async Task Update(T entity)
        {
            using IDbConnection conn = Connection;
            await conn.UpdateAsync(entity);
        }
    }
}
