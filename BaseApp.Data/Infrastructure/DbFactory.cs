namespace BaseApp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BaseAppDbContext dbContext;

        public BaseAppDbContext Init()
        {
            return dbContext ?? (dbContext = new BaseAppDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}