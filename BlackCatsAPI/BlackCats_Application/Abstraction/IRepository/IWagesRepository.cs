using BlackCats_Domain.Entities;

namespace BlackCats_Application.Abstraction.IRepository
{
    public interface IWagesRepository : IBaseRepository<Wages>
    {

        Task<int> AddWages(Wages model);

        Task<IEnumerable<Wages>> GetAllWages(int pageSize, int pageNo);

        Task<bool> DeleteWages(Guid id);

        Task<int> UpdateWages(Wages model);

        Task<Wages> GetWagesById(Guid id);
    }
}
