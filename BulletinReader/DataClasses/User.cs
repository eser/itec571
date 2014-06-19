namespace BulletinReader.DataClasses
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
    }
}