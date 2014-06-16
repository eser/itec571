namespace BulletinReader.Api.Classes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LoginRequest : BaseRequest
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}