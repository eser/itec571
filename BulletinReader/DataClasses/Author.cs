namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Authors")]
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }

        public string Name { get; set; }
    }
}