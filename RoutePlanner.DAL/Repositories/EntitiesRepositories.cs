using RoutePlanner.Entities;

namespace RoutePlanner.DAL.Repositories
{
    public class AccountsRepository : GenericRepository<Account> { }

    public class UsersRepository : GenericRepository<User> { }

    public class ContactsRepository : GenericRepository<Contact> { }

    public class AddressesRepository : GenericRepository<Address> { }

    public class MailingListsRepository : GenericRepository<MailingList> { }

    public class OrdersHistoryRepository : GenericRepository<Order> { }

    public class AuthorizationLevelsRepository : GenericRepository<AuthorizationLevel> { }

    public class OrderHistoryRepository : GenericRepository<Order> { }

    public class WaypointsRepository : GenericRepository<Waypoint> { }

    public class RoutesRepository : GenericRepository<Route> { }

    public class MatrixEntriesRepository : GenericRepository<MatrixEntry> { }

    public class AccountDestinationsRepository : GenericRepository<AccountAddress> { }

    public class AccountUsersRepository : GenericRepository<AccountUser> { }

    public class ContactAddressesRepository : GenericRepository<ContactAddress> { }

    public class MailingListContactsRepository : GenericRepository<MailingListContact> { }
}
