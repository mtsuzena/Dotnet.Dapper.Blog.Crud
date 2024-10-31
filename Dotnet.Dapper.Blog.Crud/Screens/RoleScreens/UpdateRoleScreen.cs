using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Updating a Role");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            var name = LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Update(new Role
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            MenuRoleScreen.ResetScreen();
        }

        public static void Update(Role roleUpdated)
        {
            try
            {
                var repository = new RoleRepository(Database.Connection);

                var role = repository.Get(roleUpdated.Id);
                if (role == null)
                    throw new Exception("Role not found.");

                repository.Update(roleUpdated);

                Console.WriteLine("Role updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to update the role.");
                Console.WriteLine(ex.Message);
                ResetScreen();
            }
        }

        public static void ResetScreen()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
