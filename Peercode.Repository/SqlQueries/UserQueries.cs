namespace Peercode.Persistance.SqlQueries;

internal static class UserQueries
{
    public const string InsertUser = @"
        INSERT INTO User(
            UserName,
            Email,
            FirstName,
            LastName,
            Phone,
            Address,
            DateOfBirth,
            Sex
        )
        VALUES(
            @UserName,
            @Email,
            @FirstName,
            @LastName,
            @Phone,
            @Address,
            @DateOfBirth,
            @Sex
        );";

    public const string SelectUserById = @"
        SELECT
            UserId,
            UserName,
            Email,
            FirstName,
            LastName,
            Phone,
            Address,
            DateOfBirth,
            Sex
        FROM User
        WHERE UserId = @UserId AND IsDeleted = 0";

    public const string UpdateUser = @"
        UPDATE User
        SET
            Email = @Email,
            FirstName = @FirstName,
            LastName = @LastName,
            Phone = @Phone,
            Address = @Address,
            DateOfBirth = @DateOfBirth,
            Sex = @Sex
        WHERE UserId = @UserId AND IsDeleted = 0";

    public const string DeleteUser = @"
        UPDATE User
        SET IsDeleted = 1
        WHERE UserId = @UserId";
}
