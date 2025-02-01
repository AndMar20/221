using System;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        string? path;
        while (true)
        {
            try
            {
                Console.Write("Введите имя файла: ");
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.WriteLine("Файл с этим именем не существует. Он будет создан");
                    using (File.Create(path));
                }
                else
                    Console.WriteLine("Файл открыт на дозапись: ");
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Непредвиденная ошибка");
            }
        }

        using (StreamWriter sw = File.AppendText(path))
        {
            string? input;
            do
            {
                Console.WriteLine("Введите строку для записи, чтобы закончить дозапись введите 'end': ");
                input = Console.ReadLine();
                if (input != "end")
                    sw.WriteLine(input);
            }
            while (input != "end");
        }
        Console.WriteLine("Запись файла завершена");
        Console.ReadKey();

        using StreamReader sr = File.OpenText(path);
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
    }
}