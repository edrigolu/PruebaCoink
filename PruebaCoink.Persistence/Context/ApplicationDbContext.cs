using Microsoft.Extensions.Configuration;
using Npgsql;
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
            _connectionstring = _configuration.GetConnectionString("PostgConnection")!;
        }

        public IDbConnection CreateConnection => new NpgsqlConnection(_connectionstring);
    }
}
