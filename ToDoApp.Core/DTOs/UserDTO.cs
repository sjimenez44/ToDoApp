namespace ToDoApp.Core.DTOs
{
    using System.Collections.Generic;
    using ToDoApp.Core.Interfaces.DTOs;

    public class UserDTO : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ProjectDTO> Projects { get; set; }

        public override string ToString()
        {
            return $"[{Id}] :: {Name} - {Email} | No.Projects: {Projects.Count}";
        }
    }
}
