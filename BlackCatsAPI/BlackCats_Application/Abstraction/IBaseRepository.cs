using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction
{
    public  interface IBaseRepository<T> where T : BaseEntity,new()
    {

        Task<IEnumerable<T>> GetAllByAsync();


        Task<int> AddAsync(T Modal);


        Task<int> UpdateAsync(T Modal);


        Task<T> GetbyIdAsync(Guid guid);


        Task<int> DeleteByIdAsync(Guid id);


        Task<bool> IsExist(Expression<Func<T, bool>> expression);


        Task<IEnumerable<T>> FindbyAsync(Expression<Func<T, bool>> expression);

        
    }
}
