using NUnit.Framework;
using RaceTrack.Models;
using RaceTrack.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Test
{
    public class RaceVehicleTests : BaseTest
    {
        public RaceVehicleService _service;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _service = new RaceVehicleService(_context);
        }

        [Test]
        public async Task RaceVehicle_Add_Success()
        {
            var raceVehicle = new RaceVehicle { RaceId = 2, VehicleId = 2, AcceptableLift = true, AcceptableTireWear = false, HasTowStrap = true };
            await _service.AddAsync(raceVehicle);

            Assert.IsTrue((await _service.GetAllAsync()).Where(x => x.RaceId == raceVehicle.RaceId && x.VehicleId == raceVehicle.VehicleId).FirstOrDefault() != null);
        }

        [Test]
        public void RaceVehicle_Add_Fail_MoreThanFiveVehicles()
        {
            var raceVehicle = new RaceVehicle
            {
                RaceId = 1,
                VehicleId = 6,
                AcceptableLift = true,
                AcceptableTireWear = false,
                HasTowStrap = true
            };
            var ex = Assert.ThrowsAsync<Exception>(async () => await _service.AddAsync(raceVehicle));
            Assert.That(ex.Message, Is.EqualTo("Can't add more than 5 vehicles to a race"));
        }

        [Test]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        public void RaceVehicle_Add_Fail_TruckNoPassInspection(bool acceptableLift, bool acceptableTireWear, bool hasTowStrap)
        {
            var raceVehicle = new RaceVehicle
            {
                RaceId = 2,
                VehicleId = 2,
                AcceptableLift = acceptableLift,
                AcceptableTireWear = acceptableTireWear,
                HasTowStrap = hasTowStrap
            };
            var ex = Assert.ThrowsAsync<Exception>(async () => await _service.AddAsync(raceVehicle));
            Assert.That(ex.Message, Is.EqualTo("A truck needs to have a tow strap and cannot be lifted more than 5 inches to participate in the race"));
        }

        [Test]
        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        public void RaceVehicle_Add_Fail_CarNoPassInspection(bool acceptableLift, bool acceptableTireWear, bool hasTowStrap)
        {
            var raceVehicle = new RaceVehicle
            {
                RaceId = 2,
                VehicleId = 3,
                AcceptableLift = acceptableLift,
                AcceptableTireWear = acceptableTireWear,
                HasTowStrap = hasTowStrap
            };
            var ex = Assert.ThrowsAsync<Exception>(async () => await _service.AddAsync(raceVehicle));
            Assert.That(ex.Message, Is.EqualTo("A car needs to have a tow strap and cannot have less than 85% of tire wear to participate in the race"));
        }

        [Test]
        public async Task RaceVehicle_GetAll_Success()
        {
            var allRaceVehicles = await _service.GetAllAsync();
            Assert.AreEqual(7, allRaceVehicles.Count());
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task RaceVehicle_GetByRaceId_Success(int? raceId)
        {
            var allRaceVehicles = await _service.GetAllAsync();
            var count = allRaceVehicles.Where(x => x.RaceId == raceId).Count();
            Assert.AreNotEqual(count, allRaceVehicles.Count());
        }
    }
}