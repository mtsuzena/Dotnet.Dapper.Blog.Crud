using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.LinkScreens
{
    public static class PostTagUnlinkScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Unlink Post/Tag");
            Console.WriteLine("-------------");

            int postId = LineReader.GetValidIntInput("Post Id");
            int tagId = LineReader.GetValidIntInput("Tag Id");

            Unlink(postId, tagId);

            MenuScreen.ResetScreen();
        }

        public static void Unlink(int postId, int tagId)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.DeletePostTag(postId, tagId);
                Console.WriteLine("Post and tag unlinked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to unlink the post and tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
