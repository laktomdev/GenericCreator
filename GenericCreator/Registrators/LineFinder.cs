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
            var qq = lines.Where(x => Regex.Match(x, pattern, RegexOptions.IgnoreCase).Success).ToList();

            var line =
                lines.Select((text, index) => new { text, index }).LastOrDefault(x => Regex.IsMatch(x.text, pattern, RegexOptions.IgnoreCase))!.index;

            return line + 1;
        }
    }

    protected int FindLineAfterCommon(string filePath)
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

}