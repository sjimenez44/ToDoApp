using System.Collections.Generic;

namespace ToDoApp.Storage.Sqlite.Utils
{
    public class SchemaToEntityConverter
    {
        public static Core.Entities.User Convert(Schema.User user)
        {
            Core.Entities.User useCaseProject = new Core.Entities.User()
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            return useCaseProject;
        }

        public static Core.Entities.Project Convert(Schema.Project project)
        {
            Core.Entities.Project useCaseProject = new Core.Entities.Project()
            {
                Id = project.Id.ToString(),
                Name = project.Name,
                Color = project.Color,
                User = new Core.Entities.User()
                { 
                    Id = project.UserId.ToString()
                }
            };

            return useCaseProject;
        }

        public static Core.Entities.Task Convert(Schema.Task task)
        {
            Core.Entities.Task useCaseTask = new Core.Entities.Task()
            {
                Id = task.Id.ToString(),
                Name = task.Name,
                Created = task.Created,
                Status = task.Status,
                Project = new Core.Entities.Project()
                {
                    Id = task.ProjectId.ToString()
                }
            };

            return useCaseTask;
        }
    }
}
