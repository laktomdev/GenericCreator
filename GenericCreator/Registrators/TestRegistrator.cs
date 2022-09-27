using System;
using System.IO;
using System.Linq;
using static GenericCreator.CreatorConfig;

namespace GenericCreator.Registrators;

public class TestRegistrator : LineFinder, IRegistrator
{

    public void Register(string entityName)
    {
        RegisterTests($"{TestProjectLocation}/Tools/MapperFactory.cs", entityName);
    }

    private void RegisterTests(string path, string entityName)
    {

        string pattern = ".*cfg\\.AddProfile\\<(.*)Profile\\>\\(\\)\\;$";

        var lineNumber = FindLine(path, pattern);
        if (lineNumber > -1)
        {
            var lineToAdd = $"cfg.AddProfile<{entityName}Profile>();";
            AddLineToFile(lineNumber, lineToAdd, path);

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find line matching pattern while register in entity {entityName} in MapperFactory.cs");
        }
    }



}