using RoutePlanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL.Interfaces
{
    public interface ISecuredDataService
    {
        void CreateOrUpdateAccount(Account account);
        void CreateOrUpdateUser(int accountId, User user);
        void CreateOrUpdateContact(int accountId, Contact contact);
        void CreateOrUpdateAddress(int accountId, Address address);
        void CreateOrUpdateMailingList(int accountId, MailingList mailingList);

        void GetAccountByAccounId(int accountId);
        void GetUsersByAccounId(int accountId);
        void GetContactsByAccounId(int accountId);
        void GetAddressesByAccounId(int accountId);
        void GetMailingListsByAccounId(int accountId);

        void RemoveAccount(Account account);
        void RemoveUser(int accountId, User user);
        void RemoveContact(int accountId,Contact contact);
        void RemoveAddress(int accountId,Address address);
        void RemoveMailingList(int accountId,MailingList mailingList);
    }
}
