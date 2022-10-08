namespace ToDoApp.Core.Entities
{
    using System;
    
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
        public Project Project { get; set; }

        public override string ToString()
        {
            return $"{Project.Id},{Id},{Name},{Created.ToString("dd-MMMM-yyyy")},{Status}";
        }
    }
}
