using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update a Post");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            var title = LineReader.GetValidInput("Title");
            var summary = LineReader.GetValidInput("Summary");
            var body = LineReader.GetValidInput("Body");
            var slug = LineReader.GetValidInput("Slug");
            var authorId = LineReader.GetValidIntInput("Author ID");
            var categoryId = LineReader.GetValidIntInput("Category ID");

            Update(new Post
            {
                Id = id,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                LastUpdateDate = DateTime.Now,
                AuthorId = authorId,
                CategoryId = categoryId
            });

            MenuPostScreen.ResetScreen();
        }

        

        public static void Update(Post postUpdated)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);

                var post = repository.Get(postUpdated.Id);
                if (post == null)
                    throw new Exception("Post not found.");

                postUpdated.CreateDate = post.CreateDate;

                repository.Update(postUpdated);
                Console.WriteLine("Post updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to update the post.");
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
