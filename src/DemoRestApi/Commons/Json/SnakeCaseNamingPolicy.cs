using System.Text.Json;

namespace SembaYui.DemoRestApi.Commons.Json;

/// <summary>
///     Naming policy for snake case.
/// </summary>
public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    /// <summary>
    ///     Convert the name to snake case.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public override string ConvertName(string name)
    {
        return string.Concat(name.Select((c, i) =>
            i > 0 && char.IsUpper(c) ? "_" + c.ToString().ToLower() : c.ToString().ToLower()));
    }
}
