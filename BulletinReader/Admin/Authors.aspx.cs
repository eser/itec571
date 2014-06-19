namespace BulletinReader.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using AuthorDataClass = BulletinReader.DataClasses.Author;

    public partial class Authors : BasePage
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
            string oldValue = this.Author.SelectedValue;

            this.Author.Items.Clear();
            this.Author.Items.Add(new ListItem("(New Record)", "0"));

            var authors = (from author in Global.Instance.DbContextMain.Authors
                           orderby author.Name
                           select author);

            foreach (var authorItem in authors)
            {
                string authorIdStr = authorItem.AuthorId.ToString();
                this.Author.Items.Add(new ListItem(authorItem.Name, authorIdStr));
                if (oldValue == authorIdStr)
                {
                    this.Author.SelectedValue = authorIdStr;
                }
            }
        }

        protected void Author_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NotificationArea.Text = string.Empty;

            if (this.Author.SelectedIndex == 0)
            {
                this.Name.Text = string.Empty;
                this.Birthdate.Text = string.Empty;
                return;
            }

            Guid authorGuid = Guid.Parse(this.Author.SelectedValue);
            var authors = (from author in Global.Instance.DbContextMain.Authors
                           where author.AuthorId == authorGuid
                           select author);

            var selectedAuthor = authors.SingleOrDefault();
            if (selectedAuthor == null)
            {
                throw new InvalidOperationException();
            }

            this.Name.Text = selectedAuthor.Name;
            this.Birthdate.Text = selectedAuthor.Birthdate.ToShortDateString();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            // insert
            if (this.Author.SelectedIndex == 0)
            {
                AuthorDataClass newAuthor = new AuthorDataClass()
                {
                    Name = this.Name.Text,
                    Birthdate = DateTime.Parse(this.Birthdate.Text)
                };

                Global.Instance.DbContextMain.Authors.Add(newAuthor);
                Global.Instance.DbContextMain.SaveChanges();

                this.RefillAuthors();
                this.Author.SelectedValue = newAuthor.AuthorId.ToString();

                this.AddFormNotification("success", "Success", "A new author record has been added.");
            }

            // update
            else
            {
                var authors = (from author in Global.Instance.DbContextMain.Authors
                               where author.AuthorId == Guid.Parse(this.Author.SelectedValue)
                               select author);

                var selectedAuthor = authors.SingleOrDefault();
                if (selectedAuthor == null)
                {
                    throw new InvalidOperationException();
                }

                selectedAuthor.Name = this.Name.Text;
                selectedAuthor.Birthdate = DateTime.Parse(this.Birthdate.Text);

                Global.Instance.DbContextMain.SaveChanges();

                this.RefillAuthors();
                this.AddFormNotification("success", "Success", "Record has been updated.");
            }
        }
    }
}