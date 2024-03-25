namespace N5.Permissions.BL.Models;

public class ApiResponse<T>
{
    public T Data { get; private set; }
    public string Message { get; private set; }
    public bool Success { get; private set; }

    public ApiResponse(T data, string message = "", bool success = true)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    public static ApiResponse<T> Ok(T data, string message = "")
    {
        return new ApiResponse<T>(data, message, true);
    }

    public static ApiResponse<T> Fail(string message)
    {
        return new ApiResponse<T>(default, message, false);
    }
}
