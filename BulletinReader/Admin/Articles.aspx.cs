namespace BulletinReader.Admin
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.UI.WebControls;
    using BulletinReader.DataClasses;

    public partial class Articles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.FilterAuthor.Items.Clear();
                this.FilterAuthor.Items.Add(new ListItem("(All Authors)", "0"));

                var authors = (from author in Global.Instance.DbContextMain.Authors
                               orderby author.Name
                               select author);

                foreach (var authorItem in authors)
                {
                    string authorIdStr = authorItem.AuthorId.ToString();
                    this.FilterAuthor.Items.Add(new ListItem(authorItem.Name, authorIdStr));
                }

                this.RefillArticles();
            }

            if (this.GridView.Rows.Count > 0)
            {
                this.GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void RefillArticles()
        {
            Guid authorId;
            
            if (this.FilterAuthor.SelectedValue == "0")
            {
                authorId = Guid.Empty;
            }
            else
            {
                authorId = new Guid(this.FilterAuthor.SelectedValue);
            }

            Expression<Func<Article, bool>> predicate = rec => (authorId == Guid.Empty || rec.AuthorId == authorId);

            var purchasedItems = from article in Global.Instance.DbContextMain.Articles.Where(predicate)
                                 select article;

            this.GridView.DataSource = purchasedItems.ToList();
            this.GridView.DataBind();

            this.NoRecords.Visible = (purchasedItems.Count() < 1);
        }

        protected void btnRemoveArticle_Click(object sender, EventArgs e)
        {
            Button buttonObject = sender as Button;

            Guid articleId = new Guid(buttonObject.CommandArgument);

            var articles = (from article in Global.Instance.DbContextMain.Articles
                            where article.ArticleId == articleId
                            select article);

            Global.Instance.DbContextMain.Articles.RemoveRange(articles);
            Global.Instance.DbContextMain.SaveChanges();

            this.RefillArticles();
        }

        protected void FilterAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefillArticles();
        }
    }
}