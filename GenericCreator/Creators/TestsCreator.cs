using System.IO;
using static GenericCreator.Templates.Templates;

namespace GenericCreator.Creators;

public class TestsCreator : FileCreator, ICreator
{

    public void Create(string entityName)
    {
        var repoTestsPath = Directory.CreateDirectory("../../tests/RefactoredInfrastructureTests/RepositoryTests").FullName;
        var servicesTestsPath = Directory.CreateDirectory("../../tests/RefactoredInfrastructureTests/ServicesTests").FullName;
        CreateRepoTests(repoTestsPath, entityName);
        CreateServicesTests(servicesTestsPath, entityName);
    }

    private void CreateServicesTests(string servicesTestsPath, string entityName)
    {
        var filePath = Path.Combine(servicesTestsPath, $"Get{entityName}sWithService.cs");
        var classText = ServiceTestsTemplate(entityName);
        CreateFile(filePath, classText);
    }

    private void CreateRepoTests(string repoTestsPath, string entityName)
    {
        var filePath = Path.Combine(repoTestsPath, $"Get{entityName}s.cs");
        var classText = RepoTestsTemplate(entityName);
        CreateFile(filePath, classText);
    }
}