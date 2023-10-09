namespace BoxFactory_Mrgl.Models.Interfaces
{
    public interface ILineModel
    {
        decimal DiscountPCT { get; set; }
        decimal GrossPrice { get; set; }
        int Item { get; set; }
        int LineID { get; set; }
        decimal NetPrice { get; set; }
        int OrderId { get; set; }
        decimal QTY { get; set; }
        decimal Total { get; set; }
    }
}
