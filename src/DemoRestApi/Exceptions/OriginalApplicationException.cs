namespace SembaYui.DemoRestApi.Exceptions;

/// <summary>
///     HTTP 4xx 系のエラーを表す例外クラス
/// </summary>
public class OriginalApplicationException : Exception
{
    public OriginalApplicationException(string message) : base(message) { }

    public OriginalApplicationException(string message, Exception innerException) : base(message, innerException) { }
}
