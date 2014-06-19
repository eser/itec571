namespace BulletinReader
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.Identity;

    public class BasePage : Page
    {
        public BasePage()
            : base()
        {
            this.LoggedUser = Global.Instance.UserManager.FindById(this.User.Identity.GetUserId());
        }

        public User LoggedUser { get; set; }

        protected override void InitializeCulture()
        {
            HttpCookie cookie = this.Request.Cookies["CurrentLanguage"];
            CultureInfo culture = null;

            if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
            {
                try
                {
                    culture = CultureInfo.CreateSpecificCulture(cookie.Value);
                }
                catch (CultureNotFoundException)
                {
                    // culture = null;
                }
            }

            if (culture == null)
            {
                culture = CultureInfo.CreateSpecificCulture("en-US");
            }

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            base.InitializeCulture();
        }

        protected PurchasedItem GetPurchasedItem(Guid articleId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            if (this.Session["purchasedItems"] == null)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();

                var purchasedItems = (from purchasedItem in Global.Instance.DbContextMain.PurchasedItems
                                      where purchasedItem.UserId == userId
                                      select purchasedItem);

                this.Session["purchasedItems"] = purchasedItems.ToArray();
            }

            return (this.Session["purchasedItems"] as PurchasedItem[]).Where(rec => rec.ArticleId == articleId).FirstOrDefault();
        }
    }
}