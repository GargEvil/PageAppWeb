using System.Net;

namespace PageApp.Infrastracture.ExceptionHandling;

public class ApiError
{
    public static ApiError Default => new ApiError(HttpStatusCode.InternalServerError, "Internal server error.");

    public HttpStatusCode StatusCode { get; private set; }

    public string Message { get; private set; }

    public string Details { get; set; }

    public ApiError(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
        Details = string.Empty;
    }

}