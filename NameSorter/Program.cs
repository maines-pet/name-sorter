using System;
using System.IO;
using Utilities;

namespace NameSorter
{
    class Program
    {
        public const string DefaultOutputFilePath = "sorted-names-list.txt";
        static void Main(string[] args)
        {
            ArgumentsValidation(args);

            var filePath = args[0];
            var outputFilePath = args.Length == 2 ? args[1] : DefaultOutputFilePath;

            string[] allNames = File.ReadAllLines(filePath);

            var sortedNames = NameSort.SortNames(allNames);
            sortedNames.ForEach(Console.WriteLine);

            //With this approach, no new line characters are added at the end of the file as opposed to File.WriteAllLines
            File.WriteAllText(outputFilePath, String.Join(Environment.NewLine, sortedNames));
        }

        public static void ArgumentsValidation(string[] args)
        {
            var paramCount = args.Length;
            if (paramCount == 0)
            {
                Console.WriteLine($"\nUsage: dotnet [input-file-path] [optional-output-file-path]\n");
                return;
            }
            if (paramCount > 2)
            {
                Console.WriteLine("Invalid number of parameters supplied. Program accepts maximum of 2 parameters.");
            }
            if (String.IsNullOrEmpty(args[0]) || !File.Exists(args[0]))
            {
                Console.WriteLine("File cannot be found. Please try again");
                return;
            }
        }
    }
}
