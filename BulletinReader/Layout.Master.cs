namespace BulletinReader
{
    using System;
    using System.Web.UI;

    public partial class Layout : MasterPage
    {
        public Layout()
            : base()
        {
        }

        public bool SignedIn { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}