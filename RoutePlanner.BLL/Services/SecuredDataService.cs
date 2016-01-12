using RoutePlanner.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutePlanner.DAL.Repositories;
using RoutePlanner.Entities;

namespace RoutePlanner.BLL.Services
{
    class SecuredDataService : ISecuredDataService
    {
        private AccountDestinationsRepository _accountDestinationsRepository;
        private AccountsRepository _accountRepository;
        private AccountUsersRepository _accountUserRepository;
        private AddressesRepository _addressesRepository;
        private ContactAddressesRepository _contactAddressesRepository;
        private ContactsRepository _contactsRepository;
        private MailingListContactsRepository _mailingListContactsRepository;
        private MailingListsRepository _mailingListsRepository;

        public SecuredDataService() : this(new AccountsRepository(),
            new AccountUsersRepository(),
            new AccountDestinationsRepository(),
            new AddressesRepository(),
            new ContactsRepository(),
            new ContactAddressesRepository(),
            new MailingListsRepository(),
            new MailingListContactsRepository())
        {

        }

        public SecuredDataService(AccountsRepository accountRepository,
            AccountUsersRepository accountUserRepository,
            AccountDestinationsRepository accountDestinationsRepository,
            AddressesRepository addressesRepository,
            ContactsRepository contactsRepository,
            ContactAddressesRepository contactAddressesRepository,
            MailingListsRepository mailingListsRepository,
            MailingListContactsRepository mailingListContactsRepository)
        {
            _accountRepository = accountRepository;
            _accountUserRepository = accountUserRepository;
            _accountDestinationsRepository = accountDestinationsRepository;
            _addressesRepository = addressesRepository;
            _contactsRepository = contactsRepository;
            _contactAddressesRepository = contactAddressesRepository;
            _mailingListsRepository = mailingListsRepository;
            _mailingListContactsRepository = mailingListContactsRepository;
        }

        public void CreateOrUpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateAddress(int accountId, Address address)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateContact(int accountId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateMailingList(int accountId, MailingList mailingList)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateUser(int accountId, User user)
        {
            throw new NotImplementedException();
        }

        public void GetAccountByAccounId(int accountId)
        {
            throw new NotImplementedException();
        }

        public void GetAddressesByAccounId(int accountId)
        {
            throw new NotImplementedException();
        }

        public void GetContactsByAccounId(int accountId)
        {
            throw new NotImplementedException();
        }

        public void GetMailingListsByAccounId(int accountId)
        {
            throw new NotImplementedException();
        }

        public void GetUsersByAccounId(int accountId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAddress(int accountId, Address address)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(int accountId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public void RemoveMailingList(int accountId, MailingList mailingList)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int accountId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
