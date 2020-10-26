using Microsoft.EntityFrameworkCore;
using Naklinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Context
{
    public class NaklinetDbContext : DbContext
    {
        public NaklinetDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<DocumentTypes> DocumentTypes { get; set; }
        public DbSet<RoomCount> RoomCounts { get; set; }
        public DbSet<ToAddresses> ToAddresses { get; set; }
        public DbSet<FromAddresses> FromAddresses { get; set; }
        public DbSet<PackagingOptions> PackagingOptions { get; set; }
        public DbSet<Factors> Factors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity
                .HasOne(vehicle => vehicle.VehicleType)
                .WithMany(type => type.Vehicles)
                .HasForeignKey(vehicle => vehicle.TypeID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(vehicle => vehicle.Shipper)
                .WithMany(shippers => shippers.Vehicles)
                .HasForeignKey(vehicle => vehicle.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity
                .HasOne(employee => employee.Role)
                .WithMany(role => role.Employees)
                .HasForeignKey(employee => employee.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(emp => emp.Shipper)
                .WithMany(ship => ship.Employees)
                .HasForeignKey(emp => emp.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity
                .HasOne(doc => doc.DocumentType)
                .WithMany(doctype => doctype.Documents)
                .HasForeignKey(doc => doc.TypeID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(doc => doc.Shipper)
                .WithMany(shipper => shipper.Documents)
                .HasForeignKey(doc => doc.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity
                .HasOne(reservation => reservation.Customer)
                .WithMany(customer => customer.Reservations)
                .HasForeignKey(reservation => reservation.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(reservation => reservation.Shipper)
                .WithMany(shipper => shipper.Reservations)
                .HasForeignKey(reservation => reservation.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(reservation => reservation.PackagingOption)
                .WithMany(packOption => packOption.Reservations)
                .HasForeignKey(reservation => reservation.PackagingOptionID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(reservation => reservation.Driver)
                .WithMany(employee => employee.ReservationDriver)
                .HasForeignKey(reservation => reservation.DriverID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(reservation => reservation.ReservationStatus)
                .WithMany(reserStatus => reserStatus.Reservations)
                .HasForeignKey(reservation => reservation.StatusID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Points>(entity =>
            {
                entity
                .HasOne(points => points.Shipper)
                .WithMany(shipper => shipper.Points)
                .HasForeignKey(points => points.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(point => point.Customer)
                .WithMany(customer => customer.Points)
                .HasForeignKey(point => point.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(point => point.Reservation)
                .WithOne(reservation => reservation.Point)
                .HasForeignKey<Points>(point => point.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity
                .HasOne(comments => comments.Shipper)
                .WithMany(shipper => shipper.Comments)
                .HasForeignKey(comments => comments.ShipperID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(comments => comments.Customer)
                .WithMany(customer => customer.Comments)
                .HasForeignKey(comments => comments.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(comments => comments.Reservation)
                .WithOne(reservation => reservation.Comment)
                .HasForeignKey<Comments>(comments => comments.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ToAddresses>(entity =>
            {
                entity
                .HasOne(toAddress => toAddress.RoomCount)
                .WithMany(roomCount => roomCount.ToAddresses)
                .HasForeignKey(toAddress => toAddress.RoomCountID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(toAddress => toAddress.Reservation)
                .WithOne(reservation => reservation.ToAddress)
                .HasForeignKey<ToAddresses>(toAdress => toAdress.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FromAddresses>(entity =>
            {
                entity
                .HasOne(fromAddress => fromAddress.RoomCount)
                .WithMany(roomCount => roomCount.FromAddresses)
                .HasForeignKey(fromAddress => fromAddress.RoomCountID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(fromAddress => fromAddress.Reservation)
                .WithOne(reservation => reservation.FromAddress)
                .HasForeignKey<FromAddresses>(fromAddress => fromAddress.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            seedData(modelBuilder);
        }

        void seedData(ModelBuilder modelBuilder)
        {
            var shippers = new List<Shippers>
            {
                new Shippers{ ID = 1, Address = "Test Nakliyeci Adres 1", CreatedDate = DateTime.Now, FoundingDate = new DateTime(2011,01,01), Name = "Test Nakliyeci Adı 1", Phone = "05363403660", Status = true, TaxAuthority = "Samandıra", TaxNumber = "124124123" },
                new Shippers{ ID = 2, Address = "Test Nakliyeci Adres 2", CreatedDate = DateTime.Now, FoundingDate = new DateTime(2012,02,02), Name = "Test Nakliyeci Adı 2", Phone = "05322322525", Status = false }
            };
            modelBuilder.Entity<Shippers>().HasData(shippers);

            var vehicleTypes = new List<VehicleTypes>
            {
                new VehicleTypes{ ID = 1, TypeName = "Kapalı Kasa" },
                new VehicleTypes{ ID = 2, TypeName = "Açık Kasa" }
            };
            modelBuilder.Entity<VehicleTypes>().HasData(vehicleTypes);

            var roles = new List<Roles>
            {
                new Roles{ ID = 1, Name = "Yönetici" },
                new Roles{ ID = 2, Name = "Sürücü" },
                new Roles{ ID = 3, Name = "Çalışan" }
            };
            modelBuilder.Entity<Roles>().HasData(roles);

            var documentTypes = new List<DocumentTypes>
            {
                new DocumentTypes{ ID = 1, TypeName = "İmza Sürküsü" },
                new DocumentTypes{ ID = 2, TypeName = "Vergi Levhası" }
            };
            modelBuilder.Entity<DocumentTypes>().HasData(documentTypes);

            var roomCount = new List<RoomCount>
            {
                new RoomCount{ ID = 1, BasePrice = 400, Count = "1+1" },
                new RoomCount{ ID = 2, BasePrice = 500, Count = "2+1" }
            };
            modelBuilder.Entity<RoomCount>().HasData(roomCount);

            var reservationStatus = new List<ReservationStatus>
            {
                new ReservationStatus{ ID = 1, StatusName = "Onay Bekliyor" },
                new ReservationStatus{ ID = 2, StatusName = "Onaylandı" },
                new ReservationStatus{ ID = 3, StatusName = "Taşıma Durumunda"},
                new ReservationStatus{ ID = 4, StatusName = "Tamamlandı" }
            };
            modelBuilder.Entity<ReservationStatus>().HasData(reservationStatus);

            var packagingOptions = new List<PackagingOptions>
            {
                new PackagingOptions{ ID = 1, OptionFactor = 1.7, OptionName = "Bütün Eşyalar" },
                new PackagingOptions{ ID = 2, OptionFactor = 1.3, OptionName = "Sadece Beyaz Eşyalar" },
                new PackagingOptions{ ID = 3, OptionFactor = 0, OptionName = "Kendim Paketleyeceğim" }
            };
            modelBuilder.Entity<PackagingOptions>().HasData(packagingOptions);

            var vehicles = new List<Vehicles>
            {
                new Vehicles{ ID = 1, Height = 250, Weight = 200, LicensePlate = "06MNF20", ShipperID = 1, TypeID = 1 },
                new Vehicles{ ID = 2, Height = 180, Weight = 130, LicensePlate = "34GH7218", ShipperID = 1, TypeID = 2 },
                new Vehicles{ ID = 3, Height = 180, Weight = 130, LicensePlate = "34CRK350", ShipperID = 2, TypeID = 2 }
            };
            modelBuilder.Entity<Vehicles>().HasData(vehicles);

            var employees = new List<Employees>
            {
                new Employees{ ID = 1, Name = "Çalışan 1", Surname = "Çalışan 1 Soyad", Phone = "05363403660", RoleID = 3, ShipperID = 1 },
                new Employees{ ID = 2, Name = "Yönetici", Surname = "Yönetici Soyad", Phone = "05353563535", RoleID = 1, ShipperID = 1, Email = "test@gmail.com" },
                new Employees{ ID = 3, Name = "Sürücü 1", Surname = "Sürücü 1 Soyad", Phone = "05363403660", RoleID = 2, ShipperID = 1 },
                new Employees{ ID = 4, Name = "Çalışan 2", Surname = "Çalışan 2 Soyad", Phone = "05363403660", RoleID = 3, ShipperID = 1 },
                new Employees{ ID = 5, Name = "Yönetici 2. Nakliyeci", Surname = "Yönetici Soyad", Phone = "05363403660", RoleID = 1, ShipperID = 2 }
            };
            modelBuilder.Entity<Employees>().HasData(employees);

            var documents = new List<Documents>
            {
                new Documents{ ID = 1, Name = "İmza Sürküsü - 1", ShipperID = 1, TypeID = 1 },
                new Documents{ ID = 2, Name = "Vergi Levhası - 1", ShipperID = 1, TypeID = 2 },
                new Documents{ ID = 3, Name = "Vergi Levhası", ShipperID = 2, TypeID = 2 },
            };
            modelBuilder.Entity<Documents>().HasData(documents);

            var customer = new List<Customer>
            {
                new Customer{ ID = 1, Name = "Fatih", Surname = "Balcıoğlu", Phone = "05322716155" },
                new Customer{ ID = 2, Name = "Yunus", Surname = "Gülbeyen", Phone = "05321111111" }
            };
            modelBuilder.Entity<Customer>().HasData(customer);

            var reservations = new List<Reservations>
            {
                new Reservations{ ID = 1, CustomerID = 1, ShipperID = 1, PriceToCustomer = 2200, PriceToShipper = 1900, ReservationDate = new DateTime(2020,1,20),
                    CreatedDate = new DateTime(2020,1,1), TransportDate = new DateTime(2020,1,20), Montage = true, PackagingOptionID = 1, DriverID = 3, StatusID = 4 },
                new Reservations{ ID = 2, CustomerID = 2, ShipperID = 1, PriceToCustomer = 1700, PriceToShipper = 1500, ReservationDate = new DateTime(2020,10,30),
                    CreatedDate = new DateTime(2020,10,15), Montage = false, PackagingOptionID = 1, DriverID = 3, StatusID = 4 }
            };
            modelBuilder.Entity<Reservations>().HasData(reservations);

            var points = new List<Points>
            {
                new Points{ ID = 1, ShipperID = 1, CustomerID = 1, ReservationID = 1, PointDate = new DateTime(2020,01,21), Time = 9, Contentment = 8, Cominication = 5}
            };
            modelBuilder.Entity<Points>().HasData(points);

            var comments = new List<Comments>
            {
                new Comments{ ID = 1, ShipperID = 1, CustomerID = 1, ReservationID = 1, CommentDate = new DateTime(2020,01,21), Check = true,
                    Comment = "Hasarsız taşındı eşyalarım fakat iletişim zayıf" }
            };
            modelBuilder.Entity<Comments>().HasData(comments);

            var fromAddresses = new List<FromAddresses>
            {
                new FromAddresses{ ID = 1, Elevator = false, Floor = 3, RoomCountID = 2, ReservationID = 1, City = "Istanbul", District = "Sancaktepe", State = "Osmangazi" },
                new FromAddresses{ ID = 2, Elevator = true, Floor = 2, RoomCountID = 2, ReservationID = 2, City = "Istanbul", District = "Pendik", State = "Kurtköy" }
            };
            modelBuilder.Entity<FromAddresses>().HasData(fromAddresses);

            var toAddresses = new List<ToAddresses>
            {
                new ToAddresses{ ID = 1, Elevator = true, Floor = 3, RoomCountID = 2, ReservationID = 1, City = "Istanbul", District = "Maltepe", State = "Altayçeşme" },
                new ToAddresses{ ID = 2, Elevator = true, Floor = 1, RoomCountID = 1, ReservationID = 2, City = "Istanbul", District = "Üsküdar", State = "Kısıklı" }
            };
            modelBuilder.Entity<ToAddresses>().HasData(toAddresses);

            var factor = new Factors
            {
                ID = 1,
                RoomCountFactor = 120,
                FloorFactor = 100,
                MontageFactor = 150,
                WayDiff = 3
            };
            modelBuilder.Entity<Factors>().HasData(factor);
        }
    }
}
