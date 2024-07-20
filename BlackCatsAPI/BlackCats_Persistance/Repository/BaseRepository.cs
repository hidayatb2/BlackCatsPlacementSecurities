using BlackCats_Application.Abstraction;
using BlackCats_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlackCats_Persistance.Respository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly BCPSDbContext context;

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

        public async Task<IEnumerable<T>> FindbyAsync(Expression<Func<T, bool>> expression)
        {
           return await context.Set<T>().Where(expression).ToListAsync();
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
          return  await context.SaveChangesAsync();
        }
        #endregion
    }

}
