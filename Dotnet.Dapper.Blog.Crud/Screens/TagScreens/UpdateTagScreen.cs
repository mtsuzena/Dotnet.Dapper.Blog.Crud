using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Updating a Tag");
            Console.WriteLine("-------------");

            int id = LineReader.GetValidIntInput("Id");
            var name = LineReader.GetValidInput("Name");
            var slug = LineReader.GetValidInput("Slug");

            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            MenuTagScreen.ResetScreen();
        }

        public static void Update(Tag tagUpdated)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);

                var tag = repository.Get(tagUpdated.Id);
                if (tag == null)
                    throw new Exception("Tag not found.");

                repository.Update(tagUpdated);
                Console.WriteLine("Tag updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to update the tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
