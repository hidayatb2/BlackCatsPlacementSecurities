using BlackCats_Application.Shared;
using BlackCatsAPI.Controllers.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlackCatsAPI.Utils;

public static class ResultExtension
{
    public static IResult ApiResult<T>(this ApiController controller,APIResponse<T> result) 
    {
        return new CustomResult<T>(result);
    }

}


public class CustomResult<T> : IResult
{
    public int StatusCode { get; set; }

    public APIResponse<T> Value { get; set; }

    public CustomResult(APIResponse<T> value)
    {
        Value= value;

        StatusCode=value.StatusCode;
    }


    public Task ExecuteAsync(HttpContext context)
    {
        context.Response.StatusCode = StatusCode;
        context.Response.ContentType= "application/json";

        var Serialization = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };
        var responseJson=JsonSerializer.Serialize(Value,Serialization);
        return context.Response.WriteAsync(responseJson);
    }
}
