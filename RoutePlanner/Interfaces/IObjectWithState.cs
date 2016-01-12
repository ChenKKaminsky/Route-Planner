using System;

namespace RoutePlanner.Entities.Interfaces
{
    public interface IObjectWithState
    {
        ObjectState ObjectState { get; set; }

        int Id { get; set; }

    }
    public enum ObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
