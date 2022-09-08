using System;
using System.IO;
using System.Linq;
using static GenericCreator.CreatorConfig;

namespace GenericCreator.Registrators;

public class RegisterEntity : LineFinder, IRegistrator
{

    public void Register(string entityName)
    {
        RegisterInStartup($"{ApiProjectLocation}/Startup.cs", entityName);
        RegisterTests($"{TestProjectLocation}/Tools/MapperFactory.cs", entityName);

    }

    private void RegisterInStartup(string path, string entityName)
    {
        string pattern = ".*\\.Register\\(services\\)\\;$";

        var line = FindLine(path, pattern);
        if (line > -1)
        {
            var registerLine = $"\t{entityName}Module.Register(services);\n";

            var allLines = File.ReadAllLines(path).ToList();
            allLines.Insert(line, registerLine);

            File.WriteAllLines(path, allLines.ToArray());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{entityName} registered in Startup.cs");
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
        var line = FindLine(path, pattern);
        if (line > -1)
        {
            var usingLine = $"using DataAccess.Services.{entityName};\n";

            var allLines = File.ReadAllLines(path).ToList();
            allLines.Insert(line, usingLine);

            File.WriteAllLines(path, allLines.ToArray());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{entityName}Module namespace added to Startup.cs");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find line matching pattern while adding namespace in Startup for {entityName}Module in Startup.cs");
        }

    }

    private void RegisterTests(string path, string entityName)
    {

        string pattern = ".*cfg\\.AddProfile\\<(.*)Profile\\>\\(\\)\\;$";

        var line = FindLine(path, pattern);
        if (line > -1)
        {
            var registerLine = $"\t\tcfg.AddProfile<{entityName}Profile>();\n";

            var allLines = File.ReadAllLines(path).ToList();
            allLines.Insert(line, registerLine);

            File.WriteAllLines(path, allLines.ToArray());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{entityName} registered in MapperFactory.cs");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot find line matching pattern while register in entity {entityName} in MapperFactory.cs");
        }
    }

   



}

