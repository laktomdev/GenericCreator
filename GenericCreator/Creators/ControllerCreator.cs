using System;
using System.IO;
using static GenericCreator.CreatorConfig;
using static GenericCreator.Templates.Templates;

namespace GenericCreator.Creators;

public class ControllerCreator : FileCreator, ICreator
{
    public void Create(string entityName)
    {
        var controllersPath = Directory.CreateDirectory($"{ControllersLocation}").FullName;
        CreateControllerClass(controllersPath, entityName);
    }


    private void CreateControllerClass(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"{entityName}sController.cs");
        var classText = ControllerTemplate(entityName);

        CreateFile(filePath, classText);
    }
}

