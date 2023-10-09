using BoxFactory_Mrgl.Models.Interfaces;
using System.Runtime.Serialization;

namespace BoxFactory_Mrgl.Models
{
    
    [DataContract]
    public class OrderModel : IOrderModel
    {
        [DataMember(Name = "orderId")]
        public int OrderID { get; set; }
        [DataMember(Name = "customer")]
        public ICustomerModel Customer { get; set; }
        [DataMember(Name = "orderDate")]
        public DateTime OrderDate { get; set; }
        [DataMember(Name = "deliveryDate")]
        public DateTime DeliveryDate { get; set; }
        [DataMember(Name = "open")]
        public bool Open { get; set; }
        [DataMember(Name = "total")]
        public decimal Total { get; set; }
        [DataMember(Name = "lines")]
        public List<ILineModel> Lines { get; set; }
    }
}
