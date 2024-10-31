using Dapper.Contrib.Extensions;

namespace Dotnet.Dapper.Blog.Crud.Models
{
    [Table("[User]")]
    public sealed class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public List<Role> Roles { get; set; }

        public User()
            => Roles = new List<Role>();
    }
}
