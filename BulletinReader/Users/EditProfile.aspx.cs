namespace BulletinReader.Users
{
    using System;
    using Microsoft.AspNet.Identity;
    using UserDataClass = BulletinReader.DataClasses.User;

    public partial class EditProfile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.txtFullname.Text = this.LoggedUser.Fullname;
                this.txtEmail.Text = this.LoggedUser.Email;
                this.txtPhoneNumber.Text = this.LoggedUser.PhoneNumber;
                this.txtAddress.Text = this.LoggedUser.Address;
            }
        }

        protected async void btnSubmitButton_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            UserDataClass previousUser = Global.Instance.UserManager.FindByEmail(this.txtEmail.Text);
            if (previousUser != null && previousUser.Id != this.LoggedUser.Id)
            {
                this.AddFormNotification("danger", "Error", string.Format("E-mail '{0}' is already taken.", this.txtEmail.Text));
                return;
            }

            if (!string.IsNullOrEmpty(this.txtCurrentPassword.Text) || !string.IsNullOrEmpty(this.txtPassword.Text))
            {
                IdentityResult userResult = await Global.Instance.UserManager.ChangePasswordAsync(this.LoggedUser.Id, this.txtCurrentPassword.Text, this.txtPassword.Text);

                if (userResult.Succeeded)
                {
                    this.AddFormNotification("success", "Success", "Your password has been changed.");
                }
                else
                {
                    this.AddFormNotification("danger", "Error", string.Join(Environment.NewLine, userResult.Errors));
                    return;
                }
            }

            this.LoggedUser.Fullname = this.txtFullname.Text;
            this.LoggedUser.Email = this.txtEmail.Text;
            this.LoggedUser.PhoneNumber = this.txtPhoneNumber.Text;
            this.LoggedUser.Address = this.txtAddress.Text;

            IdentityResult userResult2 = await Global.Instance.UserManager.UpdateAsync(this.LoggedUser);

            if (userResult2.Succeeded)
            {
                this.AddFormNotification("success", "Success", "Your information has been updated.");
            }
            else
            {
                this.AddFormNotification("danger", "Error", string.Join(Environment.NewLine, userResult2.Errors));
            }
        }
    }
}