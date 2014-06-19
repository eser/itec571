namespace BulletinReader
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BulletinReader.DataClasses;
    using Microsoft.AspNet.Identity;

    public class BasePage : Page
    {
        public BasePage()
            : base()
        {
        }

        public User LoggedUser { get; set; }

        protected override async void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if (this.User.Identity.IsAuthenticated)
            {
                this.LoggedUser = await Global.Instance.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Literal notificationArea = this.FindControlRecursive<Literal>("NotificationArea");
            if (notificationArea != null && this.Session["Notification"] != null)
            {
                notificationArea.Text = this.GetNotification();

                this.Session.Remove("Notification");
            }
            else
            {
                notificationArea.Text = string.Empty;
            }
        }

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
            if (!this.User.Identity.IsAuthenticated)
            {
                return null;
            }

            if (this.Session["purchasedItems"] == null)
            {
                var userId = this.User.Identity.GetUserId();

                var purchasedItems = (from purchasedItem in Global.Instance.DbContextMain.PurchasedItems
                                      where purchasedItem.UserId == userId
                                      select purchasedItem);

                this.Session["purchasedItems"] = purchasedItems.ToArray();
            }

            return (this.Session["purchasedItems"] as PurchasedItem[]).Where(rec => rec.ArticleId == articleId).FirstOrDefault();
        }

        protected string ConstructAlertMessage(string type, string title, string message)
        {
            return "<div class=\"alert alert-" + type + " alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button> <strong>" + title + "</strong> " + message.Replace(Environment.NewLine, "<br />") + "</div>";
        }

        protected void AddNotification(string type, string title, string message)
        {
            string[][] oldValue = this.Session["Notification"] as string[][];
            if (oldValue == null)
            {
                oldValue = new string[0][];
            }

            int length = oldValue.Length;
            Array.Resize(ref oldValue, length + 1);
            oldValue[length] = new string[] { type, title, message };

            this.Session["Notification"] = oldValue;
        }

        protected void AddFormNotification(string type, string title, string message)
        {
            Literal notificationArea = this.FindControlRecursive<Literal>("NotificationArea");
            if (notificationArea != null)
            {
                notificationArea.Text += this.ConstructAlertMessage(type, title, message);
            }
        }

        public string GetNotification()
        {
            string[][] oldValue = this.Session["Notification"] as string[][];

            StringBuilder text = new StringBuilder();
            if (oldValue != null)
            {
                foreach (string[] notificationValues in oldValue)
                {
                    text.AppendLine(this.ConstructAlertMessage(notificationValues[0], notificationValues[1], notificationValues[2]));
                }
            }

            return text.ToString();
        }

        protected T FindControlRecursive<T>(string id, Control root = null) where T : Control
        {
            if (root == null)
            {
                root = this;
            }

            if (root.ID == id)
            {
                return root as T;
            }

            foreach (Control ctrl in root.Controls)
            {
                Control foundControl = this.FindControlRecursive<T>(id, ctrl);
                if (foundControl != null)
                {
                    return foundControl as T;
                }
            }

            return null;
        }
    }
}