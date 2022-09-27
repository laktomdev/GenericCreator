using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;



namespace GenericCreator.Registrators;

public abstract class LineFinder
{
    protected int FindLine(string filePath, string pattern)
    {

        if (!File.Exists(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find file: {filePath}");
            return -1;
        }
        else
        {
            string[] lines = File.ReadAllLines(filePath);
            var line =
                lines.Select((text, index) => new { text, index }).LastOrDefault(x => Regex.IsMatch(x.text, pattern, RegexOptions.IgnoreCase))!.index;

            return line + 1;
        }
    }

    protected int FindLineAfterSemicolon(string filePath)
    {

        if (!File.Exists(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find file: {filePath}");
            return -1;
        }
        else
        {

            string[] lines = File.ReadAllLines(filePath);


            var line = lines.Select((text, index) => new { text, index }).LastOrDefault(x => x.text.Contains(';'))!.index;


            return line + 1;
        }
    }

    protected void AddLineToFile(int lineNumber, string lineToAdd, string filePath)
    {
        var formattedLine = $"\t\t{lineToAdd}\n";

        var allLines = File.ReadAllLines(filePath).ToList();
        allLines.Insert(lineNumber, formattedLine);

        if (allLines.Any(x => x.Contains(lineToAdd)))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"line: \"{lineToAdd}\" allready exists in {Path.GetFileName(filePath)}");
            return;
        }

        File.WriteAllLines(filePath, allLines.ToArray());

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"line: \"{lineToAdd}\" successfully added to {Path.GetFileName(filePath)}");

    }

}