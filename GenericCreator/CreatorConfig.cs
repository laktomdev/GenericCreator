namespace GenericCreator;

public static class CreatorConfig
{
    public static string ProjectLocation { get; } = "src/DataAccess";
    public static string TestProjectLocation { get; } = "tests/RefactoredInfrastructureTests";
    public static string ApiProjectLocation { get; } = "src/Diagprog4Api";

    public static string ServicesLocation { get; } = $"{ProjectLocation}/Services";
    public static string EntitiesLocation { get; } = $"{ProjectLocation}/Database/Models";
    public static string EntityConfigsLocation { get; } = $"{ProjectLocation}/Database/Configuration";
    public static string DtosLocation { get; } = $"{ProjectLocation}/Dtos";
    public static string ProfilesLocation { get; } = $"{ProjectLocation}/Profiles";
    public static string ControllersLocation { get; } = $"{ApiProjectLocation}/Controllers";

    public static string ReposTests { get; } = $"{TestProjectLocation}/RepositoryTests";
    public static string ServicesTests { get; } = $"{TestProjectLocation}/ServicesTests";








}