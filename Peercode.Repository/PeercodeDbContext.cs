using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Peercode.Persistance;

internal class PeercodeDbContext(IConfiguration configuration)
{
   public SqlConnection Connection = new (configuration.GetConnectionString("PeercodeDb"));
}
