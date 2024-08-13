using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Shared
{
    public  class ApiResponse<T>
    {
        private readonly bool _IsSuccess;

        private readonly string _Message = string.Empty;

        private readonly int _Status;

        private readonly T? _Result;


        public bool IsSuccess => _IsSuccess;

        public string Message => _Message;

        public int Status => _Status;

        public T? Result => _Result;

        public ApiResponse(T result,string message,int statusCode)
        {
            if(statusCode<100 && statusCode > 600)
            {
                throw new ArgumentException("Invalid Code");
            }

            this._Message = message;
            this._Status = statusCode;
            this._Result = result;
            this._IsSuccess = true;
        }

        public ApiResponse(string message, int statusCode)
        {
            if (statusCode<100 && statusCode > 600)
            {
                throw new ArgumentException("Invalid Code ");
            }

            this._Message = message;
            this._Status = statusCode;
            this._IsSuccess = false;
            this._Result=default;

        }

        public static ApiResponse<T> SuccessResponse(T result, string message = "Success", int statusCode = ApiStatusCodes.OK, bool isSuccess = true) 
        {
            return new ApiResponse<T>(result,message,statusCode);        
        }

        public static ApiResponse<T> ErrorResponse(string message, int statusCode) 
        {
            return new ApiResponse<T>(message,statusCode);
        }



    }
}
