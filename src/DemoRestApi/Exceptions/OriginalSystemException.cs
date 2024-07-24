namespace SembaYui.DemoRestApi.Exceptions;

/// <summary>
///     HTTP 5xx 系のエラーを表す例外クラス
/// </summary>
public class OriginalSystemException : Exception
{
    public OriginalSystemException(string message) : base(message) { }

    public OriginalSystemException(string message, Exception innerException) : base(message, innerException) { }
}
