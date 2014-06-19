namespace BulletinReader.Admin
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI.WebControls;
    using ArticleDataClass = BulletinReader.DataClasses.Article;

    public partial class ArticlesAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.RefillAuthors();
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

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            ArticleDataClass newArticle = new ArticleDataClass()
            {
                AuthorId = Guid.Parse(this.Author.SelectedValue),
                Title = this.ArticleTitle.Text,
                PublishDate = DateTime.Parse(this.PublishDate.Text),
                StoreDate = DateTime.UtcNow,
                Review = this.Review.Text,
                Content = this.Content.Text
            };

            if (this.CoverImage.HasFile)
            {
                string extension = Path.GetExtension(this.CoverImage.FileName);
                string filename = Guid.NewGuid().ToString() + extension;

                newArticle.CoverImagePath = filename;

                this.CoverImage.SaveAs(Server.MapPath("~/Uploads") + "\\" + filename);
            }

            Global.Instance.DbContextMain.Articles.Add(newArticle);
            Global.Instance.DbContextMain.SaveChanges();

            this.AddFormNotification("success", "Success", "A new article has been added.");
        }
    }
}