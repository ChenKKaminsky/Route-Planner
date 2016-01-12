using RoutePlanner.Entities;

namespace RoutePlanner.DAL.Interfaces
{
    public interface IAccountsRepository : IGenericRepository<Account> { }

    public interface IUsersRepository : IGenericRepository<User> { }

    public interface IContactsRepository : IGenericRepository<Contact> { }

    public interface IAddressesRepository : IGenericRepository<Address> { }

    public interface IMailingListsRepository : IGenericRepository<MailingList> { }

    public interface IOrdersHistoryRepository : IGenericRepository<Order> { }

    public interface IAuthorizationLevelsRepository : IGenericRepository<AuthorizationLevel> { }

    public interface IOrderHistoryRepository : IGenericRepository<Order> { }

    public interface IWaypointsRepository : IGenericRepository<Waypoint> { }

    public interface IRoutesRepository : IGenericRepository<Route> { }

    public interface IMatrixEntriesRepository : IGenericRepository<MatrixEntry> { }

    public interface IAccountDestinationsRepository : IGenericRepository<AccountAddress> { }

    public interface IAccountUsersRepository : IGenericRepository<AccountUser> { }

    public interface IContactAddressesRepository : IGenericRepository<ContactAddress> { }

    public interface IMailingListContactsRepository : IGenericRepository<MailingListContact> { }
}
