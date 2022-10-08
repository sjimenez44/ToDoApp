namespace ToDoApp.Core.Interfaces.Storage
{
    using System;
    using System.Collections.Generic;

    public interface ITaskStorage<T> : IDataStorage<T>
    {
        List<T> GetItemsByProjectId(string projectId);
        List<T> GetItemsByProjectIdDate(string projectId, DateTime dateTime);
    }
}
