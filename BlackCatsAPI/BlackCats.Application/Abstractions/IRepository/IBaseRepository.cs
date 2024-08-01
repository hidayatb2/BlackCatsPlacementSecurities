using System.Linq.Expressions;

namespace BlackCats.Application.Abstractions.IRepository
{
    public interface IBaseRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        T? GetById<T>(Guid id) where T : class;

        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> expression) where T : class;

        int Add<T>(T entity) where T : class;

        int Update<T>(T entity) where T : class;

        int Delete<T>(Guid id) where T : class;


        #region async version

        Task<IQueryable<T>> GetAllAsync<T>() where T : class;   

        Task<T> GetByIdAsync<T>(Guid id) where T : class;    

        Task<IQueryable<T>> FindByAsync<T>(Expression<Func<T, bool>> expression) where T : class;    

        Task<int> AddAsync<T>(T entity) where T : class;    

        Task<int> UpdateAsync<T>(T entity) where T : class; 

        Task<int> DeleteAsync<T>(Guid id)where T : class;   


        #endregion
    }
}
