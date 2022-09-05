using System;
using System.IO;
using System.Linq;
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
            var qq = lines.Where(x => Regex.Match(x, pattern, RegexOptions.IgnoreCase).Success).ToList();

            var line =
                lines.Select((text, index) => new { text, index }).LastOrDefault(x => Regex.IsMatch(x.text, pattern, RegexOptions.IgnoreCase))!.index;

            return line + 1;
        }
    }
}