namespace ToDoApp.Core.Interfaces.Storage
{
    using System.Collections.Generic;

    public interface IDataStorage<T>
    {
        bool AddItemAsync(T item);
        bool UpdateItemAsync(T item);
        bool DeleteItemAsync(T item);
        T GetItemAsync(string id);
        List<T> GetItemsAsync(bool forceRefresh = false);
    }
}
