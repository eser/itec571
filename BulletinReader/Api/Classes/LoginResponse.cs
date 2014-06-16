namespace BulletinReader.Api.Classes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LoginResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }
    }
}