using RoutePlanner.Entities.Interfaces;

namespace RoutePlanner.Entities
{
    public class AccountUser : IObjectWithState, IDentityProtected
    {
        public int Id { get; set; }

        public virtual Account Account { get; set; }
        public int AccountId { get; set; }

        public virtual User User  { get; set; }
        public int UserId { get; set; }

        public virtual AuthorizationLevel AuthorizationLevel { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}