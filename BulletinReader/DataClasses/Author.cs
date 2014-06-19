namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract, Table("Authors")]
    public class Author
    {
        [DataMember, Key]
        public Guid AuthorId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Birthdate { get; set; }
    }
}