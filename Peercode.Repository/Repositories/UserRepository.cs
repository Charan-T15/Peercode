using AutoMapper;
using Dapper;
using Peercode.Core.Models;
using Peercode.Core.Repositories;
using Peercode.Persistance.DbModels;
using Peercode.Persistance.SqlQueries;

namespace Peercode.Persistance.Repositories;

internal class UserRepository(PeercodeDbContext db, IMapper mapper) : IUserRepository
{
    public async Task AddUserAsync(User user)
    {
        var dbUser = mapper.Map<DbUser>(user);
        await db.Connection.ExecuteAsync(UserQueries.InsertUser, dbUser);
    }

    public async Task<User> GetUserAsync(Guid userId)
    {
        var dbUser = await db.Connection.QueryFirstOrDefaultAsync<DbUser>(UserQueries.SelectUserById, new { UserId = userId });
        return mapper.Map<User>(dbUser);
    }

    public async Task UpdateUserAsync(User user)
    {
        var dbUser = mapper.Map<DbUser>(user);
        await db.Connection.ExecuteAsync(UserQueries.UpdateUser, dbUser);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await db.Connection.ExecuteAsync(UserQueries.DeleteUser, new { UserId = userId });
    }
}
