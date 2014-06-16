namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Articles")]
    public class Article
    {
        [Key]
        public Guid ArticleId { get; set; }

        public string Title { get; set; }

        public string Review { get; set; }

        public string Content { get; set; }

        public string CoverImagePath { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime StoreDate { get; set; }

        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}