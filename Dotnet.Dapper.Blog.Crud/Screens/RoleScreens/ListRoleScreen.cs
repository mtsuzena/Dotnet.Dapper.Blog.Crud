using Dotnet.Dapper.Blog.Crud.Repositories;

namespace Dotnet.Dapper.Blog.Crud.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of Roles");
            Console.WriteLine("-------------");

            List();

            MenuRoleScreen.ResetScreen();
        }

        private static void List()
        {
            try
            {
                var repository = new RoleRepository(Database.Connection);
                var roles = repository.Get();

                if (roles.Any())
                {
                    foreach (var role in roles)
                    {
                        Console.WriteLine($"{role.Id} - Name: {role.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("No roles found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while listing the roles.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
