
using RoutePlanner.Entities;
using System;
using System.Data.Entity;

namespace RoutePlanner.DAL.Contexts
{
    public class RpDbContext : BaseContext<RpDbContext> 
    {
        public RpDbContext() : base()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<RpDbContext, Configuration>());
            Database.SetInitializer(new RpDbInitializer());

            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }
        public DbSet<AccountAddress> AccountDestinations { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<MailingListContact> MailingListContacts { get; set; }
        public DbSet<AuthorizationLevel> AuthorizationLevels { get; set; }


        public DbSet<Order> OrdersHistory { get; set; }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
        public DbSet<MatrixEntry> MatrixEntries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Ignore(e => e.ObjectState);
            modelBuilder.Entity<Contact>().Ignore(e => e.ObjectState);
            modelBuilder.Entity<MailingList>().Ignore(e => e.ObjectState);
            modelBuilder.Entity<User>().Ignore(e => e.ObjectState);
            modelBuilder.Entity<Account>().Ignore(e => e.ObjectState);

            modelBuilder.Entity<ContactAddress>().HasKey(ca => new { ca.ContactId, ca.AddressId });
            modelBuilder.Entity<ContactAddress>().Ignore(e => e.ObjectState);

            modelBuilder.Entity<MailingListContact>().HasKey(ca => new { ca.MailingListId , ca.ContactId});
            modelBuilder.Entity<MailingListContact>().Ignore(e => e.ObjectState);

            modelBuilder.Entity<AccountUser>().HasKey(ca => new { ca.AccountId , ca.UserId });
            modelBuilder.Entity<AccountUser>().Ignore(e => e.ObjectState);

            base.OnModelCreating(modelBuilder);
        }
    }
}
