using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Entities
{
    public class MatrixEntry : IObjectWithState
    {
        public int Id { get; set; }

        public int OriginId { get; set; }

        public int DestinationId { get; set; }

        public int Value { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}
