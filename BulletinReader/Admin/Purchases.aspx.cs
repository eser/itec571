namespace BulletinReader.Admin
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.UI.WebControls;
    using BulletinReader.DataClasses;

    public partial class Purchases : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.FilterStatus.Items.Add(new ListItem("All Records", "all"));
                this.FilterStatus.Items.Add(new ListItem("Not Confirmed", "notconfirmed"));
                this.FilterStatus.Items.Add(new ListItem("Confirmed", "confirmed"));

                this.RefillPurchasedItems();
            }

            if (this.GridView.Rows.Count > 0)
            {
                this.GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void RefillPurchasedItems()
        {
            Expression<Func<PurchasedItem, bool>> predicate = rec => (this.FilterStatus.SelectedValue == "all" || (this.FilterStatus.SelectedValue == "notconfirmed" && rec.Status == PurchasedItemStatus.NotConfirmed) || (this.FilterStatus.SelectedValue == "confirmed" && rec.Status == PurchasedItemStatus.Confirmed));

            var purchasedItems = from purchasedItem in Global.Instance.DbContextMain.PurchasedItems.Where(predicate)
                                 orderby purchasedItem.TransactionDate descending
                                 select purchasedItem;

            this.GridView.DataSource = purchasedItems.ToList();
            this.GridView.DataBind();

            this.NoRecords.Visible = (purchasedItems.Count() < 1);
        }

        protected void btnChangeConfirmationStatus_Click(object sender, EventArgs e)
        {
            Button buttonObject = sender as Button;

            Guid purchasedItemId = new Guid(buttonObject.CommandArgument);

            var purchasedItems = (from purchasedItem in Global.Instance.DbContextMain.PurchasedItems
                                  where purchasedItem.PurchasedItemId == purchasedItemId
                                  select purchasedItem);

            PurchasedItem item = purchasedItems.SingleOrDefault();
            item.Status = (item.Status == PurchasedItemStatus.NotConfirmed) ? PurchasedItemStatus.Confirmed : PurchasedItemStatus.NotConfirmed;
            Global.Instance.DbContextMain.SaveChanges();

            this.RefillPurchasedItems();
        }

        protected void FilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefillPurchasedItems();
        }
    }
}