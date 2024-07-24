namespace SembaYui.DemoRestApi.Models.Responses;

/// <summary>
///     Error Response.
/// </summary>
/// <param name="info"></param>
[ToString]
public class ErrorResponse(ResponseCodeInfo info, DateTime dateTime) : BaseResponse<object>(info, dateTime, null);
