namespace BulletinReader
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.FriendlyUrls;

    public partial class Default : BasePage
    {
        public const int PageSize = 25;

        public int CurrentPage
        {
            get
            {
                if (this.Request.QueryString["page"] == null)
                {
                    return 1;
                }

                return int.Parse(this.Request.QueryString["page"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.FetchData();
            }
        }

        private void FetchData()
        {
            var articles = (from article in Global.Instance.DbContextMain.Articles
                            orderby article.StoreDate descending, article.PublishDate descending
                            select article);

            int skip = (this.CurrentPage - 1) * Default.PageSize;
            int rowCount = 0;
            if (skip >= 0)
            {
                this.ArticleRepeater.DataSource = articles.Skip(skip).Take(Default.PageSize).ToList();
                this.ArticleRepeater.DataBind();

                rowCount = articles.Count();
            }

            this.ArticlePaging.Text = "";

            if (this.CurrentPage > 1)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?page={1}\">&laquo;</a></li>", FriendlyUrl.Href("~/"), this.CurrentPage - 1);
            }
            else
            {
                this.ArticlePaging.Text += "<li class=\"disabled\"><span>&laquo;</span></li>";
            }

            int pageCount = rowCount / Default.PageSize;
            if (pageCount <= 0)
            {
                pageCount = 1;
            }

            for (int i = 1; i <= pageCount; i++)
            {
                string addClass = string.Empty;

                if (i == this.CurrentPage)
                {
                    addClass = " class=\"active\"";
                }

                this.ArticlePaging.Text += string.Format("<li{0}><a href=\"{1}?page={2}\">{2}</a></li>", addClass, FriendlyUrl.Href("~/"), i);
            }

            if (this.CurrentPage < pageCount)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?page={1}\">&raquo;</a></li>", FriendlyUrl.Href("~/"), this.CurrentPage + 1);
            }
            else
            {
                this.ArticlePaging.Text += "<li class=\"disabled\"><span>&raquo;</span></li>";
            }
        }
    }
}