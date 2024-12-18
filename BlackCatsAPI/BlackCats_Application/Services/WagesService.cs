using AutoMapper;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BlackCats_Application.Services
{
    public class WagesService : IWagesService
    {
        private readonly IWagesRepository repository;
        private readonly IMapper mapper;

        public WagesService(IWagesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<APIResponse<WagesResponse>> AddWages(WagesRequest model)
        {
            var wages = mapper.Map<Wages>(model);
            int returnValue = await repository.AddWages(wages);
            if (returnValue > 0)
            {
                return APIResponse<WagesResponse>.SuccessResponse(mapper.Map<WagesResponse>(wages), "Success", APIStatusCodes.Created);
            }
            return APIResponse<WagesResponse>.ErrorResponse("Something went wrong, Insertion Not Successful", APIStatusCodes.Conflict);
        }

        public async Task<APIResponse<string>> DeleteWages(Guid id)
        {
            var response = await repository.GetWagesById(id);
            if (response is not null)
            {
                bool res = await repository.DeleteWages(id);
                if (res.Equals(true))
                {
                    return APIResponse<string>.SuccessResponse("Wage Deleted Sucessfully", APIStatusCodes.OK);
                }
                return APIResponse<string>.ErrorResponse("Something went wrong, Please try again later", APIStatusCodes.Conflict);
            }
            return APIResponse<string>.ErrorResponse($"Wage with Id: {id} doesn't exist, please check your ID", APIStatusCodes.BadRequest);
        }

        public async Task<APIResponse<IEnumerable<WagesResponse>>> GetAllWages(int pageNo, int pageSize)
        {
            var res = await repository.GetAllWages(pageSize, pageNo);
            if (res is not null)
            {
                var response = res.Select(x => new WagesResponse()
                {
                    DailyWages = x.DailyWages,
                    NoOfWorkingDays = x.NoOfWorkingDays,
                    WageMonth = x.WageMonth,
                    PFDeduction = x.PFDeduction,
                    ESICDeduction = x.ESICDeduction,
                    EmployeeId = x.EmployeeId,
                });

                return APIResponse<IEnumerable<WagesResponse>>.SuccessResponse(response, StatusCodes.Status200OK);
            }
            return APIResponse<IEnumerable<WagesResponse>>.ErrorResponse("No Records Found", StatusCodes.Status400BadRequest);
        }

        public async Task<APIResponse<WagesResponse>> GetWagesById(Guid id)
        {
            var res = await repository.GetWagesById(id);
            if (res is not null)
            {
                return APIResponse<WagesResponse>.SuccessResponse(mapper.Map<WagesResponse>(res), APIStatusCodes.OK);

            }
            return APIResponse<WagesResponse>.ErrorResponse($"Wage with Id: {id} doesn't exist, please check your ID", APIStatusCodes.BadRequest);
        }

        public async Task<APIResponse<WagesUpdateResponse>> UpdateWages(WagesUpdateRequest model)
        {
            var wage = await repository.GetWagesById(model.Id);
            if (wage is not null)
            {
                var emp = mapper.Map<Wages>(model);
                var res = await repository.UpdateWages(emp);
                if (res > 0)
                {
                    return APIResponse<WagesUpdateResponse>.SuccessResponse(mapper.Map<WagesUpdateResponse>(emp), "success", APIStatusCodes.Accepted);
                }
                else
                {
                    return APIResponse<WagesUpdateResponse>.ErrorResponse("Wage with Id: {id} doesn't exist, please check your ID", APIStatusCodes.Conflict);
                }
            }
            return APIResponse<WagesUpdateResponse>.ErrorResponse($"Wages with that Package Id: {model.Id} doesn't Exist, Please Check your ID and try again after sometime", APIStatusCodes.BadRequest);


        }
    }
}
