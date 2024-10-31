using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Dapper.Blog.Crud.Utils
{
    public static class LineReader
    {
        public static string GetValidInput(string fieldName)
        {
            string input;
            do
            {
                Console.Write($"{fieldName}: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine($"{fieldName} cannot be empty. Please enter a valid {fieldName.ToLower()}.");
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static int GetValidIntInput(string fieldName)
        {
            int input;
            while (true)
            {
                Console.Write($"{fieldName}: ");
                if (int.TryParse(Console.ReadLine(), out input)) break;
                Console.WriteLine($"Invalid input. Please enter a valid number for {fieldName}.");
            }
            return input;
        }
    }
}
