using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Post");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            Delete(id);

            MenuPostScreen.ResetScreen();
        }

        public static void Delete(int id)
        {
            try
            { 
                var repository = new PostRepository(Database.Connection);
                repository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to delete the post.");
                Console.WriteLine(ex.Message);
                ResetScreen();
            }
        }

        private static void ResetScreen()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
