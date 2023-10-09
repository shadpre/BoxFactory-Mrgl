using BoxFactory_Mrgl.Models.Interfaces;
using System.Runtime.Serialization;

namespace BoxFactory_Mrgl.Models
{
  

    [DataContract]
    public class LineModel : ILineModel
    {
        [DataMember(Name = "lineId")]
        public int LineID { get; set; }
        [DataMember(Name = "item")]
        public int Item { get; set; }
        [DataMember(Name = "qty")]
        public decimal QTY { get; set; }
        [DataMember(Name = "discountPCT")]
        public decimal DiscountPCT { get; set; }
        [DataMember(Name = "grossPrice")]
        public decimal GrossPrice { get; set; }
        [DataMember(Name = "netPrice")]
        public decimal NetPrice { get; set; }
        [DataMember(Name = "total")]
        public decimal Total { get; set; }
        [DataMember(Name = "orderId")]
        public int OrderId { get; set; }
    }
}
