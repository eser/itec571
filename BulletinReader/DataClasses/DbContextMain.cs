namespace BulletinReader.DataClasses
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DbContextMain : IdentityDbContext<User>
    {
        public DbContextMain()
            : base()
        {
        }

        public DbContextMain(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbContextMain(string nameOrConnectionString, bool throwIfV1Schema)
            : base(nameOrConnectionString, throwIfV1Schema)
        {
        }

        public DbContextMain(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PurchasedItem> PurchasedItems { get; set; }
    }
}