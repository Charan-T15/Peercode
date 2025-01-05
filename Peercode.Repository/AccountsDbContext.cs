using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Peercode.Persistance;

public class AccountsDbContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options)
{
}