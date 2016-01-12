using RoutePlanner.Entities.Interfaces;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class Contact : IArchivable, IObjectWithState , IDentityProtected
    {
        public Contact()
        {
            ContactAddresses = new List<ContactAddress>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? PrimaryAddressId { get; set; }

        public virtual ICollection<ContactAddress> ContactAddresses { get; set; }

        public int AccountId { get; set; }

        public bool IsArchived { get; set; }

        public ObjectState ObjectState { get; set; }

        public string FullName
        {
            get
            {
                return string.Concat(FirstName + " " + LastName);
            }
        }

        public string FullNameReverse
        {
            get
            {
                return string.Concat(LastName + ", " +  FirstName);
            }
        }
    }
}
