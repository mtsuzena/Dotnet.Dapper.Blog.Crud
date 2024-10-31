using Dotnet.Dapper.Blog.Crud;
using Dotnet.Dapper.Blog.Crud.Screens;
using Microsoft.Data.SqlClient;

namespace Dotnet.Dappter.Blog.Crud
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            MenuScreen.Load();

            Database.Connection.Close();
            Console.ReadKey();
        }        
    }
}
