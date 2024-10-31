using Dotnet.Dapper.Blog.Crud.Repositories;

namespace Dotnet.Dapper.Blog.Crud.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of Tags");
            Console.WriteLine("-------------");

            List();

            MenuTagScreen.ResetScreen();
        }

        private static void List()
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                var tags = repository.Get();

                if (tags.Any())
                {
                    foreach (var tag in tags)
                    {
                        Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
                    }
                }
                else
                {
                    Console.WriteLine("No tags found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while listing the tags.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
