// See https://aka.ms/new-console-template for more information

using System;
using GenericCreator.Creators;



string entityName = Environment.GetCommandLineArgs()[1];
Console.WriteLine($"parametr: {entityName}");


new ServiceCreator().Create(entityName);
new ModelsCreator().Create(entityName);
new TestsCreator().Create(entityName);