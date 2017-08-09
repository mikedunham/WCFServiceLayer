using System.Runtime.Serialization;

namespace Demo.Services.Data.DataContracts.UserService
{
    [DataContract(Name = "GetUserByLoginRequest")]
    public class GetUserByLoginRequestDataContract
    {
        [DataMember(IsRequired = true)]
        public string Login { get; set; }
    }
}
