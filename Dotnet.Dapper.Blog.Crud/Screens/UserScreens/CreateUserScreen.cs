using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New User");
            Console.WriteLine("-------------");

            string name = LineReader.GetValidInput("Name");
            string email = LineReader.GetValidInput("Email");
            string passwordHash = LineReader.GetValidInput("Password");
            string bio = LineReader.GetValidInput("Bio");
            string image = LineReader.GetValidInput("Image Path");
            string slug = LineReader.GetValidInput("Slug");

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            });

            MenuUserScreen.ResetScreen();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Create(user);
                Console.WriteLine("User registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to register the user.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
