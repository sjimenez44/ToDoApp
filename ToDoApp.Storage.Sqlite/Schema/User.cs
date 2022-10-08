namespace ToDoApp.Storage.Sqlite.Schema
{
    using SQLite;

    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
