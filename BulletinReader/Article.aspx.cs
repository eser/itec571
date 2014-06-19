namespace BulletinReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.FriendlyUrls;
    using Microsoft.AspNet.Identity;
    using ArticleDataClass = BulletinReader.DataClasses.Article;

    public partial class Article : BasePage
    {
        public ArticleDataClass ArticleEntity
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> segments = new List<string>(this.Request.GetFriendlyUrlSegments());
            if (segments.Count < 1 || string.IsNullOrWhiteSpace(segments[0]))
            {
                throw new InvalidOperationException();
            }

            string articleName = HttpUtility.UrlDecode(segments[0]);
            var articles = (from article in Global.Instance.DbContextMain.Articles
                           where article.Title == articleName
                           select article);

            this.ArticleEntity = articles.SingleOrDefault();

            PurchasedItem purchasedItem = this.GetPurchasedItem(this.ArticleEntity.ArticleId);

            if (purchasedItem == null)
            {
                this.btnPurchaseButton.Visible = true;
                this.ltrPaymentNotice.Visible = false;
                this.ltrContent.Visible = false;

                if (this.LoggedUser == null)
                {
                    this.btnPurchaseButton.Disabled = true;
                }
            }
            else if (purchasedItem.Status == PurchasedItemStatus.NotConfirmed)
            {
                this.btnPurchaseButton.Visible = false;
                this.ltrPaymentNotice.Visible = true;
                this.ltrContent.Visible = false;
            }
            else
            {
                this.btnPurchaseButton.Visible = false;
                this.ltrPaymentNotice.Visible = false;
                this.ltrContent.Visible = true;
            }
        }

        protected void btnPurchaseButton_ServerClick(object sender, EventArgs e)
        {
            PurchasedItem purchasedItem = new PurchasedItem()
            {
                PurchasedItemId = Guid.NewGuid(),
                ArticleId = this.ArticleEntity.ArticleId,
                Status = PurchasedItemStatus.NotConfirmed,
                TransactionDate = DateTime.UtcNow,
                UserId = HttpContext.Current.User.Identity.GetUserId()
            };

            Global.Instance.DbContextMain.PurchasedItems.Add(purchasedItem);
            Global.Instance.DbContextMain.SaveChanges();

            this.Session["purchasedItems"] = null;

            this.btnPurchaseButton.Visible = false;
            this.ltrPaymentNotice.Visible = true;
            this.ltrContent.Visible = false;
        }

        protected void btnCancelButton_ServerClick(object sender, EventArgs e)
        {
            PurchasedItem purchasedItem = this.GetPurchasedItem(this.ArticleEntity.ArticleId);

            if (purchasedItem == null)
            {
                throw new InvalidOperationException();
            }

            Global.Instance.DbContextMain.PurchasedItems.Remove(purchasedItem);
            Global.Instance.DbContextMain.SaveChanges();

            this.Session["purchasedItems"] = null;

            this.btnPurchaseButton.Visible = true;
            this.ltrPaymentNotice.Visible = false;
            this.ltrContent.Visible = false;
        }
    }
}