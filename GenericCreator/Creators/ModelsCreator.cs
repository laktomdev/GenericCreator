using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Create(string entityName)
        {
            var entityLocationPath = Directory.CreateDirectory("Database/Models").FullName;
            CreateEntityClass(entityLocationPath, entityName);

            var dtoLocationPath = Directory.CreateDirectory("Dtos").FullName;
            CreateDtoClass(dtoLocationPath, entityName);

            var profileLocationPath = Directory.CreateDirectory("Profiles").FullName;
            CreateProfile(profileLocationPath, entityName);
        }

    }
}
