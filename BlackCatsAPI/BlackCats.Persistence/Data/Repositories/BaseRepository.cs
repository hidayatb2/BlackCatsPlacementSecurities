using BlackCats.Application.Abstractions.IRepository;
using BlackCats.Persistence.Data.Context;
using System.Linq.Expressions;

namespace BlackCats.Persistence
{
    public class BaseRepository : IBaseRepository
    {
        private readonly BlackCatsDbContext context;

        public BaseRepository(BlackCatsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return context.Set<T>();
        }

        public T? GetById<T>(Guid id) where T : class
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> expression) where T : class
        {
           return context.Set<T>().Where(expression);
        }

        public int Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();   
        }

        public int Update<T>(T entity) where T : class
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();   
        }

        public int Delete<T>(Guid id) where T : class
        {
            var entity = GetById<T>(id);
            if (entity is null) return 0;
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }


        #region Async Version

        public async Task<IQueryable<T>> GetAllAsync<T>() where T : class
        {
            return await Task.FromResult(context.Set<T>());
        }

        public async Task<T?> GetByIdAsync<T>(Guid id) where T : class
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> FindByAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
          return await Task.FromResult(context.Set<T>().Where(expression)); 
        }

        public async Task<int> AddAsync<T>(T entity) where T : class
        {
          await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();    
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
           await Task.FromResult(context.Set<T>().Update(entity));
            return await context.SaveChangesAsync();    
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await Task.FromResult(GetById<T>(id));
            if (entity is null) return 0;
            await Task.FromResult(context.Set<T>().Remove(entity));
            return await context.SaveChangesAsync();    
        }

        #endregion
    }
}
