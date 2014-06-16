namespace BulletinReader.Api
{
    using System.Web.Http;
    using BulletinReader.Api.App_LocalResources;
    using BulletinReader.Api.Classes;

    public class LoginController : ApiController
    {
        // POST api/login
        public LoginResponse Post([FromBody]LoginRequest loginRequest)
        {
            LoginResponse response;

            if (loginRequest.Email == "eser@sent.com")
            {
                response = new LoginResponse()
                {
                    Success = true
                };
            }
            else
            {
                response = new LoginResponse()
                {
                    Success = false,
                    Reason = string.Format(ApiLiterals.InvalidEmail, loginRequest.Email)
                };
            }

            return response;
        }
    }
}