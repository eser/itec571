namespace BulletinReader
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Routing;
    using BulletinReader.DataClasses;

    public class Global : HttpApplication
    {
        public static Global Instance { get; private set; }

        public DbContextMain DbContextMain { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.Instance = this;

            DbContextMainInitializer mainInitializer = new DbContextMainInitializer();
            Database.SetInitializer<DbContextMain>(mainInitializer);

            this.DbContextMain = new DbContextMain(ConfigurationManager.ConnectionStrings["DbMainConnectionString"].ConnectionString);
            this.DbContextMain.Database.Initialize(false);

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
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