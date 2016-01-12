using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoutePlanner.DAL.Repositories;
using RoutePlanner.Entities;
using System.Linq;

namespace RoutePlanner.Tests
{
    [TestClass]
    public class AccountRepositoryShould
    {
        [TestMethod]
        public void RetrieveContactInformationIncludingContacsAddresses()
        {
            Account account = null;

            using (var repo = new AccountsRepository())
            {
                account = repo.GetSingle(a => a.Id == 1);
            }

            var contactsCount = account.Contacts.Count;
            var accountContactsAddresses = account.Contacts.First().ContactAddresses.Select(ca => ca.Address).Count();

            Assert.IsTrue(contactsCount == 1);
            Assert.IsTrue(accountContactsAddresses > 1);




        }
    }
}
