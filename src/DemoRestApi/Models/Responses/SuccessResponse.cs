namespace SembaYui.DemoRestApi.Models.Responses;

/// <summary>
///     Success Response.
/// </summary>
/// <param name="dateTime"></param>
[ToString]
public class SuccessResponse(DateTime dateTime) : BaseResponse<object>(ResponseCodes.Success, dateTime, null);
