using Dotnet.Dapper.Blog.Crud.Repositories;
using Dotnet.Dapper.Blog.Crud.Utils;

namespace Dotnet.Dapper.Blog.Crud.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma permissão");
            Console.WriteLine("-------------");

            var id = LineReader.GetValidIntInput("Id");
            Delete(id);

            MenuRoleScreen.ResetScreen();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new RoleRepository(Database.Connection);
                repository.Delete(id);
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine("Não foi possivel deletar a permissão");
                    Console.WriteLine(ex.Message);
                    ResetScreen();
                }
            }
        }

        public static void ResetScreen()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Load();
        }
    }
}
