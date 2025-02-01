string path = "";
while (true)
{
    try
    {
        Console.Write("Введите имя файла: ");
        path = Console.ReadLine();
        File.OpenRead(path);
        break;
    }
    catch (FileNotFoundException e)
    {
        Console.WriteLine("Файл с таким именем не существует");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Непредвиденная ошибка");
    }
}
using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }
}
