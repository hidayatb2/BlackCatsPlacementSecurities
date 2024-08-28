using BlackCats_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlackCats_Persistance.Data;
using Dapper;
using System.Data;
using BlackCats_Application.Abstraction.IRepository;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BlackCats_Persistance.Respository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly BCPSDbContext context;

        public BaseRepository(BCPSDbContext context, IConfiguration configuration)
        {
            this.context = context;
        }

        public BaseRepository(BCPSDbContext context)
        {
            this.context = context;
        }

        #region Async Methods
        public async Task<int> AddAsync(T Modal)
        {
            context.Set<T>()?.AddAsync(Modal);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(Guid id)
        {
            T model = new T { Id = id };
            context.Set<T>().Remove(model);
            return await context.SaveChangesAsync();
        }



        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().Where(predicate);
        }



        public async Task<IEnumerable<T>> GetAllByAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyIdAsync(Guid guid)
        {
            return await context.Set<T>().FindAsync(guid);
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AnyAsync(expression);
        }



        public async Task<int> UpdateAsync(T Modal)
        {
            context.Set<T>().Update(Modal);
            return await context.SaveChangesAsync();
        }

        public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteAsync(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync<TEntity>(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T1> Findby<T1>(Expression<Func<T1, bool>> expression)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region DapperMethods
        //public async Task<TEntity> FirstOrDefaultAsync<TEntity>(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        //{
        //    using SqlConnection connection = new(_configuration);
        //    await connection.OpenAsync();
        //    return await connection.QueryFirstOrDefaultAsync<TEntity>(query, param, transaction, null, commandType);
        //}

        //public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        //{
        //    using SqlConnection connection = new(_configuration);
        //    await connection.OpenAsync();
        //    return await connection.QueryAsync<TEntity>(query, param, transaction, null, commandType);
        //}

        //public async Task<int> ExecuteAsync(string query, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        //{
        //    using SqlConnection connection = new(_configuration);
        //    await connection.OpenAsync();
        //    return await connection.ExecuteAsync(query, param, transaction, null, commandType);
        //}
        #endregion
    }

}
