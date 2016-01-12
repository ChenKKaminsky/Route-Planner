using RoutePlanner.Entities.Interfaces;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class MailingList : IObjectWithState , IDentityProtected
    {
        public MailingList()
        {
            MailingListContacts = new List<MailingListContact>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MailingListContact> MailingListContacts { get; set; }

        public ObjectState ObjectState { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}