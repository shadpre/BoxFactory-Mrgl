using System.Runtime.Serialization;

namespace BoxFactory_Mrgl.Models.Interfaces
{    
    public interface IInventoryModel
    {
        int BoxId { get; set; }
        string Description { get; set; }
        decimal Height { get; set; }
        decimal InOrder { get; set; }
        decimal Length { get; set; }
        decimal Price { get; set; }
        decimal Volumen { get; }
        decimal VolumenLiters { get; }
        decimal Width { get; set; }
    }
}
