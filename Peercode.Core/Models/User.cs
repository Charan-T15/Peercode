using Peercode.Core.Enums;

namespace Peercode.Core.Models;

public class User
{
    public Guid UserId { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone {  get; set; }

    public Address? Address { get; set; }

    public DateTime? DateofBirth { get; set; }

    public Sex Sex { get; set; }
}
