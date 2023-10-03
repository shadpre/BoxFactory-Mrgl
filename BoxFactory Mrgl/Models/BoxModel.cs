using System.Runtime.Serialization;

namespace BoxFactory_Mrgl.Models
{
    [DataContract]
    public class BoxModel
    {
        /// <summary>
        /// ID - Unique identifier.
        /// </summary>
        [DataMember(Name = "boxId")]
        public int BoxId { get; set; } = 0;
        /// <summary>
        /// Length in mm
        /// </summary>
        [DataMember(Name = "length")]
        public decimal Length { get; set; }
        /// <summary>
        /// Height in mm
        /// </summary>
        [DataMember(Name = "height")]
        public decimal Height { get; set; }
        /// <summary>
        /// Width in mm
        /// </summary>
        [DataMember(Name = "width")]
        public decimal Width { get; set; }
        /// <summary>
        /// Price in DKK
        /// </summary>
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Volumen in mm2
        /// </summary>        
        ///         
        public decimal Volumen
        {
            get { return Length * Height * Width; }
        }
        /// <summary>
        /// Volumen in liters
        /// </summary>
        /// <returns>Volumen in Liters</returns>
        public decimal VolumenLiters
        {
            get { return Volumen / 1000000; }
        }
    }
}
