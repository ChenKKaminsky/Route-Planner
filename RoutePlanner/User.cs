using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class User : IObjectWithState
    {
        public User()
        {
            AccessibleAccounts = new List<AccountUser>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ICollection<AccountUser> AccessibleAccounts { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}