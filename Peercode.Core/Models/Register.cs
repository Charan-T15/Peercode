namespace Peercode.Core.Models;

public class Register
{
    public required string UserName { get; set; }

    public required string Password { get; set; }

    public required string FirstName { get; set; }

    public string? LastName { get; set; }
}
