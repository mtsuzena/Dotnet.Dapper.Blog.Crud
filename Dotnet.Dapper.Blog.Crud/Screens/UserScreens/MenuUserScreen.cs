using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("User Management");
            Console.WriteLine("--------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - List users");
            Console.WriteLine("2 - Register user");
            Console.WriteLine("3 - Update user");
            Console.WriteLine("4 - Delete user");
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
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
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
