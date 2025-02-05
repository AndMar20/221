class Program
{
    static void Main()
    {
        Console.Write("Введите путь к исходному каталогу: ");
        string? sourceDirectory = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task2.1";

        Console.Write("Введите путь к целевому каталогу: ");
        string? targetDirectory = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task2.2";

        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine("Исходный каталог не существует.");
            return;
        }

        if (!Directory.Exists(targetDirectory))
            Directory.CreateDirectory(targetDirectory);

        string otherCategory = "Другое";
        string[] files = Directory.GetFiles(sourceDirectory);

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            string category;

            switch(extension)
            {
                case ".zip":
                case ".rar":
                case ".7z":
                    category = "Архивы";
                    break;
                case ".jpeg":
                case ".jpg":
                case ".bmp":
                case ".png":
                case ".gif":
                    category = "Изображения";
                    break;
                case ".txt":
                case ".rtf":
                case ".odt":
                case ".doc":
                case ".docx":
                    category = "Теекстовые документы";
                    break;
                default:
                    category = otherCategory;
                    break;
            }
            string categoryDirectory = Path.Combine(targetDirectory, category);

            if (!Directory.Exists(categoryDirectory))
                Directory.CreateDirectory(categoryDirectory);

            string targetPath = Path.Combine(categoryDirectory, Path.GetFileName(file));
            File.Copy(file, targetPath, true);
            Console.WriteLine($"{file} скопирован");
        }

        Console.WriteLine("Копирование завершено.");
    }
}
