using System.Runtime.Serialization;

namespace Demo.Services.Data.DataContracts.UserService
{
    [DataContract(Name = "GetUserByLoginResponse")]
    public class GetUserByLoginResponseDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
