namespace ToDoApp.Storage.Sqlite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToDoApp.Core.DTOs;
    using ToDoApp.Core.Entities;
    using ToDoApp.Core.Interfaces.Storage;

    public class SqlRepository
    {
        private IUserStorage<User>          _userStorage;
        private IProjectStorage<Project>    _projectStorage;
        private ITaskStorage<Task>          _taskStorage;

        public SqlRepository(
            IUserStorage<User> userStorage, 
            IProjectStorage<Project> projectStorage, 
            ITaskStorage<Task> taskStorage)
        {
            _userStorage = userStorage;
            _projectStorage = projectStorage;
            _taskStorage = taskStorage;
        }

        #region Users
        public UserDTO GetUserByEmail(string email, string password)
        {
            User user = _userStorage.GetItemByEmailAsync(email, password);
            return new UserDTO()
            {
                Id = int.Parse(user.Id),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Projects = new List<ProjectDTO>(),
            };
        }

        public bool CreateUser(User user)
        {
            return _userStorage.AddItemAsync(user);
        }

        public bool UpdateUser(User user)
        {
            return _userStorage.UpdateItemAsync(user);
        }

        public bool DeleteUser(User user)
        {
            return _userStorage.DeleteItemAsync(user);
        }
        #endregion

        #region Projects
        public List<ProjectDTO> GetProjectsByUserId(string userId)
        {
            List<Project> projects = _projectStorage.GetItemsByUserId(userId).ToList();
            List<ProjectDTO> projectsDTO = new List<ProjectDTO>();
            foreach (Project project in projects)
            {
                List<TaskDTO> tasks = GetTasksByProjectId(project.Id).ToList()
                    .Select(task => new TaskDTO()
                    { 
                        Id = task.Id, 
                        Name = task.Name, 
                        Created = task.Created, 
                        Status = task.Status}
                    ).ToList();
                projectsDTO.Add(new ProjectDTO()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Color = project.Color,
                    Tasks = tasks
                });
            }

            return projectsDTO;
        }

        public ProjectDTO GetProject(Project project)
        {
            Project projectInfo = _projectStorage.GetItemAsync(project.Id);
            return new ProjectDTO()
            {
                Id = projectInfo.Id,
                Name = projectInfo.Name,
                Color = projectInfo.Color,
                Tasks = GetTasksByProjectId(project.Id).ToList()
            };
        }

        public bool CreateProject(Project project)
        {
            return _projectStorage.AddItemAsync(project);
        }

        public bool UpdateProject(Project project)
        {
            return _projectStorage.UpdateItemAsync(project);
        }

        public bool DeleteProject(Project project)
        {
            List<TaskDTO> tasks = GetTasksByProjectId(project.Id).ToList();
            foreach (TaskDTO task in tasks)
            {
                bool result = DeleteTask(new Task()
                { 
                    Id = task.Id,
                    Name = task.Name,
                    Created = task.Created,
                    Status = task.Status,
                    Project = new Project() { Id = project.Id },
                });

                if (!result)
                {
                    return result;
                }
            }

            return _projectStorage.DeleteItemAsync(project);
        }
        #endregion

        #region Tasks

        public List<Task> GetTasksByUserIdDate(string userId, DateTime dateTime)
        {
            List<Project> projectsUser = _projectStorage.GetItemsByUserId(userId);
            List<Task> tasks = new List<Task>();
            foreach (Project project in projectsUser)
            {
                List<Task> tasksUser = _taskStorage.GetItemsByProjectIdDate(project.Id, dateTime);
                tasksUser.ForEach(task => task.Project = new Project() 
                { 
                    Id = project.Id,
                    Name = project.Name,
                    Color = project.Color,
                    User = project.User,
                });
                tasks.AddRange(tasksUser);
            }

            return tasks;
        }

        public List<TaskDTO> GetTasksByProjectId(string projectId)
        {
            List<Task> tasks = _taskStorage.GetItemsByProjectId(projectId);
            return tasks.Select(t => new TaskDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Created = t.Created,
                Status = t.Status,
            }).ToList();
        }

        private List<TaskDTO> GetTasksByProjectIdDate(string projectId, DateTime dateTime)
        {
            List<Task> tasks = _taskStorage.GetItemsByProjectIdDate(projectId, dateTime);
            return tasks.Select(t => new TaskDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Created = t.Created,
                Status = t.Status,
            }).ToList();
        }

        public TaskDTO GetTask(Task task)
        {
            Task taskInfo = _taskStorage.GetItemAsync(task.Id);
            return new TaskDTO()
            {
                Id = taskInfo.Id,
                Name = taskInfo.Name,
                Created = taskInfo.Created,
                Status = taskInfo.Status,
            };
        }

        public bool CreateTask(Task task)
        {
            return _taskStorage.AddItemAsync(task);
        }

        public bool UpdateTask(Task task)
        {
            return _taskStorage.UpdateItemAsync(task);
        }

        public bool DeleteTask(Task task)
        {
            return _taskStorage.DeleteItemAsync(task);
        }
        #endregion
    }
}
