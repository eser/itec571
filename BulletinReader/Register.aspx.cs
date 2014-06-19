namespace BulletinReader
{
    using System;
    using System.Security.Claims;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using UserDataClass = BulletinReader.DataClasses.User;

    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnSubmitButton_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            UserDataClass previousUser = Global.Instance.UserManager.FindByEmail(this.txtEmail.Text);
            if (previousUser != null)
            {
                this.AddFormNotification("danger", "Error", string.Format("E-mail '{0}' is already taken.", this.txtEmail.Text));
                return;
            }

            UserDataClass user = new UserDataClass() {
                UserName = this.txtUsername.Text,
                Fullname = this.txtFullname.Text,
                Email = this.txtEmail.Text,
                EmailConfirmed = true,
                PhoneNumber = this.txtPhoneNumber.Text,
                PhoneNumberConfirmed = true,
                Address = this.txtAddress.Text
            };

            IdentityResult userResult = await Global.Instance.UserManager.CreateAsync(user, this.txtPassword.Text);

            if (userResult.Succeeded)
            {
                await Global.Instance.UserManager.AddToRoleAsync(user.Id, "users");

                ClaimsIdentity userIdentity = await Global.Instance.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignIn(
                    new AuthenticationProperties()
                    {
                        IsPersistent = true
                    },
                    userIdentity
                );

                this.AddNotification("success", "Welcome", string.Format("{0}, your registration is successfully completed.", user.Fullname));
                this.Response.Redirect("~/", false);
                this.Context.ApplicationInstance.CompleteRequest();

                return;
            }

            this.AddFormNotification("danger", "Error", string.Join(Environment.NewLine, userResult.Errors));
        }
    }
}