namespace ToDoApp.Storage.Sqlite.Schema
{
    using System;
    using SQLite;

    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ProjectId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public DateTime Created { get; set; }
        [NotNull]
        public int Status { get; set; }
    }
}
