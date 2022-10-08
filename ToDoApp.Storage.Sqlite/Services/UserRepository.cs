namespace ToDoApp.Storage.Sqlite.Services
{
    using SQLite;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoApp.Core.Entities;
    using ToDoApp.Core.Interfaces.Storage;
    using ToDoApp.Storage.Sqlite.Utils;

    public class UserRepository : IUserStorage<User>
    {
        string _databaseLocation;

        public UserRepository(string databaseLocation)
        {
            _databaseLocation = databaseLocation;
        }

        public User GetItemAsync(string id)
        {
            User useCaseUser = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.User>();
                Schema.User userData = conn.Table<Schema.User>().ToList().Find(user => user.Id == int.Parse(id));

                if (userData != null)
                {
                    useCaseUser = SchemaToEntityConverter.Convert(userData);
                }
            }

            return useCaseUser;
        }

        public User GetItemByEmailAsync(string email, string password)
        {
            User useCaseUser = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.User>();
                Schema.User userData = conn.Table<Schema.User>()
                    .ToList()
                    .Find(user => user.Email == email && user.Password == password);

                if (userData != null)
                {
                    useCaseUser = SchemaToEntityConverter.Convert(userData);
                }
            }

            return useCaseUser;
        }

        public List<User> GetItemsAsync(bool forceRefresh = false)
        {
            List<User> useCaseUsers = null;

            using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
            {
                conn.CreateTable<Schema.User>();
                List<Schema.User> users = conn.Table<Schema.User>().ToList();
                useCaseUsers = users.Select(t => SchemaToEntityConverter.Convert(t)).ToList();
            }

            return useCaseUsers;
        }

        public bool AddItemAsync(User item)
        {
            try
            {
                bool isSuccessful;
                Schema.User user = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.User>();
                    int rows = conn.Insert(user);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateItemAsync(User item)
        {
            try
            {
                bool isSuccessful;
                Schema.User user = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.User>();
                    int rows = conn.Update(user);
                    isSuccessful = rows > 0;
                }

                return isSuccessful;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DeleteItemAsync(User item)
        {
            try
            {
                bool isSuccessful;
                Schema.User user = EntityToSchemaConverter.Convert(item);

                using (SQLiteConnection conn = new SQLiteConnection(_databaseLocation))
                {
                    conn.CreateTable<Schema.User>();
                    int rows = conn.Delete(user);
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
