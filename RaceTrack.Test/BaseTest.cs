using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RaceTrack.Data;
using RaceTrack.Models;
using RaceTrack.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RaceTrack.Test
{
    public class BaseTest
    {
        public RaceTrackContext _context;
        //public Mock<DbSet<VehicleType>> _vehicleTypeSet;
        //public Mock<DbSet<RaceTrackInfo>> _raceTrackInfoSet;
        //public Mock<DbSet<Vehicle>> _vehicleSet;
        //public Mock<DbSet<Race>> _raceSet;
        //public Mock<DbSet<RaceVehicle>> _raceVehicleSet;
       

        [SetUp]
        public virtual void Setup()
        {
            var options = new DbContextOptionsBuilder<RaceTrackContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RaceTrackContext(options);

            var raceTrackInfoData = new List<RaceTrackInfo>
            {
                new RaceTrackInfo { Id = 1, Name = "Test1" },
                new RaceTrackInfo { Id = 2, Name = "Test2" },
                new RaceTrackInfo { Id = 3, Name = "Test3" },
            };

            _context.AddRange(raceTrackInfoData);
            _context.SaveChanges();

            var raceData = new List<Race>
            {
                new Race {Id = 1, Name = "Test1", Date = DateTime.Now, RaceTrackId = 1},
                new Race {Id = 2, Name = "Test2", Date = DateTime.Now, RaceTrackId = 2},
                new Race {Id = 3, Name = "Test3", Date = DateTime.Now, RaceTrackId = 1},
                new Race {Id = 4, Name = "Test4", Date = DateTime.Now, RaceTrackId = 3}
            };

            _context.AddRange(raceData);
            _context.SaveChanges();

            var vehicleTypeData = new List<VehicleType>
            {
                new VehicleType {Id = 1, Description = "Truck"},
                new VehicleType { Id = 2, Description = "Car" }
            };

            _context.AddRange(vehicleTypeData);
            _context.SaveChanges();

            var vehicleData = new List<Vehicle>
            {
                new Vehicle { Id = 1, VehicleTypeId = 1, Make = "Ford", Model = "F-150", OwnerName = "Test1", VehicleAlias = "Test1" },
                new Vehicle { Id = 2, VehicleTypeId = 1, Make = "Ford", Model = "Ranger", OwnerName = "Test2", VehicleAlias = "Test2" },
                new Vehicle { Id = 3, VehicleTypeId = 2, Make = "Ford", Model = "Mustang", OwnerName = "Test3", VehicleAlias = "Test3" },
                new Vehicle { Id = 4, VehicleTypeId = 2, Make = "Ford", Model = "Fiesta", OwnerName = "Test4", VehicleAlias = "Test4" },
                new Vehicle { Id = 5, VehicleTypeId = 2, Make = "Ford", Model = "Focus", OwnerName = "Test6", VehicleAlias = "Test5" },
                new Vehicle { Id = 6, VehicleTypeId = 1, Make = "Ford", Model = "Bronco", OwnerName = "Test1", VehicleAlias = "Test6" },
            };

            _context.AddRange(vehicleData);
            _context.SaveChanges();

            var raceVehicleData = new List<RaceVehicle>
            {
                new RaceVehicle { RaceId = 1, VehicleId = 1, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
                new RaceVehicle { RaceId = 1, VehicleId = 2, AcceptableLift = false, AcceptableTireWear = true, HasTowStrap = true },
                new RaceVehicle { RaceId = 1, VehicleId = 3, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
                new RaceVehicle { RaceId = 1, VehicleId = 4, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
                new RaceVehicle { RaceId = 1, VehicleId = 5, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
                new RaceVehicle { RaceId = 2, VehicleId = 1, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
                new RaceVehicle { RaceId = 2, VehicleId = 6, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true },
            };

            _context.AddRange(raceVehicleData);
            _context.SaveChanges();
        }
    }
}
