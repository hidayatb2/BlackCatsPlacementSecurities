using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance.Repository
{
    public class WagesRepository : BaseRepository<Wages>, IWagesRepository
    {
        private readonly BCPSDbContext context;

        public WagesRepository(BCPSDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> AddWages(Wages model)
        {
            string Query = $@"Insert into Wages values(@id,@DailyWages,@NoOfWorkingDays,@WageMonth,@PFDeduction,
                            @ESICDeduction,@EmployeeId,@CreatedAt)";
            return await ExecuteAsync(Query, new
            {
                id = model.Id,
                DailyWages = model.DailyWages,
                NoOfWorkingDays = model.NoOfWorkingDays,
                WageMonth = model.WageMonth,
                PFDeduction = model.PFDeduction,
                ESICDeduction = model.ESICDeduction,
                EmployeeId = model.EmployeeId,
                CreatedAt = model.CreatedAt
            });
        }

        public async Task<bool> DeleteWages(Guid id)
        {
            string Query = $@"Delete from Wages where id=@id";
            var res = await ExecuteAsync(Query, new { id });
            if (res >= 1)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<IEnumerable<Wages>> GetAllWages(int pageSize, int pageNo)
        {
            string Query = $@"Select * From Wages Order By id OFFSET {pageSize * (pageNo - 1)} Rows FETCH NEXT {pageSize} ROWS ONLY ";
            var x = await QueryAsync<Wages>(Query);
            return x;
        }

        public async Task<Wages> GetWagesById(Guid id)
        {
            string Query = $@"Select * from Employees where id=@id";
            return await FirstOrDefaultAsync<Wages>(Query, new { id });
        }

        public async Task<int> UpdateWages(Wages model)
        {
            string Query = $@"Update Wages Set @DailyWages,@NoOfWorkingDays,@WageMonth,@PFDeduction,
                            @ESICDeduction,@EmployeeId,@CreatedAt WHERE Id=@Id";
            return await ExecuteAsync(Query, new
            {
                id = model.Id,
                DailyWages = model.DailyWages,
                NoOfWorkingDays = model.NoOfWorkingDays,
                WageMonth = model.WageMonth,
                PFDeduction = model.PFDeduction,
                ESICDeduction = model.ESICDeduction,
                EmployeeId = model.EmployeeId,
                CreatedAt = model.CreatedAt
            });
        }
    }
}
