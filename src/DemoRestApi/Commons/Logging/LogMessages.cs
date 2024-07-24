using Microsoft.Extensions.Localization;

namespace SembaYui.DemoRestApi.Commons.Logging;

/// <summary>
///     ログメッセージを定義するクラス
/// </summary>
/// <param name="localizer"></param>
public class LogMessages(IStringLocalizer<LogMessages> localizer)
{
    public string L0001UnhandledException => localizer["L0001-UNHANDLED-EXCEPTION"];
    public string L0002ApplicationException => localizer["L0002-APPLICATION-EXCEPTION"];
    public string L0003SystemException => localizer["L0003-SYSTEM-EXCEPTION"];
}
