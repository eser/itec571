namespace BulletinReader.DataClasses
{
    using System.Runtime.Serialization;
    using Microsoft.AspNet.Identity.EntityFramework;

    [DataContract]
    public class User : IdentityUser
    {
        [DataMember]
        public string Fullname { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}