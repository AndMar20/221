class Program
{
    static void Main()
    {
        Console.Write("Введите путь к каталогу: ");
        string? directoryPath = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task1.1";

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Указанный каталог не существует.");
            return;
        }

        string[] files = Directory.GetFiles(directoryPath);

        foreach (string file in files)
        {
            String extension = Path.GetExtension(file).TrimStart('.').ToUpper();

            String targetDirectory = Path.Combine(directoryPath, extension);

            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);

            String targetPath = Path.Combine(targetDirectory, Path.GetFileName(file));

            File.Move(file, targetPath);
            Console.WriteLine($"{file} перемещен");
        }

        Console.WriteLine("Сортировка завершена.");
    }
}
