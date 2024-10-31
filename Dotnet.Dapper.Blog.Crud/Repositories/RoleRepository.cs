using Dotnet.Dapper.Blog.Crud.Models;
using Microsoft.Data.SqlClient;

namespace Dotnet.Dapper.Blog.Crud.Repositories
{
    public sealed class RoleRepository : Repository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) : base(connection)
            => _connection = connection;
    }
}
