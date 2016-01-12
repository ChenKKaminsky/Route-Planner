
using RoutePlanner.Entities.Interfaces;

namespace RoutePlanner.Entities
{
    public class AccountAddress :IObjectWithState , IDentityProtected
    {
        public int Id { get; set; }

        public string AddressNickname { get; set; }

        public virtual Account Account { get; set; }
        public int AccountId { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}