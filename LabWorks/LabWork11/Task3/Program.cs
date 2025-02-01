using System;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        string path = "";
        string input = "";
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-path")
                path = args[i + 1];
            if (args[i] == "-input")
                input = args[i + 1];
        }

        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл не существует");
            return;
        }
        var lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(input))
                Console.WriteLine($"Строка {i + 1}: {lines[i]}");
        }
            
    }
}