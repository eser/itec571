using System.Runtime.Serialization;
namespace BulletinReader.DataClasses
{
    [DataContract]
    public enum PurchasedItemStatus
    {
        [DataMember]
        NotConfirmed,

        [DataMember]
        Confirmed
    }
}