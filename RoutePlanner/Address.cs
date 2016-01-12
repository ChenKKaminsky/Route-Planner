using RoutePlanner.Entities.Interfaces;
using System;

namespace RoutePlanner.Entities
{
    public class Address : IArchivable, IObjectWithState
    {
        public int Id { get; set; }

        public string FirstLine { get; set; }

        public string SecondLine { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public bool IsArchived { get; set; }

        public ObjectState ObjectState { get; set; }

        public override string ToString()
        {
            return string.Concat(PostCode + "+" + City);
        }
    }
}