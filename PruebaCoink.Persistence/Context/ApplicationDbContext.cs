using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PruebaCoink.Persistence.Context
{
    public class ApplicationDbContext
    {
        private readonly string _connectionstring;
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SqlConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionstring);
    }
}
