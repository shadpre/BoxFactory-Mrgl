namespace BoxFactory_Mrgl.Models.Interfaces
{
    public interface IOrderModel
    {
        ICustomerModel Customer { get; set; }
        DateTime DeliveryDate { get; set; }
        List<ILineModel> Lines { get; set; }
        bool Open { get; set; }
        DateTime OrderDate { get; set; }
        int OrderID { get; set; }
        decimal Total { get; set; }
    }
}
