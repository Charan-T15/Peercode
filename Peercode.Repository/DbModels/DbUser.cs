﻿namespace Peercode.Persistance.DbModels;

internal class DbUser
{
    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public DateTime DateofBirth { get; set; }

    public short Sex { get; set; }
}
