namespace BulletinReader.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class DbContextMainInitializer : DropCreateDatabaseAlways<DbContextMain> // DropCreateDatabaseIfModelChanges<DbContextMain>
    {
        public DbContextMainInitializer()
            : base()
        {
        }

        protected override void Seed(DbContextMain dbContext)
        {
            Author authorEser = new Author() { AuthorId = Guid.NewGuid(), Name = "Eser" };

            List<Author> authors = new List<Author>()
            {
                authorEser
            };

            List<Article> articles = new List<Article>()
            {
                new Article() { ArticleId = Guid.NewGuid(), Author = authorEser, Title = "Test Article I" },
                new Article() { ArticleId = Guid.NewGuid(), Author = authorEser, Title = "Test Article II" }
            };


            dbContext.Authors.AddRange(authors);
            dbContext.Articles.AddRange(articles);
            dbContext.SaveChanges();

            base.Seed(dbContext);
        }
    }
}