namespace ToDoApp.Core.Interfaces.Storage
{
    using System.Collections.Generic;

    public interface IProjectStorage<T> : IDataStorage<T>
    {
        List<T> GetItemsByUserId(string userId);
    }
}
