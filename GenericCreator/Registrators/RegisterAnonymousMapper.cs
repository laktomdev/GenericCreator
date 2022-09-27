using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static GenericCreator.CreatorConfig;

namespace GenericCreator.Registrators;
public class RegisterAnonymousMapper : LineFinder
{
    public void Register()
    {


        var path = $"{Directory.GetCurrentDirectory()}\\{ProjectLocation}\\bin\\Debug\\net6.0\\DataAccess.dll";

        path = Path.Combine(Directory.GetCurrentDirectory(), ProjectLocation, "bin\\Debug\\net6.0\\DataAccess.dll");
        //var path = "E:\\Repos\\Diagprog4Tools\\Diagprog4Infrastructure\\src\\DataAccess\\bin\\Debug\\net6.0\\DataAccess.dll";

        var dtos = GetLoadableTypes(Assembly.LoadFile(path)).Where(x => x.FullName.Contains($"Dto"));


        foreach (var d in dtos)
        {
            RegisterInProfile(d);
        }
    }

    public void Register(string entityName)
    {


        var path = $"{Directory.GetCurrentDirectory()}\\{ProjectLocation}\\bin\\Debug\\net6.0\\DataAccess.dll";
        path = Path.Combine(Directory.GetCurrentDirectory(), ProjectLocation, "bin\\Debug\\net6.0\\DataAccess.dll");


        var dto = GetLoadableTypes(Assembly.LoadFile(path)).SingleOrDefault(x => x.FullName.Contains($"{entityName}Dto"));

        if (dto == null)
        {
            Console.WriteLine($"Could not find {entityName}Dto in assembly");
        }
        RegisterInProfile(dto);

    }


    public void RegisterInProfile(Type dto)
    {
        var properties = dto.GetProperties();
        var mapperStrings = ForPathCollection(properties);

        var profileName = dto.Name.Replace("Dto", "Profile");

        var filePath = $"{ProfilesLocation}/{profileName}.cs";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Could not file: {filePath}");
            return;
        }
        string text = JoinForPathCollection(mapperStrings, dto.Name);
        UpdateFile(filePath, text);
    }

    public string JoinForPathCollection(IEnumerable<string> mapperStrings, string dtoName)
    {
        var baseStr = $"\nCreateMap<object, {dtoName}>()";
        foreach (var str in mapperStrings)
        {
            baseStr += $"\n{str}";
        }

        baseStr += ";";

        return baseStr;

    }


    public void UpdateFile(string path, string text)
    {
      
        var line = FindLineAfterSemicolon(path);
        AddLineToFile(line, text, path);

        Console.WriteLine($"File updated: {Path.GetFileName(path)}");
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        if (assembly == null) throw new ArgumentNullException(nameof(assembly));
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            return e.Types.Where(t => t != null);
        }
    }


    private static IEnumerable<string> ForPathCollection(PropertyInfo[] properties)
    {
        foreach (var p in properties)
        {
            yield return
                $".ForPath(dto => dto.{p.Name}, m => m.MapFrom(obj => obj.GetType().GetProperty(\"{p.Name}\")!.GetValue(obj)))";
        }

    }
}