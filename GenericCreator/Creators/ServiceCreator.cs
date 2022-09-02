using System.IO;
using System.Text;
using static GenericCreator.Templates.Templates;

namespace GenericCreator.Creators;

public class ServiceCreator : FileCreator, ICreator
{
    public void Create(string entityName)
    {
        var path = Directory.CreateDirectory($"Services/{entityName}").FullName;
        CreateRepoInterface(path, entityName);
        CreateRepoClass(path, entityName);
        CreateServiceClass(path, entityName);
        CreateServiceInterface(path, entityName);
        CreateModuleClass(path, entityName);

        var controllersPath = Directory.CreateDirectory($"../Diagprog4Api/Controllers/").FullName;
        CreateControllerClass(controllersPath, entityName);
    }

    private void CreateServiceClass(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"{entityName}Service.cs");
       
        var classText = ServiceTemplate(entityName);
        CreateFile(filePath, classText);
    }

    private void CreateServiceInterface(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"I{entityName}Service.cs");
        var classText = IServiceTemplate(entityName);

        CreateFile(filePath, classText);
    }

    private void CreateRepoInterface(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"I{entityName}Repository.cs");
        var classText = IRepositoryTemplate(entityName);

        CreateFile(filePath, classText);
    }

    private void CreateRepoClass(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"{entityName}Repository.cs");
        var classText = RepositoryTemplate(entityName);

        CreateFile(filePath, classText);
    }

    private void CreateModuleClass(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"{entityName}Module.cs");
        var classText = ModuleTemplate(entityName);

        CreateFile(filePath, classText);
    }


    private void CreateControllerClass(string dirPath, string entityName)
    {
        var filePath = Path.Combine(dirPath, $"{entityName}sConroller.cs");
        var classText = ControllerTemplate(entityName);

        CreateFile(filePath, classText);
    }


}