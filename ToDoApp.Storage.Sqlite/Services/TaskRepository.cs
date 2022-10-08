namespace ToDoApp.Storage.Sqlite.Services
{
    using SQLite;
    using System.Linq;
    using System.Collections.Generic;
    using ToDoApp.Core.Entities;
    using ToDoApp.Core.Interfaces.Storage;
    using ToDoApp.Storage.Sqlite.Utils;
    using System;

    public class TaskRepository : ITaskStorage<Task>
    {
        string _databaseLocation;

        public TaskRepository(string databaseLocation)
        {
            _databaseLocation = databaseLocation;
        }

        public Task GetItemAsync(string id)
        {
            Task useCaseTask = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Task>();
                Schema.Task taskData = conn.Table<Schema.Task>().ToList().Find(task => task.Id == int.Parse(id));

                if (taskData != null)
                {
                    useCaseTask = SchemaToEntityConverter.Convert(taskData);
                }
            }

            return useCaseTask;
        }

        public List<Task> GetItemsAsync(bool forceRefresh = false)
        {
            List<Task> useCaseTasks = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Task>();
                List<Schema.Task> tasks = conn.Table<Schema.Task>().ToList();
                useCaseTasks = tasks.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseTasks;
        }

        public List<Task> GetItemsByProjectId(string projectId)
        {
            List<Task> useCaseTasks = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Task>();
                List<Schema.Task> tasks = conn.Table<Schema.Task>().ToList()
                    .FindAll(task => task.ProjectId == int.Parse(projectId));
                useCaseTasks = tasks.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseTasks;
        }

        public List<Task> GetItemsByProjectIdDate(string projectId, DateTime dateTime)
        {
            List<Task> useCaseTasks = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.Task>();
                List<Schema.Task> tasks = conn.Table<Schema.Task>().ToList()
                    .FindAll(task => task.ProjectId == int.Parse(projectId) && task.Created.ToString("dd-MMMM-yyyy") == dateTime.ToString("dd-MMMM-yyyy"));
                useCaseTasks = tasks.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseTasks;
        }

        public bool AddItemAsync(Task item)
        {
            try
            {
                bool isSuccessful;
                Schema.Task task = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Task>();
                    int rows = conn.Insert(task);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateItemAsync(Task item)
        {
            try
            {
                bool isSuccessful;
                Schema.Task task = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Task>();
                    int rows = conn.Update(task);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DeleteItemAsync(Task item)
        {
            try
            {
                bool isSuccessful;
                Schema.Task task = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.Task>();
                    int rows = conn.Delete(task);
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
