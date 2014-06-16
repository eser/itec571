namespace BulletinReader.DataClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PurchasedItems")]
    public class PurchasedItem
    {
        [Key]
        public Guid PurchasedItemId { get; set; }

        public DateTime TransactionDate { get; set; }

        public PurchasedItemStatus Status { get; set; }

        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}