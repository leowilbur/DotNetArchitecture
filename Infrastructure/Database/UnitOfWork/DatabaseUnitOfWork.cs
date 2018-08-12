namespace Solution.Infrastructure.Database
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public DatabaseUnitOfWork(
            IUserLogRepository userLogRepository,
            IUserRepository userRepository,
            DatabaseContext databaseContext)
        {
            UserLogRepository = userLogRepository;
            UserRepository = userRepository;
            Context = databaseContext;
        }

        public IUserLogRepository UserLogRepository { get; }

        public IUserRepository UserRepository { get; }

        private DatabaseContext Context { get; set; }

        public void DiscardChanges()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
