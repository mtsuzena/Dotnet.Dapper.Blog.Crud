using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete Category");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            Delete(id);

            MenuCategoryScreen.ResetScreen();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to delete the category.");
                Console.WriteLine(ex.Message);
                ResetScreen();
            }
        }

        private static void ResetScreen()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
