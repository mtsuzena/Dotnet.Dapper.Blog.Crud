using Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens;
using Dotnet.Dapper.Blog.Crud.Screens.PostScreens;
using Dotnet.Dapper.Blog.Crud.Screens.RoleScreens;
using Dotnet.Dapper.Blog.Crud.Screens.TagScreens;
using Dotnet.Dapper.Blog.Crud.Screens.UserScreens;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens
{
    public static class MenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("My Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - Post Management");
            Console.WriteLine("2 - User Management");
            Console.WriteLine("3 - Role Management");
            Console.WriteLine("4 - Category Management");
            Console.WriteLine("5 - Tag Management");
            Console.WriteLine("6 - Link Management");
            Console.WriteLine();

            try
            {
                var option = LineReader.GetValidIntInput("Option");
                HandleOption(option);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                ResetScreen();
            }
        }

        private static void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    MenuPostScreen.Load();
                    break;
                case 2:
                    MenuUserScreen.Load();
                    break;
                case 3:
                    MenuRoleScreen.Load();
                    break;
                case 4:
                    MenuCategoryScreen.Load();
                    break;
                case 5:
                    MenuTagScreen.Load();
                    break;          
                case 6:
                    LinkManagementScreen.Load();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid number.");
                    ResetScreen();
                    break;
            }
        }

        public static void ResetScreen()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
