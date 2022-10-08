using ToDoApp.Core.Entities;
using ToDoApp.Core.Interfaces.Collector;
using ToDoApp.Core.Interfaces.Storage;

namespace ToDoApp.Core.Services
{
    public class ToDoCollectorInteractor : ICollectorInteractor
    {
        private IUserStorage<User> _userStorage;
        private IProjectStorage<Project> _projectStorage;
        private ITaskStorage<Task> _taskStorage;

        public ToDoCollectorInteractor(
            IUserStorage<User> userStorage, 
            IProjectStorage<Project> projectStorage, 
            ITaskStorage<Task> taskStorage)
        {
            _userStorage = userStorage;
            _projectStorage = projectStorage;
            _taskStorage = taskStorage;
        }
    }
}
