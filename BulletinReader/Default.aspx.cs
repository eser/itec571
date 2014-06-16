namespace BulletinReader
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var x = from author in Global.Instance.DbContextMain.Authors
                    select author;

            this.TextBox1.Text = x.FirstOrDefault().Name;
        }
    }
}