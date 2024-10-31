using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a Tag");
            Console.WriteLine("-------------");

            int id = LineReader.GetValidIntInput("Id");
            Delete(id);

            MenuTagScreen.ResetScreen();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to delete the tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
