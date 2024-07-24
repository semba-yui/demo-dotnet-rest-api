namespace SembaYui.DemoRestApi.Repositories.Interfaces;

/// <summary>
///     Interface for getting the current time.
/// </summary>
public interface IDateTimeRepository
{
    /// <summary>
    ///     Get the current time.
    /// </summary>
    DateTime Now { get; }
}
