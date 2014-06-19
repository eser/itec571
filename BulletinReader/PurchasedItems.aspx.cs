namespace BulletinReader
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class PurchasedItems : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.RefillPurchasedItems();
            }
        }

        protected void RefillPurchasedItems()
        {
            var purchasedItems = from purchasedItem in Global.Instance.DbContextMain.PurchasedItems
                                 where purchasedItem.UserId == this.LoggedUser.Id
                                 orderby purchasedItem.TransactionDate descending
                                 select purchasedItem;

            this.GridView.DataSource = purchasedItems.ToList();
            this.GridView.DataBind();

            if (purchasedItems.Count() < 1)
            {
                this.NoRecords.Visible = true;
            }
            else
            {
                this.GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}