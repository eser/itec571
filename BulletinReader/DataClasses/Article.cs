namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract, Table("Articles")]
    public class Article
    {
        [DataMember, Key]
        public Guid ArticleId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Review { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string CoverImagePath { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

        [DataMember]
        public DateTime StoreDate { get; set; }

        [DataMember, ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        [DataMember]
        public virtual Author Author { get; set; }
    }
}