using Dotnet.Dapper.Blog.Crud.Repositories;

namespace Dotnet.Dapper.Blog.Crud.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of Categories");
            Console.WriteLine("-------------");

            List();

            MenuCategoryScreen.ResetScreen();
        }

        private static void List()
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                var categories = repository.Get();

                if (categories.Any())
                {
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Id} - Name: {category.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("No categories found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while listing the categories.");
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
