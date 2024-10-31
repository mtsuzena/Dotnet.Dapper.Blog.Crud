using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New Post");
            Console.WriteLine("-------------");

            var title = LineReader.GetValidInput("Title");
            var summary = LineReader.GetValidInput("Summary");
            var body = LineReader.GetValidInput("Body");
            var slug = LineReader.GetValidInput("Slug");
            var authorId = LineReader.GetValidIntInput("Author ID");
            var categoryId = LineReader.GetValidIntInput("Category ID");

            Create(new Post
            {
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                AuthorId = authorId,
                CategoryId = categoryId
            });

            MenuPostScreen.ResetScreen();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to register the post.");
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
