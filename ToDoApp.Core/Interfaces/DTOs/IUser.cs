namespace ToDoApp.Core.Interfaces.DTOs
{
    using System.Collections.Generic;
    using ToDoApp.Core.DTOs;

    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        List<ProjectDTO> Projects { get; set; }
    }
}
