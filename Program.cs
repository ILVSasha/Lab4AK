using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceDirectory = "D:\\Лабораторна для АК\\Batch команди\\Лабораторні\\Група\\ПІБ\\batch\\Не прихована папка";
        string destinationDirectory = "D:\\Лабораторна для АК\\Лабораторна з АК\\Лабораторні\\Група\\ПІБ\\Командний рядок\\Не прихована папка";

        SynchronizeDirectories(sourceDirectory, destinationDirectory);

        Console.WriteLine("Синхронізація завершена.");
        Console.ReadLine();
    }

    static void SynchronizeDirectories(string sourceDir, string destinationDir)
    {
        DirectoryInfo sourceInfo = new DirectoryInfo(sourceDir);
        DirectoryInfo destinationInfo = new DirectoryInfo(destinationDir);

        // Перевіряємо, чи каталог призначення існує. Якщо ні, створюємо його.
        if (!destinationInfo.Exists)
        {
            destinationInfo.Create();
        }

        // Отримуємо список файлів у початковому каталозі
        FileInfo[] sourceFiles = sourceInfo.GetFiles();

        foreach (FileInfo sourceFile in sourceFiles)
        {
            string destinationFilePath = Path.Combine(destinationDir, sourceFile.Name);
            FileInfo destinationFile = new FileInfo(destinationFilePath);

            // Перевіряємо, чи файл вже існує у каталозі призначення
            if (!destinationFile.Exists || sourceFile.LastWriteTime > destinationFile.LastWriteTime)
            {
                // Копіюємо файл у каталог призначення
                sourceFile.CopyTo(destinationFilePath, true);
                Console.WriteLine("Скопійовано файл: " + sourceFile.Name);
            }
        }
    }
}
