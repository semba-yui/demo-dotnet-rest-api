namespace SembaYui.DemoRestApi.Models.Responses.User;

/// <summary>
///     User.
/// </summary>
public class User(int id, string userName)
{
    public int Id { get; } = id;
    public string UserName { get; } = userName;
}
