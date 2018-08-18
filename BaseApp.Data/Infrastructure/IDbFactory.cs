using System;

namespace BaseApp.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BaseAppDbContext Init();
    }
}