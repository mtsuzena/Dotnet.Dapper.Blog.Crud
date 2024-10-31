using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Category Management");
            Console.WriteLine("--------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1 - List categories");
            Console.WriteLine("2 - Register category");
            Console.WriteLine("3 - Update category");
            Console.WriteLine("4 - Delete category");
            Console.WriteLine("5 - Return to main menu");
            Console.WriteLine();

            var option = LineReader.GetValidIntInput("Option");
            HandleOption(option);
        }

        public static void ResetScreen()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Load();
        }

        private static void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
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
    }
}
