using Dapper;
using Dotnet.Dapper.Blog.Crud.Models;
using Microsoft.Data.SqlClient;

namespace Dotnet.Dapper.Blog.Crud.Repositories
{
    public sealed class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Post> GetWithAuthorAndCategoryAndTags()
        {
            var query = @"
                SELECT 
                    [Post].*,
                    [User].*,
                    [Category].*,
                    [Tag].*
                FROM
                    [Post]
                LEFT JOIN [User] ON [User].[Id] = [Post].[AuthorId]
                LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                LEFT JOIN [Tag] ON [Tag].[Id] = [PostTag].[TagId]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, User, Category, Tag, Post>(
                query,
                (post, user, category, tag) =>
                {
                    var postFound = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (postFound == null)
                    {
                        postFound = post;

                        if (user != null)
                            postFound.Author = user;

                        if(category != null) 
                            postFound.Category = category;

                        if (tag != null)
                            post.Tags.Add(tag);

                        posts.Add(postFound);
                    }
                    else
                        postFound.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }

        public async void CreatePostTag(int postId, int tagId)
        {
            var insert = @"
                INSERT INTO 
                    [PostTag]
                VALUES (
                    @PostId,
                    @TagId
                )";

            await _connection.ExecuteAsync(insert, new { PostId = postId, TagId = tagId });
        }

        public async void DeletePostTag(int postId, int tagId)
        {
            var delete = @"
                DELETE FROM 
	                [PostTag]
                WHERE 
	                PostId = @PostId
	                AND TagId = @TagId";

            await _connection.ExecuteAsync(delete, new { PostId = postId,TagId = tagId });      
        }            
    }
}
