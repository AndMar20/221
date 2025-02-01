class Program
{
    static void Main()
    {
        Console.Write("Введите путь к исходному каталогу: ");
        String? sourceDirectory = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task2.1";

        Console.Write("Введите путь к целевому каталогу: ");
        String? targetDirectory = @"C:\Temp\_000000000_Ispp21\LabWorks\LabWork13\Task2.2";

        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine("Исходный каталог не существует.");
            return;
        }

        if (!Directory.Exists(targetDirectory))
            Directory.CreateDirectory(targetDirectory);

        Dictionary<string, string> categories = new Dictionary<string, string>
        {
            { ".zip", "Архивы" }, { ".rar", "Архивы" }, { ".7z", "Архивы" },
            { ".jpeg", "Изображения" }, { ".jpg", "Изображения" }, { ".bmp", "Изображения" },
            { ".png", "Изображения" }, { ".gif", "Изображения" },
            { ".txt", "Текстовые документы" }, { ".rtf", "Текстовые документы" },
            { ".odt", "Текстовые документы" }, { ".doc", "Текстовые документы" },
            { ".docx", "Текстовые документы" }
        };

        String otherCategory = "Другое";
        String[] files = Directory.GetFiles(sourceDirectory);

        foreach (string file in files)
        {
            String extension = Path.GetExtension(file).ToLower();
            String category = categories.ContainsKey(extension) ? categories[extension] : otherCategory;
            String categoryDirectory = Path.Combine(targetDirectory, category);

            if (!Directory.Exists(categoryDirectory))
                Directory.CreateDirectory(categoryDirectory);

            String targetPath = Path.Combine(categoryDirectory, Path.GetFileName(file));
            File.Copy(file, targetPath, true);
            Console.WriteLine($"{file} скопирован");
        }

        Console.WriteLine("Копирование завершено.");
    }
}
