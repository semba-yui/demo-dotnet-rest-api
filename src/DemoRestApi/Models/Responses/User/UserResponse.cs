namespace SembaYui.DemoRestApi.Models.Responses.User;

/// <summary>
///     User Response.
/// </summary>
public class UserResponse(ResponseCodeInfo info, DateTime dateTime, User? data)
    : BaseResponse<User>(info, dateTime, data);
