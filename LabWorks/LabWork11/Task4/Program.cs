using System;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        List<string> logins = [];
        using (StreamReader sr = new(@"C:\Temp\ispp21\LabWorks\LabWork11\logins.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(";");
                logins.Add(values[0]);
            }  
        };
        Console.Write("Введите логин: ");
        string login = Console.ReadLine();
        while (logins.Contains(login))
        {
            Console.WriteLine("Логин занят введите другой: ");
            login = Console.ReadLine();
        }
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        File.AppendAllText(@"C:\Temp\ispp21\LabWorks\LabWork11\logins.txt", $"{login};{password};{DateTime.Now:dd.mm.yyyy} \n");
    }
}