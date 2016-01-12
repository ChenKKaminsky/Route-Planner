using RoutePlanner.Entities;
using System;
using System.Data.Entity;

namespace RoutePlanner.DAL.Contexts
{
    class RpDbInitializer : CreateDatabaseIfNotExists<RpDbContext>
    {
        protected override void Seed(RpDbContext context)
        {
            #region Accounts
            var accountCargo = new Account()
            {
                AccountName = "El Al Cargo",
                Settings = new Settings()
                {
                    MaxPickupsPerCar = 3,
                    MaxTripDuration = 75,
                    MinPickupsPerCar = 2
                }
            };
            context.Accounts.Add(accountCargo);

            var accountKiko = new Account()
            {
                AccountName = "Kiko",
                Settings = new Settings()
                {
                    MaxPickupsPerCar = 4,
                    MaxTripDuration = 45,
                    MinPickupsPerCar = 2
                }
            };
            context.Accounts.Add(accountKiko);

            context.SaveChanges();
            #endregion

            #region Users

            var userCargoAdmin = new User()
            {
                Username = "ChenKK",
                LastLogin = DateTime.Now,
                Email = "ckchenkeren@gmail.com",

            };
            userCargoAdmin.AccessibleAccounts.Add(
                            new AccountUser()
                            {
                                AuthorizationLevel = new AuthorizationLevel()
                                {
                                    Description = "admin"
                                },
                                AccountId = accountCargo.Id
                            });
            context.Users.Add(userCargoAdmin);

            var userCargoUser = new User()
            {
                Username = "YanivZ",
                LastLogin = DateTime.Now,
                Email = "Yzelenco@gmail.com",

            };
            userCargoUser.AccessibleAccounts.Add(
                            new AccountUser()
                            {
                                AuthorizationLevel = new AuthorizationLevel()
                                {
                                    Description = "user"
                                },
                                AccountId = accountCargo.Id
                            });

            context.Users.Add(userCargoUser);

            var userKikoAdmin = new User()
            {
                Username = "BiancaKK",
                LastLogin = DateTime.Now,
                Email = "biancakerenkaminsky@gmail.com",

            };
            userKikoAdmin.AccessibleAccounts.Add(
                            new AccountUser()
                            {
                                AuthorizationLevel = new AuthorizationLevel()
                                {
                                    Description = "admin"
                                },
                                AccountId = accountKiko.Id
                            });
            context.Users.Add(userKikoAdmin);
            context.SaveChanges();
            #endregion

            #region Destinations
            var destinationAddressCargo = new Address()
            {
                IsArchived = false,
                FirstLine = "502 Shoreham Rd",
                SecondLine = "London Heatrow Airport , Hounslow",
                PostCode = "TW6 3UA",
                City = "London",
                Country = "United Kingdom"
            };
            context.Addresses.Add(destinationAddressCargo);

            accountCargo.AccountDestinations.Add(
                new AccountAddress()
                {
                    Account = accountCargo,
                    Address = destinationAddressCargo,
                    AddressNickname = "Cargo Warehouse"
                });

            var destinationAddressKiko = new Address()
            {
                IsArchived = false,
                FirstLine = "Westfield White City",
                SecondLine = "Ariel Road",
                PostCode = "W13 0AX",
                City = "London",
                Country = "United Kingdom"
            };
            context.Addresses.Add(destinationAddressKiko);

            accountKiko.AccountDestinations.Add(
                new AccountAddress()
                {
                    Account = accountKiko,
                    Address = destinationAddressKiko,
                    AddressNickname = "White City"
                });

            context.SaveChanges();

            #endregion

            #region Contacts
            var contactCargoPrimaryAddress = new Address()
            {
                FirstLine = "6 Bridgeman House",
                SecondLine = "Pump House Crescent",
                PostCode = "TW8 0FX",
                City = "London",
                Country = "United Kingdom",
            };
            context.Addresses.Add(contactCargoPrimaryAddress);

            var contactCargoSecondaryAddress = new Address()
            {
                FirstLine = "23 Balmain Close",
                SecondLine = "Ealing Broadway",
                PostCode = "W5 5BY",
                City = "London",
                Country = "United Kingdom",
            };
            context.Addresses.Add(contactCargoSecondaryAddress);
            context.SaveChanges();

            var contactCargo = new Contact()
            {
                FirstName = "Chen",
                LastName = "Keren Kaminsky",
                Email = "ckchenkeren@gmail.com",
                Phone = "07474772070",
                IsArchived = false,
                PrimaryAddressId = contactCargoPrimaryAddress.Id
            };
            context.Contacts.Add(contactCargo);
            accountCargo.Contacts.Add(contactCargo);

            context.SaveChanges();

            contactCargo.ContactAddresses.Add(
                new ContactAddress()
                {
                    Contact = contactCargo,
                    Address = contactCargoPrimaryAddress
                });
            contactCargo.ContactAddresses.Add(
                new ContactAddress()
                {
                    Contact = contactCargo,
                    Address = contactCargoSecondaryAddress
                });
            #endregion

            #region MailingContacts
            var mailingContact = new Contact()
            {
                FirstName = "Dina",
                LastName = "Barel",
                Email = "ckchenkeren@gmail.com",
                Phone = "0208000000",
                IsArchived = false,
                PrimaryAddressId = null,
            };
            context.Contacts.Add(mailingContact);
            context.SaveChanges();

            var mailingList = new MailingList()
            {
                Name = "Default"
            };
            context.MailingLists.Add(mailingList);
            context.SaveChanges();

            mailingList.MailingListContacts.Add(new MailingListContact()
            {
                Contact = mailingContact,
                MailingList = mailingList
            });

            accountCargo.MailingLists.Add(mailingList);

            #endregion

            context.SaveChanges();
        }
    }
}
