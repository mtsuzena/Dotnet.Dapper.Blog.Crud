using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Post Management");
            Console.WriteLine("--------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - List posts");
            Console.WriteLine("2 - Register post");
            Console.WriteLine("3 - Update post");
            Console.WriteLine("4 - Delete post");
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
                    ListPostScreen.Load();
                    break;
                case 2:
                    CreatePostScreen.Load();
                    break;
                case 3:
                    UpdatePostScreen.Load();
                    break;
                case 4:
                    DeletePostScreen.Load();
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
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
