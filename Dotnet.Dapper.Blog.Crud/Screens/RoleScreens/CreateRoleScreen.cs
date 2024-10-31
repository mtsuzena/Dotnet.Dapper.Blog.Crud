using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New Role");
            Console.WriteLine("-------------");

            var name =  LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Create(new Role
            {
                Name = name,
                Slug = slug
            });

            MenuRoleScreen.ResetScreen();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new RoleRepository(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Role successfully registered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to register the role.");
                Console.WriteLine(ex.Message);
                ResetScreen();
            }
        }

        private static void ResetScreen()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
