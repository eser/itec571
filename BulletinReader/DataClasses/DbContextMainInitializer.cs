namespace BulletinReader.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

#if DEBUG
    public class DbContextMainInitializer : DropCreateDatabaseAlways<DbContextMain>
#else
    public class DbContextMainInitializer : DropCreateDatabaseIfModelChanges<DbContextMain>
#endif
    {
        public DbContextMainInitializer()
            : base()
        {
        }

        protected override void Seed(DbContextMain dbContext)
        {
            RoleStore<IdentityRole> userRoleStore = new RoleStore<IdentityRole>(dbContext);
            RoleManager<IdentityRole> userRoleManager = new RoleManager<IdentityRole>(userRoleStore);

            IdentityRole userRoleAdmin = new IdentityRole() { Name = "admins" };
            IdentityResult userRoleAdminResult = userRoleManager.Create(userRoleAdmin);

            UserStore<User> userStore = new UserStore<User>(dbContext);
            UserManager<User> userManager = new UserManager<User>(userStore);

            User userAdmin = new User() { UserName = "admin", Email = "eser@sent.com", EmailConfirmed = true };
            IdentityResult userAdminResult = userManager.Create(userAdmin, "123456");
            userManager.AddToRole(userAdmin.Id, userRoleAdmin.Name);

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