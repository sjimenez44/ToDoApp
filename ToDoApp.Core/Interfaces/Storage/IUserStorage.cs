namespace ToDoApp.Core.Interfaces.Storage
{
    public interface IUserStorage<T> : IDataStorage<T>
    {
        T GetItemByEmailAsync(string email, string password);
    }
}
