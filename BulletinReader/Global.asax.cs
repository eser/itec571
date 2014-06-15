namespace BulletinReader
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Web;
    using BulletinReader.DataClasses;

    public class Global : HttpApplication
    {
        public static Global Instance { get; private set; }

        public DbContextMain DbContext { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.Instance = this;

            DbContextMainInitializer initializer = new DbContextMainInitializer();
            Database.SetInitializer<DbContextMain>(initializer);

            this.DbContext = new DbContextMain(ConfigurationManager.ConnectionStrings["DbMainConnectionString"].ConnectionString);
            this.DbContext.Database.Initialize(false);
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