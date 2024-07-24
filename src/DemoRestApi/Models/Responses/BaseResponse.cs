namespace SembaYui.DemoRestApi.Models.Responses;

/// <summary>
///     Base Response.
/// </summary>
/// <param name="info"></param>
/// <param name="data"></param>
/// <typeparam name="T"></typeparam>
[ToString]
public class BaseResponse<T>(ResponseCodeInfo info, DateTime dateTime, T? data)
{
    public string Code { get; } = info.Code;
    public string Message { get; } = info.Message;
    public DateTime DateTime { get; } = dateTime;
    public T? Data { get; } = data;
}
