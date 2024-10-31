using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Role Management");
            Console.WriteLine("--------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - List roles");
            Console.WriteLine("2 - Register role");
            Console.WriteLine("3 - Update role");
            Console.WriteLine("4 - Delete role");
            Console.WriteLine("5 - Return to main menu");
            Console.WriteLine();

            var option = LineReader.GetValidIntInput("Option");
            HandleOption(option);
        }

        private static void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                case 5:
                    MenuScreen.Load();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid number.");
                    ResetScreen();
                    break;
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
