using System.Runtime.Serialization;

namespace Demo.Services.Data.FaultExceptions
{
    [DataContract]
    public class DataFault
    {
        [DataMember]
        public string Issue { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public string MoreInformation { get; set; }
    }
}
