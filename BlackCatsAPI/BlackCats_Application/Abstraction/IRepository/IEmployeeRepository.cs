using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.Abstraction.IRepository
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {

        Task<int> AddEmployee(Employee model);

        Task<IEnumerable<Employee>> GetAllEmployees(int pageSize,int pageNo);

        Task<bool> DeleteEmployee(Guid id);

        Task<int> UpdateEmployee (Employee model);

        Task<Employee> GetEmpById(Guid id);
    }
}
