namespace ToDoApp.Storage.Sqlite.Utils
{
    using System.Collections.Generic;
    using ToDoApp.Core.DTOs;

    public class EntityToDTOConverter
    {
        public static UserDTO Convert(Core.Entities.User user, List<ProjectDTO> projects)
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            if (!string.IsNullOrEmpty(user.Id))
            {
                userDTO.Id = int.Parse(user.Id);
            }

            userDTO.Projects = (projects == null)
                ? new List<ProjectDTO>()
                : projects;

            return userDTO;
        }

        public static ProjectDTO Convert(Core.Entities.Project project, List<TaskDTO> tasks)
        {
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Name = project.Name,
                Color = project.Color,
            };

            if (!string.IsNullOrEmpty(project.Id))
            {
                projectDTO.Id = project.Id;
            }

            projectDTO.Tasks = (tasks == null)
                ? new List<TaskDTO>()
                : tasks;

            return projectDTO;
        }

        public static TaskDTO Convert(Core.Entities.Task task)
        {
            TaskDTO taskDTO = new TaskDTO()
            {
                Name = task.Name,
                Created = task.Created,
                Status = task.Status,
            };

            if (!string.IsNullOrEmpty(task.Id))
            {
                taskDTO.Id = task.Id;
            }

            return taskDTO;
        }
    }
}
