namespace BulletinReader
{
    using System;
    using System.Linq;
    using BulletinReader.DataClasses;
    using BulletinReader.Utils;

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

        protected string Highlight(string text)
        {
            foreach (string keyword in this.Keywords)
            {
                text = StringHelper.Replace(
                    text,
                    keyword,
                    found => string.Format("<span class=\"search-highlight\">{0}</span>", found),
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
                predicate = predicate.Or(p => p.Title.Contains(temp) || p.Review.Contains(temp));
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
                this.ArticlePaging.Text += string.Format("<li><a href=\"Search?q={0}&page={1}\">&laquo;</a></li>", this.Query, this.CurrentPage - 1);
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

                this.ArticlePaging.Text += string.Format("<li{0}><a href=\"Search?q={1}&page={2}\">{2}</a></li>", addClass, this.Query, i);
            }

            if (this.CurrentPage < pageCount)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"Search?q={0}&page={1}\">&raquo;</a></li>", this.Query, this.CurrentPage + 1);
            }
            else
            {
                this.ArticlePaging.Text += "<li class=\"disabled\"><span>&raquo;</span></li>";
            }
        }
    }
}