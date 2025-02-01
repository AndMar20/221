
class Program
{
    static void Main()
    {
        Console.Write("Введите путь к каталогу: ");
        String directoryPath = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task3.1";

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Указанный каталог не существует.");
            return;
        }

        String[] files = Directory.GetFiles(directoryPath);

        foreach (string file in files)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(file);

            String year = lastWriteTime.Year.ToString();
            String month = lastWriteTime.Month.ToString();
            String day = lastWriteTime.Day.ToString();

            String targetDirectory = Path.Combine(directoryPath, year, month, day);

            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);

            String targetPath = Path.Combine(targetDirectory, Path.GetFileName(file));

            File.Move(file, targetPath);
            Console.WriteLine($"{file}  перемещен");
        }

        Console.WriteLine("Сортировка по дате изменения завершена.");
    }
}