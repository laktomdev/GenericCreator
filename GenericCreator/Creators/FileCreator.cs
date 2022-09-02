using System;
using System.IO;
using System.Text;

namespace GenericCreator.Creators;

public abstract class FileCreator
{
    public void CreateFile(string filePath, string fileText)
    {
        if (!File.Exists(filePath))
        {
            using FileStream fs = File.Create(filePath);
            byte[] info = new UTF8Encoding(true).GetBytes(fileText);
            fs.Write(info, 0, info.Length);
            
            Console.WriteLine($"{filePath} created!", ConsoleColor.Green);
        }
        else
        {
            Console.WriteLine($"{filePath} allready exists!", ConsoleColor.Red);
        }
    }
}