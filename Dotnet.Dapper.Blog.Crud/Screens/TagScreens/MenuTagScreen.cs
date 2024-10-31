using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Tag Management");
            Console.WriteLine("--------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - List tags");
            Console.WriteLine("2 - Register tag");
            Console.WriteLine("3 - Update tag");
            Console.WriteLine("4 - Delete tag");
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
                    ListTagScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
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
