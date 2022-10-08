using System.Security.Principal;

namespace ToDoApp.Storage.Sqlite.Utils
{
    public class EntityToSchemaConverter
    {
        public static Schema.User Convert(Core.Entities.User user)
        {
            Schema.User inkEntity = new Schema.User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            if (!string.IsNullOrEmpty(user.Id))
            {
                inkEntity.Id = int.Parse(user.Id);
            }

            return inkEntity;
        }

        public static Schema.Project Convert(Core.Entities.Project project)
        {
            Schema.Project projectEntity = new Schema.Project()
            {
                Name = project.Name,
                Color = project.Color,
            };

            if (!string.IsNullOrEmpty(project.User.Id))
            {
                projectEntity.UserId = int.Parse(project.User.Id);
            }

            if (!string.IsNullOrEmpty(project.Id))
            {
                projectEntity.Id = int.Parse(project.Id);
            }

            return projectEntity;
        }

        public static Schema.Task Convert(Core.Entities.Task task)
        {
            Schema.Task taskEntity = new Schema.Task()
            {
                Name = task.Name,
                Created = task.Created,
                Status = task.Status,
            };

            if (!string.IsNullOrEmpty(task.Project.Id))
            {
                taskEntity.ProjectId = int.Parse(task.Project.Id);
            }

            if (!string.IsNullOrEmpty(task.Id))
            {
                taskEntity.Id = int.Parse(task.Id);
            }

            return taskEntity;
        }
    }
}
