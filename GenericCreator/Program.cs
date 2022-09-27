// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using GenericCreator;
using GenericCreator.Creators;
using GenericCreator.Registrators;


string entityName = Environment.GetCommandLineArgs()[1];

var options = Environment.GetCommandLineArgs().Where(x => x.StartsWith('-')).ToList();



if (options.Contains("--all") || options.Contains("-all"))
{
    if (entityName.ToLower() == "all")
    {
        Console.WriteLine("You have to use this command for every entity separately.");
    }
    new ServiceCreator().Create(entityName);
    new ControllerCreator().Create(entityName);

    new ModelsCreator().Create(entityName);
    new TestsCreator().Create(entityName);
    new StartupRegistrator().Register(entityName);
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
        new StartupRegistrator().Register(entityName);
    }

    if (options.Contains("--obj") || options.Contains("-obj"))
    {
        if (entityName=="all")
        {
            new RegisterAnonymousMapper().Register();
        }
        else
        {
            Console.WriteLine($"registering anonymous object mapping for {entityName}Dto");
            new RegisterAnonymousMapper().Register(entityName);
        }
    }

}








