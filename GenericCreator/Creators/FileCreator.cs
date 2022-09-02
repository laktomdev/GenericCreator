using System;
using System.Diagnostics;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{filePath} created!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{filePath} allready exists!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}