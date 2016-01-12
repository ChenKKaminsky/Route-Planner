using RoutePlanner.Entities.Interfaces;
using System;

namespace RoutePlanner.Entities
{
    public class MailingListContact : IObjectWithState
    {
        public int Id { get; set; }

        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }

        public virtual MailingList MailingList { get; set; }
        public int MailingListId { get; set; }

        public ObjectState ObjectState { get; set; }

    }
}