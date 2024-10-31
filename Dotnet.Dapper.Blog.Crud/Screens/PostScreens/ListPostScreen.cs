using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;

namespace Dotnet.Dapper.Blog.Crud.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of Posts");
            Console.WriteLine("-------------");

            List();

            MenuPostScreen.ResetScreen();
        }

        private static void List()
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                var posts = repository.GetWithAuthorAndCategoryAndTags();

                if (posts.Any())
                    foreach (var post in posts) 
                        PrintPostDetails(post);
                else
                    Console.WriteLine("No posts found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while listing the posts.");
                Console.WriteLine(ex.Message);
                MenuPostScreen.ResetScreen();
            }
        }

        private static void PrintPostDetails(Post post)
        {
            var details = $"Id: {post.Id}\n" +
                          $"Title: {post.Title}\n" +
                          $"Summary: {post.Summary}\n" +
                          $"Body: {post.Body}\n" +
                          $"Slug: {post.Slug}\n" +
                          $"CreateDate: {post.CreateDate}\n" +
                          $"LastUpdateDate: {post.LastUpdateDate}\n";

            if (post.Author != null)
                details += $"Author: {post.Author.Name}\n";

            if (post.Category != null)
                details += $"Category: {post.Category.Name}\n";

            if (post.Tags.Count > 0)
            {
                details += "Tags: " + string.Join(", ", post.Tags.Select(tag => tag.Name)) + "\n";
            }

            details += "\n";
            Console.WriteLine(details);
        }
    }
}
