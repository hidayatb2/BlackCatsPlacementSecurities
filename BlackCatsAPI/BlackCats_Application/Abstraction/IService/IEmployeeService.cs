using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IEmployeeService
    {
        Task<APIResponse<EmployeeResponse>> AddEmployee(EmployeeRequest model);

        Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAllEmployee(int pageNo, int pageSize);

        Task<APIResponse<string>> DeleteEmployee(Guid id);

        Task<APIResponse<EmployeeResponse>> GetEmployeeById(Guid id);

        Task<APIResponse<EmployeeUpdateResponse>> UpdateEmployee(EmployeeUpdateRequest model);
    }
}
