using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.LinkScreens
{
    public static class UserRoleUnlinkScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Unlink User/Role");
            Console.WriteLine("-------------");

            int userId = LineReader.GetValidIntInput("User Id");
            int roleId = LineReader.GetValidIntInput("Role Id");

            Unlink(userId, roleId);

            MenuScreen.ResetScreen();
        }

        public static void Unlink(int userId, int roleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.DeleteUserRole(userId, roleId);
                Console.WriteLine("User and role unlinked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to unlink the user and role.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
