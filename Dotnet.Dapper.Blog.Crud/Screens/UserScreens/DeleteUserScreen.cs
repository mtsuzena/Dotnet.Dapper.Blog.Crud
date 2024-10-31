using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a User");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            Delete(id);

            MenuUserScreen.ResetScreen();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to delete the user.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
