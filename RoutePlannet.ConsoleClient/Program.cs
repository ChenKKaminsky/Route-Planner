using RoutePlanner.DAL.Contexts;
using RoutePlanner.DAL.Repositories;
using RoutePlanner.Entities;
using RoutePlanner.Entities.Interfaces;
using System;
using System.Linq;

namespace BestPracticesPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RpDbContext();

            context.Database.Initialize(true);

            Contact contact;
            using (var repo = new ContactsRepository())
            {
                contact = repo.GetSingle(c => c.Id == 1);
            }

            contact.FirstName = "changed";
            contact.ObjectState = ObjectState.Modified;

            var address = contact.ContactAddresses.FirstOrDefault(a => a.Address.Id == contact.PrimaryAddressId).Address;
            address.SecondLine = "Hacked";
            address.ObjectState = ObjectState.Modified;

            contact.ContactAddresses.FirstOrDefault(a => a.Address.Id == contact.PrimaryAddressId).ObjectState = ObjectState.Modified;

            using (var repo = new ContactsRepository())
            {
                repo.InsertOrUpdate(contact);
                repo.SaveChanges();
            }



            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadKey();
        }

        private static void ShowRecordState(RpDbContext context)
        {
            var storedAccount = context.Accounts.FirstOrDefault();

            if (storedAccount != null)
            {
                Console.WriteLine(storedAccount.AccountName);
                Console.WriteLine("Settings:\n{0}\n{1}\n{2}", storedAccount.Settings.MaxPickupsPerCar, storedAccount.Settings.MaxTripDuration,
                    storedAccount.Settings.MinPickupsPerCar);
                Console.WriteLine("Contacts:");
                foreach (var cnt in storedAccount.Contacts)
                {
                    Console.WriteLine(cnt.FirstName + " " + cnt.LastName);
                    Console.WriteLine("Primary Address:");
                    Console.WriteLine(cnt.ContactAddresses.FirstOrDefault(a => a.Address.Id == cnt.PrimaryAddressId).Address.FirstLine);
                }
                Console.WriteLine("Destinations: ");
                foreach (var dst in storedAccount.AccountDestinations)
                {
                    Console.WriteLine(dst.AddressNickname + ": " + dst.Address.FirstLine);
                }
                Console.WriteLine("Mailing Lists:");
                foreach (var mailList in storedAccount.MailingLists)
                {
                    Console.WriteLine(mailList.Name + ": ");
                    foreach (var mcnt in mailList.MailingListContacts)
                    {
                        Console.WriteLine(mcnt.Contact.FirstName + ": " + mcnt.Contact.Email);
                    }
                }
            }
            else
            {
                Console.WriteLine("No recordes found");
            }
        }
       
    }
}

