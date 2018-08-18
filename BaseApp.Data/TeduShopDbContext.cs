using System.Data.Entity;
using BaseApp.Model.Models;

namespace BaseApp.Data
{
    public class BaseAppDbContext : DbContext
    {
        public BaseAppDbContext() : base("BaseAppConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ProductCategory> ProductCategories { set; get; }

        public static BaseAppDbContext Create()
        {
            return new BaseAppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}
