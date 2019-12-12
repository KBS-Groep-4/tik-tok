using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RoeiJeRot.Database.Database;
using RoeiJeRot.Logic;

namespace RoeiJeRot.View.Wpf.Logic
{
    /// <summary>
    ///     Data seeder that inserts test data into the database.
    /// </summary>
    internal class DataSeeder
    {
        private readonly RoeiJeRotDbContext _context;

        public DataSeeder(RoeiJeRotDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Inserts test data into database.
        /// </summary>
        public void Seed()
        {
            if (!EnumerableExtensions.Any(_context.Users))
                try
                {
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT users ON");
                    _context.SaveChanges();

                    SeedPermissions();
                    SeedUsers();
                    SeedUserPermissions();
                    SeedBoatTypes();
                    SeedBoats();
                    SeedReservations();

                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT users OFF");
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }

        private void SeedPermissions()
        {
            _context.Permissions.Add(new Permission
            {
               Id = 1, 
               Name = "ADMIN", 
            });

            _context.Permissions.Add(new Permission
            {
                Id = 2,
                Name = "MEMBER",
            });

            _context.Permissions.Add(new Permission
            {
                Id = 3,
                Name = "WC",
            });

            _context.Permissions.Add(new Permission
            {
                Id = 4,
                Name = "MC",
            });
            
            _context.Permissions.Add(new Permission
            {
                Id = 5,
                Name = "Staff",
            });

            _context.SaveChanges();
        }

        private void SeedUserPermissions()
        {
            _context.PermissionUsers.Add(new UserPermission()
            {
                Id = 1,
                PermissionId = 1,
                UserId = 3
            });

            _context.PermissionUsers.Add(new UserPermission()
            {
                Id = 1,
                PermissionId = 2,
                UserId = 4
            });

            _context.PermissionUsers.Add(new UserPermission()
            {
                Id = 1,
                PermissionId = 3,
                UserId = 7
            });

            _context.PermissionUsers.Add(new UserPermission()
            {
                Id = 1,
                PermissionId = 4,
                UserId = 6
            });

            _context.PermissionUsers.Add(new UserPermission()
            {
                Id = 1,
                PermissionId = 5,
                UserId = 8
            });
        }

        private void SeedUsers()
        {
            _context.Users.Add(new User
            {
                Id = 1,
                FirstName = "admin", LastName = "Hiemstra", City = "Zwolle", Country = "Nederland", HouseNumber = "2",
                Password = Hasher.Hash("123"), Username = "paul", SailingLevel = 1, StreetName = "Duckweg"
            });

            _context.Users.Add(new User
            {
                Id = 2,
                FirstName = "Frank", LastName = "Demilt", City = "Zwolle", Country = "Nederland", HouseNumber = "2",
                Password = Hasher.Hash("123"), Username = "frank", SailingLevel = 1, StreetName = "Duckweg"
            });
            
            _context.Users.Add(new User
            {
                Id = 3,
                FirstName = "Frank",
                LastName = "Demilt",
                City = "Zwolle",
                Country = "Nederland",
                HouseNumber = "2",
                Password = Hasher.Hash("admin"),
                Username = "admin",
                SailingLevel = 1,
                StreetName = "Duckweg"
            });

            _context.Users.Add(new User
            {
                Id = 4,
                FirstName = "Frank",
                LastName = "Demilt",
                City = "Zwolle",
                Country = "Nederland",
                HouseNumber = "2",
                Password = Hasher.Hash("member"),
                Username = "member",
                SailingLevel = 1,
                StreetName = "Duckweg"
            });

            _context.Users.Add(new User
            {
                Id = 6,
                FirstName = "Frank",
                LastName = "Demilt",
                City = "Zwolle",
                Country = "Nederland",
                HouseNumber = "2",
                Password = Hasher.Hash("mc"),
                Username = "mc",
                SailingLevel = 1,
                StreetName = "Duckweg"
            });

            _context.Users.Add(new User
            {
                Id = 7,
                FirstName = "Frank",
                LastName = "Demilt",
                City = "Zwolle",
                Country = "Nederland",
                HouseNumber = "2",
                Password = Hasher.Hash("wc"),
                Username = "wc",
                SailingLevel = 1,
                StreetName = "Duckweg"
            });

            _context.Users.Add(new User
            {
                Id = 8,
                FirstName = "Frank",
                LastName = "Demilt",
                City = "Zwolle",
                Country = "Nederland",
                HouseNumber = "2",
                Password = Hasher.Hash("staff"),
                Username = "staff",
                SailingLevel = 1,
                StreetName = "Duckweg"
            });

            _context.SaveChanges();
        }

        private void SeedBoats()
        {
            //Make for every boat type 5 boats
            foreach (BoatType type in _context.SailingBoatTypes)
                for (int i = 0; i < 5; i++)
                    _context.SailingBoats.Add(new SailingBoat { Status = 0, BoatTypeId = type.Id });

            _context.SaveChanges();
        }

        private void SeedBoatTypes()
        {
            _context.SailingBoatTypes.Add(new BoatType
                {PossiblePassengers = 3, RequiredLevel = 2, Name = "Grote kano"});
            _context.SailingBoatTypes.Add(
                new BoatType {PossiblePassengers = 1, RequiredLevel = 1, Name = "Kleine kano"});
            _context.SailingBoatTypes.Add(new BoatType()
            {
                PossiblePassengers = 5,
                Name = "Zeilboot",
                RequiredLevel = 5
            });
            _context.SailingBoatTypes.Add(new BoatType()
            {
                PossiblePassengers = 4,
                Name = "Zwaartboot",
                RequiredLevel = 6
            });
            _context.SailingBoatTypes.Add(new BoatType()
            {
                Name = "Flying Dutchman",
                PossiblePassengers = 5,
                RequiredLevel = 2
            });
            _context.SaveChanges();
        }

        private void SeedReservations()
        {
            _context.Reservations.Add(new SailingReservation
            {
                Date = DateTime.Now,
                Duration = TimeSpan.FromMinutes(50),
                ReservedByUserId = _context.Users.ToList()[0].Id,
                ReservedSailingBoatId = _context.SailingBoats.ToList()[0].Id
            });
            _context.Reservations.Add(new SailingReservation
            {
                Date = new DateTime(2020, 4, 9, 13, 30, 0),
                Duration = TimeSpan.FromMinutes(40),
                ReservedByUserId = _context.Users.ToList()[1].Id,
                ReservedSailingBoatId = _context.SailingBoats.ToList()[1].Id
            });
            _context.Reservations.Add(new SailingReservation
            {
                Date = new DateTime(2020, 4, 10, 13, 30, 0),
                Duration = TimeSpan.FromMinutes(90),
                ReservedByUserId = _context.Users.ToList()[1].Id,
                ReservedSailingBoatId = _context.SailingBoats.ToList()[1].Id
            });
            _context.Reservations.Add(new SailingReservation
            {
                Date = new DateTime(2020, 4, 9, 11, 30, 0),
                Duration = TimeSpan.FromMinutes(90),
                ReservedByUserId = _context.Users.ToList()[1].Id,
                ReservedSailingBoatId = _context.SailingBoats.ToList()[1].Id
            });
            _context.SaveChanges();
        }
    }
}