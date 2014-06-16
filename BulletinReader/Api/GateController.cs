namespace BulletinReader.Api
{
    using System.Security.Claims;
    using System.Web;
    using System.Web.Http;
    using BulletinReader.Api.App_LocalResources;
    using BulletinReader.Api.Classes;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    [RoutePrefix("api/gate")]
    public class GateController : ApiController
    {
        [Route("login")]
        public LoginResponse PostLogin([FromBody]LoginRequest loginRequest)
        {
            var user = Global.Instance.UserManager.FindByEmail(loginRequest.Email);

            if (user == null)
            {
                return new LoginResponse()
                {
                    Success = false,
                    Reason = string.Format(ApiLiterals.InvalidEmail, loginRequest.Email)
                };
            }

            if (!Global.Instance.UserManager.CheckPassword(user, loginRequest.Password))
            {
                return new LoginResponse()
                {
                    Success = false,
                    Reason = string.Format(ApiLiterals.InvalidPassword, loginRequest.Email)
                };
            }

            if (!user.EmailConfirmed)
            {
                return new LoginResponse()
                {
                    Success = false,
                    Reason = string.Format(ApiLiterals.EmailIsNotConfirmed, loginRequest.Email)
                };
            }

            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            ClaimsIdentity userIdentity = Global.Instance.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            authenticationManager.SignIn(
                new AuthenticationProperties() {
                    IsPersistent = true
                },
                userIdentity
            );

            return new LoginResponse()
            {
                Success = true
            };
        }

        [Route("logout")]
        public LogoutResponse PostLogout([FromBody]LogoutRequest logoutRequest)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return new LogoutResponse()
            {
                Success = true
            };
        }
    }
}