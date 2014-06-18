namespace BulletinReader
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using Microsoft.AspNet.Identity;

    public class BasePage : Page
    {
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

        protected bool IsAPurchasedItem(Guid articleId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return false;
            }

            if (this.Session["purchasedItems"] == null)
            {
                var purchasedItems = (from purchasedItem in Global.Instance.DbContextMain.PurchasedItems
                                      where purchasedItem.UserId == HttpContext.Current.User.Identity.GetUserId()
                                      select purchasedItem.ArticleId);

                this.Session["purchasedItems"] = purchasedItems.ToList();
            }

            return (this.Session["purchasedItems"] as List<Guid>).Contains(articleId);
        }
    }
}