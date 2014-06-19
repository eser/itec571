namespace BulletinReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BulletinReader.DataClasses;
    using BulletinReader.Utils;
    using Microsoft.AspNet.FriendlyUrls;
    using AuthorDataClass = BulletinReader.DataClasses.Author;

    public partial class Author : BasePage
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

        public AuthorDataClass AuthorEntity
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Guid authorGuid;
            if (string.IsNullOrWhiteSpace(this.Request.QueryString["id"]) || !Guid.TryParse(this.Request.QueryString["id"], out authorGuid) || authorGuid == Guid.Empty)
            {
                throw new InvalidOperationException();
            }

            var authors = (from author in Global.Instance.DbContextMain.Authors
                           where author.AuthorId == authorGuid
                           select author);
            */

            List<string> segments = new List<string>(this.Request.GetFriendlyUrlSegments());
            if (segments.Count < 1 || string.IsNullOrWhiteSpace(segments[0]))
            {
                // throw new InvalidOperationException();
            }

            string authorName = HttpUtility.UrlDecode(segments[0]);
            var authors = (from author in Global.Instance.DbContextMain.Authors
                           where author.Name == authorName
                           select author);

            this.AuthorEntity = authors.SingleOrDefault();

            if (!this.IsPostBack)
            {
                this.FetchData();
            }
        }

        private void FetchData()
        {
            var articles = (from article in Global.Instance.DbContextMain.Articles.Where(a => a.AuthorId == this.AuthorEntity.AuthorId)
                            orderby article.StoreDate descending, article.PublishDate descending
                            select article);

            int skip = (this.CurrentPage - 1) * Default.PageSize;
            int rowCount = 0;
            if (skip >= 0 && this.AuthorEntity != null)
            {
                this.ArticleRepeater.DataSource = articles.Skip(skip).Take(Default.PageSize).ToList();
                this.ArticleRepeater.DataBind();

                rowCount = articles.Count();
            }

            this.ArticlePaging.Text = "";

            if (this.CurrentPage > 1)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?page={1}\">&laquo;</a></li>", FriendlyUrl.Href("~/Author", this.AuthorEntity.Name), this.CurrentPage - 1);
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

                this.ArticlePaging.Text += string.Format("<li{0}><a href=\"{1}?page={2}\">{2}</a></li>", addClass, FriendlyUrl.Href("~/Author", this.AuthorEntity.Name), i);
            }

            if (this.CurrentPage < pageCount)
            {
                this.ArticlePaging.Text += string.Format("<li><a href=\"{0}?page={1}\">&raquo;</a></li>", FriendlyUrl.Href("~/Author", this.AuthorEntity.Name), this.CurrentPage + 1);
            }
            else
            {
                this.ArticlePaging.Text += "<li class=\"disabled\"><span>&raquo;</span></li>";
            }
        }
    }
}