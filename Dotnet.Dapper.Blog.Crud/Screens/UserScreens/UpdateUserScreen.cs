using Dotnet.Dapper.Blog.Crud.Models;
using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Updating a User");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            var name = LineReader.GetValidInput("Name");
            var email = LineReader.GetValidInput("Email");
            var passwordHash = LineReader.GetValidInput("Password");
            var bio = LineReader.GetValidInput("Bio");
            var image = LineReader.GetValidInput("Image Path");
            var slug = LineReader.GetValidInput("Slug");

            Update(new User
            {
                Id = id,
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            });

            MenuUserScreen.ResetScreen();
        }

        public static void Update(User userUpdated)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);

                var user = repository.Get(userUpdated.Id);
                if (user == null)
                    throw new Exception("User not found.");

                repository.Update(userUpdated);

                Console.WriteLine("User updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("It was not possible to update the user.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
