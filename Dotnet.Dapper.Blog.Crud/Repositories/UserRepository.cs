using Dapper;
using Dapper.Contrib.Extensions;
using Dotnet.Dapper.Blog.Crud.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace Dotnet.Dapper.Blog.Crud.Repositories
{
    public sealed class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var existingUser = users.FirstOrDefault(x => x.Id == user.Id);
                    if (existingUser == null)
                    {
                        existingUser = user;
                        if (role != null)
                            existingUser.Roles.Add(role);
                        users.Add(existingUser);
                    }
                    else
                        existingUser.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }

        public async void CreateUserRole(int userId, int roleId)
        {
            var insert = @"
                INSERT INTO 
                    [UserRole]
                VALUES (
                    @UserId,
                    @RoleId
                )";

            await _connection.ExecuteAsync(insert, new { UserId = userId, RoleId = roleId });
        }
        public async void DeleteUserRole(int userId, int roleId)
        {
            var delete = @"
                DELETE FROM 
	                [UserRole]
                WHERE 
	                UserId = @UserId
	                AND RoleId = @RoleId";

            await _connection.ExecuteAsync(delete, new { UserId = userId, RoleId = roleId });
        }
    }
}
