using Dotnet.Dapper.Blog.Crud.Models;
using Microsoft.Data.SqlClient;

namespace Dotnet.Dapper.Blog.Crud.Repositories
{
    public sealed class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;
    }
}
