using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class UserRoleLinkScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link User/Role");
            Console.WriteLine("-------------");

            int userId = LineReader.GetValidIntInput("User Id");
            int roleId = LineReader.GetValidIntInput("Role Id");

            Link(userId, roleId);

            MenuScreen.ResetScreen();
        }

        public static void Link(int userId, int roleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.CreateUserRole(userId, roleId);
                Console.WriteLine("User and role linked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to link the user role.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
