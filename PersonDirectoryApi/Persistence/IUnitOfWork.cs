namespace PersonDirectoryApi.Persistence
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
