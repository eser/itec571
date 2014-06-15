namespace BulletinReader.DataClasses
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public class DbContextMain : DbContext
    {
        public DbContextMain()
            : base()
        {
        }

        public DbContextMain(DbCompiledModel model)
            : base(model)
        {
        }

        public DbContextMain(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbContextMain(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public DbContextMain(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        public DbContextMain(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        public DbContextMain(DbConnection existingConnection, DbCompiledModel model, bool dbContextOwnsObjectContext)
            : base(existingConnection, model, dbContextOwnsObjectContext)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}