namespace ToDoApp.Core.Interfaces.DTOs
{
    using System;
    
    public interface ITask
    {
        string Id { get; set; }
        string Name { get; set; }
        DateTime Created { get; set; }
        int Status { get; set; }
    }
}
