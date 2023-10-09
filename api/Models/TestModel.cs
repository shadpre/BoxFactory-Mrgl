using System.Runtime.Serialization;

namespace BoxFactory_Mrgl.Models
{
    [DataContract]
    public class TestModel
    {
        [DataMember]
        public string Message { get; set; }
    }
}
