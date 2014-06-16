namespace BulletinReader
{
    using System;
    using System.Web;
    using System.Web.UI;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.Identity;

    public partial class Layout : MasterPage
    {
        public Layout()
            : base()
        {
        }

        public User LoggedUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoggedUser = Global.Instance.UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());
        }
    }
}