namespace ToDoApp.Core.Entities
{
    using System.Collections.Generic;
    
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"{User.Id},{Id},{Name},{Color}";
        }
    }
}
