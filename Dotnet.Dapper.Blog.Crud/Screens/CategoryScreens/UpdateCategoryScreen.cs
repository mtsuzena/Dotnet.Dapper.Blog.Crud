using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update Category");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            var name = LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Update(new Category
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            MenuCategoryScreen.ResetScreen();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                repository.Update(category);
                Console.WriteLine("Category updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to update the category");
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
