// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;using GenericCreator;
using GenericCreator.Creators;
using GenericCreator.Registrators;


string entityName = Environment.GetCommandLineArgs()[1];

var options = Environment.GetCommandLineArgs().Where(x => x.StartsWith('-')).ToList();



Console.WriteLine($"parametr: {entityName}");

if (options.Contains("--a") || options.Contains("-a"))
{
    new ServiceCreator().Create(entityName);
    new ModelsCreator().Create(entityName);
    new TestsCreator().Create(entityName);
    new RegisterEntity().Register(entityName);
}
else
{
    if (options.Contains("--s") || options.Contains("-s"))
    {
        new ServiceCreator().Create(entityName);
    }
    if (options.Contains("--m") || options.Contains("-m"))
    {
        new ModelsCreator().Create(entityName);
    }
    if (options.Contains("--t") || options.Contains("-m"))
    {
        new TestsCreator().Create(entityName);
    }
    if (options.Contains("--r") || options.Contains("-r"))
    {
        new RegisterEntity().Register(entityName);
    }
}




