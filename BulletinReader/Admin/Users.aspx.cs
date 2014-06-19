namespace BulletinReader.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class Users : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.RefillUsers();
            }

            if (this.GridView.Rows.Count > 0)
            {
                this.GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void RefillUsers()
        {
            var users = from user in Global.Instance.DbContextMain.Users
                        select user;

            this.GridView.DataSource = users.ToList();
            this.GridView.DataBind();

            this.NoRecords.Visible = (users.Count() < 1);
        }
    }
}