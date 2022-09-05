using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace GenericCreator.Registrators;

public class RegisterEntity : LineFinder, IRegistrator
{

    public void Register(string entityName)
    {
        RegisterInStartup("../Diagprog4Api/Startup.cs", entityName);
        RegisterTests("../../tests/RefactoredInfrastructureTests/Tools/MapperFactory.cs", entityName);

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

