using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenericCreator.CreatorConfig;
using static GenericCreator.Templates.Templates;

namespace GenericCreator.Creators
{
    public class ModelsCreator : FileCreator, ICreator
    {
        private void CreateEntityClass(string dirPath, string entityName)
        {
            var filePath = Path.Combine(dirPath, $"{entityName}Entity.cs");
            var classText = EntityTemplate(entityName);

            CreateFile(filePath, classText);
        }

        private void CreateDtoClass(string dirPath, string entityName)
        {
            var filePath = Path.Combine(dirPath, $"{entityName}Dto.cs");

            var classText = DtoTemplate(entityName);
            CreateFile(filePath, classText);
      
        }

        private void CreateProfile(string dirPath, string entityName)
        {
            var filePath = Path.Combine(dirPath, $"{entityName}Profile.cs");
            var classText = ProfileTemplate(entityName);
            CreateFile(filePath, classText);

        }

        private void CreateEntityConfigs(string dirPath, string entityName)
        {
            var filePath = Path.Combine(dirPath, $"{entityName}EntityConfiguration.cs");
            var classText = EntityConfigurationTemplate(entityName);
            CreateFile(filePath, classText);

        }

        public void Create(string entityName)
        {
            var entityLocationPath = Directory.CreateDirectory($"{EntitiesLocation}").FullName;
            CreateEntityClass(entityLocationPath, entityName);

            var dtoLocationPath = Directory.CreateDirectory($"{DtosLocation}").FullName;
            CreateDtoClass(dtoLocationPath, entityName);

            var profileLocationPath = Directory.CreateDirectory($"{ProfilesLocation}").FullName;
            CreateProfile(profileLocationPath, entityName);

            var configurationPath = Directory.CreateDirectory($"{EntityConfigsLocation}").FullName;
            CreateEntityConfigs(configurationPath, entityName);
        }

    }
}
