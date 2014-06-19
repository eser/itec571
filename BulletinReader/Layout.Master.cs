namespace BulletinReader
{
    using System;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

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

            if (!this.IsPostBack)
            {
                this.languagebox.Items.Add(new ListItem("English", "en-US"));
                this.languagebox.Items.Add(new ListItem("Türkçe", "tr-TR"));

                this.languagebox.SelectedValue = Thread.CurrentThread.CurrentUICulture.Name;
            }
        }
    }
}