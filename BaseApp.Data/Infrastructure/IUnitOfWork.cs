namespace BaseApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}