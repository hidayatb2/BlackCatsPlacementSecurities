using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;

namespace BlackCats_Persistance.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        private readonly BCPSDbContext context;

        public EmployeeRepository(BCPSDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> AddEmployee(Employee model)
        {
            string Query = $@"Insert into Employees values(@id,@Name,@Address,@ContactNo,@DataofJoining,
                            @DateOfLeaving,@AdhaarNo,@BankAccountNo,@IsUniformFeePaid,@isDeleted,@ClientId,@CreatedAt)";
            return await ExecuteAsync(Query, new
            {
                id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contactno = model.ContactNo,
                Dateofjoining = model.DateOfJoining,
                Dateofleaving = model.DateOfLeaving,
                AdhaarNo = model.AadhaarNumber,
                BankAccountNo = model.BankAccountNo,
                IsUniformFeePaid = model.IsUniformFeePaid,
                isDeleted = model.IsDeleted,
                clientId = model.ClientId,
                CreatedAt = model.CreatedAt
            });
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            string Query = $@"Delete from Employees where id=@id";
            var res= await ExecuteAsync(Query,new {id});
            if(res>=1)
            {
                return true;
            }
            else
                return false;
          
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(int pageSize,int pageNo)
        {
            string Query = $@"Select * From Employees Order By id OFFSET {pageSize*(pageNo-1)} Rows FETCH NEXT{pageSize} ROWS ONLY ";
           return await QueryAsync<Employee>(Query);
        }

        public async Task<Employee> GetEmpById(Guid id)
        {
            string Query = $@"Select * from Employees where id=@id";
            return await FirstOrDefaultAsync<Employee>(Query, new { id });
        }

        public async Task<int> UpdateEmployee(Employee model)
        {
            string Query = $@"Update Employees Set Name=@Name,Address=@Address,ContactNo=@ContactNo,
                            DateofJoining=@DateOfJoining,DateOfLeaving=
                            @DateOfLeaving,AdhaarNo=@AdhaarNo,BankAccountNo=@BankAccountNo,
                            IsUniformFeePaid=@IsUniformFeePaid,isDeleted=@isDeleted
                            ClientId=@ClientId,CreatedAt=@CreatedAt";
            return await ExecuteAsync(Query, new
            {
                id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contactno = model.ContactNo,
                Dateofjoining = model.DateOfJoining,
                Dateofleaving = model.DateOfLeaving,
                AdhaarNo = model.AadhaarNumber,
                BankAccountNo = model.BankAccountNo,
                IsUniformFeePaid = model.IsUniformFeePaid,
                isDeleted = model.IsDeleted,
                clientId = model.ClientId,
                CreatedAt = model.CreatedAt
            });
        }
    }
}
