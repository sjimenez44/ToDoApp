namespace ToDoApp.Storage.Sqlite.Schema
{
    using SQLite;

    [Table("Projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int UserId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Color { get; set; }
    }
}
