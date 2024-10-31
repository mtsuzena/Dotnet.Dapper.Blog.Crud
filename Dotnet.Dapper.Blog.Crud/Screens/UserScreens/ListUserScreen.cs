using Dotnet.Dapper.Blog.Crud.Repositories;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of Users");
            Console.WriteLine("-------------");

            List();

            MenuUserScreen.ResetScreen();
        }

        private static void List()
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                var users = repository.GetWithRoles();

                if (users.Any())
                {
                    foreach (var user in users)
                    {
                        var roles = string.Join(", ", user.Roles.Select(role => role.Name));
                        Console.WriteLine($"{user.Id} - Name: {user.Name} - Email: {user.Email} - Permissions: {roles}");
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while listing the users.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
