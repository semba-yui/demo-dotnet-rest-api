namespace SembaYui.DemoRestApi.Models.Responses;

/// <summary>
///     Response Codes.
/// </summary>
public static class ResponseCodes
{
    public static readonly ResponseCodeInfo Success = new("CODE00000", "Success");

    public static readonly ResponseCodeInfo IllegalParameters = new("CODE00001", "Illegal Parameters");

    public static readonly ResponseCodeInfo InternalServerError = new("CODE00002", "Internal Server Error");

    public static readonly ResponseCodeInfo UnknownError = new("CODE00003", "Unknown Error");
    public static readonly ResponseCodeInfo ClientError = new("CODE00004", "Client Error");
    public static readonly ResponseCodeInfo SystemError = new("CODE00005", "System Error");
}
