using Peercode.Core.Enums;
using Peercode.Core.Models;

namespace Peercode.Dtos;

public class UserUpdateDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public Address Address { get; set; }

    public Sex Sex { get; set; }

    public DateOnly DateOfBirth { get; set; }

}
