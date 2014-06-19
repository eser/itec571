namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract, Table("PurchasedItems")]
    public class PurchasedItem
    {
        [DataMember, Key]
        public Guid PurchasedItemId { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public PurchasedItemStatus Status { get; set; }

        [DataMember, ForeignKey("Article")]
        public Guid ArticleId { get; set; }

        [DataMember]
        public virtual Article Article { get; set; }

        [DataMember, ForeignKey("User")]
        public string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }
    }
}