namespace BulletinReader.Admin
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI.WebControls;
    using ArticleDataClass = BulletinReader.DataClasses.Article;

    public partial class ArticlesEdit : BasePage
    {
        public Guid ArticleId
        {
            get
            {
                if (this.Request.QueryString["id"] == null)
                {
                    return Guid.Empty;
                }

                return Guid.Parse(this.Request.QueryString["id"]);
            }
        }

        public ArticleDataClass ArticleEntity
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ArticleId == Guid.Empty)
            {
                throw new InvalidOperationException();
            }

            var articles = (from article in Global.Instance.DbContextMain.Articles
                           where article.ArticleId == this.ArticleId
                           select article);

            this.ArticleEntity = articles.FirstOrDefault();
            if (this.ArticleEntity == null)
            {
                throw new InvalidOperationException();
            }

            if (!this.IsPostBack)
            {
                this.RefillAuthors();

                this.Author.SelectedValue = this.ArticleEntity.AuthorId.ToString();
                this.ArticleTitle.Text = this.ArticleEntity.Title;
                this.PublishDate.Text = this.ArticleEntity.PublishDate.ToShortDateString();
                this.Review.Text = this.ArticleEntity.Review;
                this.Content.Text = this.ArticleEntity.Content;
            }
        }

        protected void RefillAuthors()
        {
            var authors = (from author in Global.Instance.DbContextMain.Authors
                           orderby author.Name
                           select author);

            foreach (var authorItem in authors)
            {
                string authorIdStr = authorItem.AuthorId.ToString();
                this.Author.Items.Add(new ListItem(authorItem.Name, authorIdStr));
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            this.ArticleEntity.AuthorId = Guid.Parse(this.Author.SelectedValue);
            this.ArticleEntity.Title = this.ArticleTitle.Text;
            this.ArticleEntity.PublishDate = DateTime.Parse(this.PublishDate.Text);
            this.ArticleEntity.Review = this.Review.Text;
            this.ArticleEntity.Content = this.Content.Text;

            if (this.CoverImage.HasFile)
            {
                // remove existing cover image first
                if (!string.IsNullOrWhiteSpace(this.ArticleEntity.CoverImagePath))
                {
                    string imagePath = Server.MapPath("~/Uploads") + "\\" + this.ArticleEntity.CoverImagePath;

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                string extension = Path.GetExtension(this.CoverImage.FileName);
                string filename = Guid.NewGuid().ToString() + extension;

                this.ArticleEntity.CoverImagePath = filename;

                this.CoverImage.SaveAs(Server.MapPath("~/Uploads") + "\\" + filename);
            }

            Global.Instance.DbContextMain.SaveChanges();

            this.AddFormNotification("success", "Success", "The article is updated successfully.");
        }
    }
}