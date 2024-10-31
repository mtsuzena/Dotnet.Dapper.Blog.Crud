using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class PostTagLinkScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link Post/Tag");
            Console.WriteLine("-------------");

            int postId = LineReader.GetValidIntInput("Post Id");
            int tagId = LineReader.GetValidIntInput("Tag Id");

            Link(postId, tagId);

            MenuScreen.ResetScreen();
        }

        public static void Link(int postId, int tagId)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.CreatePostTag(postId, tagId);
                Console.WriteLine("Post and tag linked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to link the post and tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
