

using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{ public static ResponseResult OK()
    {
        return new ResponseResult
        {
          
            Message = "Succeeded",
            StatusCode = StatusCodes.OK

        };
    }
    public static ResponseResult OK( string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Succeeded",
            StatusCode = StatusCodes.OK

        };
    }
    public static ResponseResult OK(object obj, string? message= null)
    {
        return new ResponseResult
        {
            ContentResult=obj,
            Message = message?? "Succeeded",
            StatusCode = StatusCodes.OK

        };
    }


    public static ResponseResult ERROR(string? message=null)
    {
        return new ResponseResult
        {

            Message = message?? "Failed",
            StatusCode = StatusCodes.ERROR

        };
    }

    public static ResponseResult NOTFOUND(string? message = null)
    {
        return new ResponseResult
        {

            Message = message?? "Not found",
            StatusCode = StatusCodes.NOT_FOUND

        };
    }

    public static ResponseResult EXISTS(string? message = null)
    {
        return new ResponseResult
        {

            Message = message?? "Already exists",
            StatusCode = StatusCodes.EXISTS

        };
    }

    
}
