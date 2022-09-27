using System;
using System.IO;
using System.Linq;
using static GenericCreator.CreatorConfig;

namespace GenericCreator.Registrators;

public class StartupRegistrator : LineFinder, IRegistrator
{

    public void Register(string entityName)
    {
        AddModuleRegister($"{ApiProjectLocation}/Startup.cs", entityName);
    

    }

    private void AddModuleRegister(string path, string entityName)
    {
        string pattern = ".*\\.Register\\(services\\)\\;$";

        var lineNumber = FindLine(path, pattern);
        if (lineNumber > -1)
        {
            string lineToAdd = $"{entityName}Module.Register(services);";
            AddLineToFile(lineNumber, lineToAdd, path);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find line matching pattern while register in entity {entityName} in Startup.cs");
        }

        AddStartupUsings(path, entityName);

    }

    private void AddStartupUsings(string path, string entityName)
    {
        string pattern = "using.*;";
        var lineNumber = FindLine(path, pattern);
        if (lineNumber > -1)
        {
            var lineToAdd = $"using DataAccess.Services.{entityName};";

            AddLineToFile(lineNumber, lineToAdd, path);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find line matching pattern while adding namespace in Startup for {entityName}Module in Startup.cs");
        }

    }




}

