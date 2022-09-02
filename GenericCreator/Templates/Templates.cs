namespace GenericCreator.Templates;

public static class Templates
{

    public static string EntityTemplate(string entityName)
    {
        return $@"using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
namespace DataAccess.Database.Models;


public class {entityName}Entity : Entity
{{
     //TODO: NewEntity: add properties
}}";
    }

    public static string DtoTemplate(string entityName)
    {
        return $@"using Newtonsoft.Json;

namespace DataAccess.Dtos;

public class {entityName}Dto : Dto
{{
  //TODO: NewEntity: add properties
}}";
    }

    public static string ProfileTemplate(string entityName)
    {
        return $@"using AutoMapper;
using DataAccess.Database.Models;
using DataAccess.Dtos;

namespace DataAccess.Profiles;

public class {entityName}Profile : Profile
{{
    public {entityName}Profile()
    {{
        CreateMap<{entityName}Entity, {entityName}Dto>();

       //TODO: NewEntity: add mapping
    }}
    }}";
    }


    public static string IServiceTemplate(string entityName)
    {
        return $@"using DataAccess.Commons.Services;
        using DataAccess.Database.Models;
        using DataAccess.Dtos;

        namespace DataAccess.Services.{entityName};

    public interface I{entityName}Service : IGenericService<{entityName}Entity, {entityName}Dto>
    {{

    }}";
    }

    public static string ServiceTemplate(string entityName)
    {
        return $@"using AutoMapper;
using DataAccess.Commons.Repository;
using DataAccess.Commons.Services;
using DataAccess.Database.Models;
using DataAccess.Dtos;
using Microsoft.Extensions.Logging;

namespace DataAccess.Services.{entityName};


public class {entityName}Service : GenericService<{entityName}Entity, {entityName}Dto>, I{entityName}Service
{{
    public {entityName}Service(IGenericRepository<{entityName}Entity?> repository, IMapper mapper, ILogger<{entityName}Service> logger) : base(repository, mapper, logger)
    {{
    }}



}}";
    }


    public static string IRepositoryTemplate(string entityName)
    {

        return @$"using DataAccess.Commons.Repository;
        using DataAccess.Database.Models;

        namespace DataAccess.Services.{entityName};

    public interface I{entityName}Repository : IGenericRepository<{entityName}Entity>
    {{

    }}";
    }


    public static string RepositoryTemplate(string entityName)
    {
        return $@"using DataAccess.Commons.Repository;
        using DataAccess.Database;
        using DataAccess.Database.Models;

        namespace DataAccess.Services.{entityName};

    public class {entityName}Repository : GenericRepository<{entityName}Entity>, I{entityName}Repository
    {{
        public {entityName}Repository(DiagprogFbContext context) : base(context)
        {{
        }}
    }}";
    }

    public static string ControllerTemplate(string entityName)
    {
        return $@"using DataAccess.Commons.Controllers;
using DataAccess.Commons.Services;
using DataAccess.Database.Models;
using DataAccess.Dtos;
using DataAccess.Services.{entityName};
using Microsoft.Extensions.Caching.Memory;

namespace Diagprog4Api.Controllers;

public class {entityName}sController : GenericController<{entityName}Entity, {entityName}Dto>
{{
    public {entityName}sController(I{entityName}Service service, IMemoryCache memoryCache) : base(service, memoryCache)
    {{
    }}




    }}";
    }


}