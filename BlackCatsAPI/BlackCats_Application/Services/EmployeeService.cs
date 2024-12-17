using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<APIResponse<EmployeeResponse>> AddEmployee(EmployeeRequest model)
        {
           var emp=mapper.Map<Employee>(model);
           int returnValue= await repository.AddEmployee(emp);
            if(returnValue>0)
            {
                return APIResponse<EmployeeResponse>.SuccessResponse(mapper.Map<EmployeeResponse>(emp), "Success", APIStatusCodes.OK);
            }
            return APIResponse<EmployeeResponse>.ErrorResponse("Invalid Details",APIStatusCodes.Conflict);
        }

        public async Task<APIResponse<string>> DeleteEmployee(Guid id)
        {
            bool isDeleted=await repository.DeleteEmployee(id);
            if(isDeleted)
            {
                return APIResponse<string>.SuccessResponse("Employee Deleted Succesfully");
            }
            return APIResponse<string>.ErrorResponse("Invalid Id", APIStatusCodes.Conflict);

        }

       

        public async Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAllEmployee(int pageNo,int pageSize)
        {
            var res= await repository.GetAllEmployees(pageNo, pageSize);
            if(res is not null)
            {
                var response = res.Select(x => new EmployeeResponse()
                {
                     Name = x.Name,
                     AadhaarNumber = x.AadhaarNumber,
                     Address = x.Address,
                     BankAccountNo = x.BankAccountNo,
                     ClientId = x.ClientId,
                     ContactNo = x.ContactNo,
                     DateOfJoining=x.DateOfJoining,
                     DateOfLeaving=x.DateOfLeaving,
                     IsUniformFeePaid=x.IsUniformFeePaid,
                });    
                return APIResponse<IEnumerable<EmployeeResponse>>.SuccessResponse(response);
            }
                return APIResponse<IEnumerable<EmployeeResponse>>.ErrorResponse("No Employee Found", APIStatusCodes.Conflict);
        }

        public async Task<APIResponse<EmployeeResponse>> GetEmployeeById(Guid id)
        {
            var res=await repository.GetEmpById(id);
            if(res is not null)
            {
                return APIResponse<EmployeeResponse>.SuccessResponse(mapper.Map<EmployeeResponse>(res));
            }
            else
            {
                return APIResponse<EmployeeResponse>.ErrorResponse("Invalid id",APIStatusCodes.Conflict);
            }
        }

        public async Task<APIResponse<EmployeeUpdateResponse>> UpdateEmployee(EmployeeUpdateRequest model)
        {
            var emp = mapper.Map<Employee>(model);
            var res = await repository.UpdateAsync(emp);
            if (res>0)
            {
                return APIResponse<EmployeeUpdateResponse>.SuccessResponse(mapper.Map<EmployeeUpdateResponse>(emp), "success", APIStatusCodes.Created);
            }
            else
            {
                return APIResponse<EmployeeUpdateResponse>.ErrorResponse("Invalid Id", APIStatusCodes.Conflict);
            }
        }

        
    }
}
