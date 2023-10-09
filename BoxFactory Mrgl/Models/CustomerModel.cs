using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.Models
{
    [DataContract]
    public class CustomerModel : ICustomerModel
    {   
        /// <summary>
        /// Customer ID (Auto incremet from DB) ReadOnly from DB.
        /// </summary>
        [DataMember(Name = "customerId") ]
        public int CustomerId { get; set; } = 0;
        /// <summary>
        /// Customer Name.
        /// </summary>
        [DataMember(Name ="name")]
        [Required]
        [DisallowNull]
        public string Name { get; set; }
        /// <summary>
        /// Customer Phone.
        /// </summary>
        [DataMember(Name = "phone")]
        [Required]
        [DisallowNull]
        public string Phone { get; set; }
    }
}
