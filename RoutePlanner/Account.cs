using RoutePlanner.Entities.Interfaces;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class Account : IObjectWithState
    {
        public Account()
        {
            Contacts = new List<Contact>();
            MailingLists = new List<MailingList>();

            AccountDestinations = new List<AccountAddress>();
        }

        public int Id { get; set; }

        public string AccountName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<MailingList> MailingLists { get; set; }

        public virtual ICollection<AccountAddress> AccountDestinations { get; set; }

        public ICollection<Order> OrderHistory { get; set; }

        public virtual Settings Settings { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}
