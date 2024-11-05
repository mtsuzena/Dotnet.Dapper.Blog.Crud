using Dotnet.Dapper.Blog.Crud.Screens.LinkScreens;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class MenuLinkScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link Management");
            Console.WriteLine("-------------");
            Console.WriteLine("What do you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - Link Post/Tag");
            Console.WriteLine("2 - Unlink Post/Tag");
            Console.WriteLine("3 - Link User/Role");
            Console.WriteLine("4 - Unlink User/Role");
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
                    PostTagLinkScreen.Load();
                    break;
                case 2:
                    PostTagUnlinkScreen.Load();
                    break;
                case 3: 
                    UserRoleLinkScreen.Load();
                    break;
                case 4: 
                    UserRoleUnlinkScreen.Load();
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
