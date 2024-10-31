using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New Category");
            Console.WriteLine("-------------");

            var name = LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

            MenuCategoryScreen.ResetScreen();
        }

        public static void Create(Category category)
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Category registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to register the category");
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
