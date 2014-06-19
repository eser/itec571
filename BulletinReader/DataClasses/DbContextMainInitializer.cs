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

            IdentityRole userRoleUser = new IdentityRole() { Name = "users" };
            IdentityResult userRoleUserResult = userRoleManager.Create(userRoleUser);

            IdentityRole userRoleAdmin = new IdentityRole() { Name = "admins" };
            IdentityResult userRoleAdminResult = userRoleManager.Create(userRoleAdmin);

            UserStore<User> userStore = new UserStore<User>(dbContext);
            UserManager<User> userManager = new UserManager<User>(userStore);

            User userAdmin = new User() { UserName = "admin", Email = "eser@sent.com", Fullname = "Eser Ozvataf", EmailConfirmed = true };
            IdentityResult userAdminResult = userManager.Create(userAdmin, "123456");
            userManager.AddToRole(userAdmin.Id, userRoleAdmin.Name);
            userManager.AddToRole(userAdmin.Id, userRoleUser.Name);

            Author authorEser = new Author() { AuthorId = Guid.NewGuid(), Name = "Eser" };

            List<Author> authors = new List<Author>()
            {
                authorEser
            };

            List<Article> articles = new List<Article>()
            {
                new Article() {
                    ArticleId = Guid.NewGuid(),
                    Author = authorEser,
                    Title = "Test Article I",
                    Review = "first review for a test article",
                    Content = "",
                    CoverImagePath = null,
                    PublishDate = new DateTime(2012, 12, 12, 12, 12, 12),
                    StoreDate = DateTime.UtcNow
                },

                new Article() {
                    ArticleId = Guid.NewGuid(),
                    Author = authorEser,
                    Title = "Test Article II",
                    Review = "second review for another test article",
                    Content = "",
                    CoverImagePath = null,
                    PublishDate = new DateTime(2013, 1, 1, 15, 0, 0),
                    StoreDate = DateTime.UtcNow
                },


                new Article() {
                    ArticleId = Guid.NewGuid(),
                    Author = authorEser,
                    Title = "Test Article III",
                    Review = "second review for an another test article",
                    Content = "",
                    CoverImagePath = null,
                    PublishDate = new DateTime(2014, 4, 16, 6, 30, 0),
                    StoreDate = DateTime.UtcNow
                }
            };


            dbContext.Authors.AddRange(authors);
            dbContext.Articles.AddRange(articles);
            dbContext.SaveChanges();

            base.Seed(dbContext);
        }
    }
}