namespace BulletinReader
{
    using System;
    using System.Linq;
    using BulletinReader.DataClasses;
    using BulletinReader.Utils;
    using Microsoft.AspNet.FriendlyUrls;

    public partial class Search : BasePage
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

        public string Query
        {
            get;
            private set;
        }

        public string[] Keywords
        {
            get;
            private set;
        }

        protected string Highlight(string text, string addClass = "search-highlight")
        {
            foreach (string keyword in this.Keywords)
            {
                text = StringHelper.Replace(
                    text,
                    keyword,
                    found => string.Format("<span class=\"{0}\">{1}</span>", addClass, found),
                    StringComparison.CurrentCultureIgnoreCase
                );
            }

            return text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Query = this.Request.QueryString["q"];

            if (!string.IsNullOrWhiteSpace(this.Query))
            {
                this.Keywords = this.Query.ToLower().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                this.Query = string.Join(" ", this.Keywords);
            }
            else
            {
                this.Keywords = new string[0];
                this.Query = string.Empty;
            }

            if (!this.IsPostBack)
            {
                this.FetchData();
            }
        }

        private void FetchData()
        {

            var predicate = PredicateBuilder.False<Article>();
            foreach (string keyword in this.Keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => p.Title.Contains(temp) || p.Review.Contains(temp) || p.Author.Name.Contains(temp));
            }

            var articles = (from article in Global.Instance.DbContextMain.Articles.Where(predicate)
                            orderby article.StoreDate descending, article.PublishDate descending
                            select new { Article = article, Author = article.Author });

            int skip = (this.CurrentPage - 1) * Default.PageSize;
            int rowCount = 0;
            if (skip >= 0 && this.Keywords.Length > 0)
            {
                this.ArticleRepeater.DataSource = articles.Skip(skip).Take(Default.PageSize).ToList();
                this.ArticleRepeater.DataBind();

                rowCount = articles.Count();
            }

            this.ArticlePaging.Text = "";

            if (this.CurrentPage > 1)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?q={1}&page={2}\">&laquo;</a></li>", FriendlyUrl.Href("~/Search"), this.Query, this.CurrentPage - 1);
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

                this.ArticlePaging.Text += string.Format("<li{0}><a href=\"{1}?q={2}&page={3}\">{3}</a></li>", addClass, FriendlyUrl.Href("~/Search"), this.Query, i);
            }

            if (this.CurrentPage < pageCount)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?q={1}&page={2}\">&raquo;</a></li>", FriendlyUrl.Href("~/Search"), this.Query, this.CurrentPage + 1);
            }
            else
            {
                this.ArticlePaging.Text += "<li class=\"disabled\"><span>&raquo;</span></li>";
            }
        }
    }
}