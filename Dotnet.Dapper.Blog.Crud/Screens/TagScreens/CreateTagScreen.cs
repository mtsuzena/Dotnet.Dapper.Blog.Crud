using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New Tag");
            Console.WriteLine("-------------");

            var name = LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });

            MenuTagScreen.ResetScreen();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to register the tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
