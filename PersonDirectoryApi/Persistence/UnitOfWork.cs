namespace PersonDirectoryApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonsDbContext context;

        public UnitOfWork(PersonsDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
