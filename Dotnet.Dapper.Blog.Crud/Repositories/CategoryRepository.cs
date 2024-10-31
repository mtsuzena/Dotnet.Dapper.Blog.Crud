using Dotnet.Dapper.Blog.Crud.Models;
using Microsoft.Data.SqlClient;

namespace Dotnet.Dapper.Blog.Crud.Repositories
{
    public sealed class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection) : base(connection)
            => _connection = connection;
    }
}
