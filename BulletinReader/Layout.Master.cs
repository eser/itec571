namespace BulletinReader
{
    using System;
    using System.Web;
    using System.Web.UI;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.FriendlyUrls;

    public partial class Layout : MasterPage
    {
        public Layout()
            : base()
        {
        }

        public string SearchBoxText { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Search searchPage = this.Page as Search;
            if (searchPage != null)
            {
                this.SearchBoxText = searchPage.Query;
            }
        }
    }
}