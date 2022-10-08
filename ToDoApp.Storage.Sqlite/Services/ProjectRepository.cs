namespace ToDoApp.Storage.Sqlite.Services
{
    using SQLite;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoApp.Core.Entities;
    using ToDoApp.Core.Interfaces.Storage;
    using ToDoApp.Storage.Sqlite.Utils;

    public class ProjectRepository : IProjectStorage<Project>
    {
        string _databaseLocation;

        public ProjectRepository(string databaseLocation)
        {
            _databaseLocation = databaseLocation;
        }

        public Project GetItemAsync(string id)
        {
            Project useCaseProject = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Project>();
                Schema.Project projectData = conn.Table<Schema.Project>().ToList()
                    .Find(project => project.Id == int.Parse(id));

                if (projectData != null)
                {
                    useCaseProject = SchemaToEntityConverter.Convert(projectData);
                }
            }

            return useCaseProject;
        }

        public List<Project> GetItemsAsync(bool forceRefresh = false)
        {
            List<Project> useCaseProjects = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Project>();
                List<Schema.Project> projects = conn.Table<Schema.Project>().ToList();
                useCaseProjects = projects.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseProjects;
        }

        public List<Project> GetItemsByUserId(string userId)
        {
            List<Project> useCaseProjects = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Project>();
                List<Schema.Project> projects = conn.Table<Schema.Project>().ToList()
                    .FindAll(project => project.UserId == int.Parse(userId));
                useCaseProjects = projects.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseProjects;
        }

        public bool AddItemAsync(Project item)
        {
            try
            {
                bool isSuccessful;
                Schema.Project project = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Project>();
                    int rows = conn.Insert(project);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateItemAsync(Project item)
        {
            try
            {
                bool isSuccessful;
                Schema.Project project = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Project>();
                    int rows = conn.Update(project);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DeleteItemAsync(Project item)
        {
            try
            {
                bool isSuccessful;
                Schema.Project project = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Project>();
                    int rows = conn.Delete(project);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
