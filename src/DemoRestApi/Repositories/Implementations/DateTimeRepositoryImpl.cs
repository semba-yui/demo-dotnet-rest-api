using SembaYui.DemoRestApi.Repositories.Interfaces;

namespace SembaYui.DemoRestApi.Repositories.Implementations;

/// <summary>
///     Implementation of the <see cref="IDateTimeRepository" />.
/// </summary>
public class DateTimeRepositoryImpl : IDateTimeRepository
{
    /// <summary>
    ///     Get the time zone of Tokyo.
    /// </summary>
    private static readonly TimeZoneInfo TokyoTimeZone = GetTokyoTimeZone();

    /// <summary>
    ///     Get the current time in Tokyo.
    /// </summary>
    public DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TokyoTimeZone);

    /// <summary>
    ///     Get the time zone of Tokyo.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    private static TimeZoneInfo GetTokyoTimeZone()
    {
        // Windows
        if (OperatingSystem.IsWindows())
        {
            return TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        }

        // macOS or Linux
        if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
        {
            return TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
        }

        throw new NotSupportedException("Unsupported operating system.");
    }
}
