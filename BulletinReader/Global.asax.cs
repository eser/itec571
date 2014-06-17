namespace BulletinReader
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Global : HttpApplication
    {
        public static Global Instance { get; private set; }

        public DbContextMain DbContextMain { get; private set; }
        public UserStore<User> UserStore { get; private set; }
        public UserManager<User> UserManager { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.Instance = this;

            DbContextMainInitializer mainInitializer = new DbContextMainInitializer();
            Database.SetInitializer<DbContextMain>(mainInitializer);

            this.DbContextMain = new DbContextMain(ConfigurationManager.ConnectionStrings["DbMainConnectionString"].ConnectionString);
            this.DbContextMain.Database.Initialize(false);

            this.UserStore = new UserStore<User>(this.DbContextMain);
            this.UserManager = new UserManager<User>(this.UserStore);

            GlobalConfiguration.Configure(
                config =>
                {
                    config.MapHttpAttributeRoutes();
                    config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );
                }
            );
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}