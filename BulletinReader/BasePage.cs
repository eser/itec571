namespace BulletinReader
{
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using System.Web.UI;

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
    }
}