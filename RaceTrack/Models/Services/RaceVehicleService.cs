using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    /// <summary>
    /// this is the main service for the race vehicle module
    /// </summary>
    /// <remarks>
    /// Thew service serves as a business logic layer for the application. Business rules, and db operations are handled here.
    /// </remarks>
    public class RaceVehicleService
    {
        private readonly RaceTrackContext _context;
        public RaceVehicleService(RaceTrackContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all of the Race Vehicles from the database
        /// </summary>
        /// <returns>
        /// A list of Race Vehicles
        /// </returns>
        public async Task<IEnumerable<RaceVehicle>> GetAllAsync()
        {
            var raceTrackContext = _context.RaceVehicles.Include(r => r.Race).Include(r => r.Vehicle);
            return await raceTrackContext.ToListAsync();
        }

        /// <summary>
        /// Gets a Race Vehicle by Id
        /// </summary>
        /// <returns>
        /// A specific Race Vehicle
        /// </returns>
        /// <param name="raceVehicleId">The Id of the Race Vehicle we want to find</param>
        public async Task<RaceVehicle> GetByIdAsync(int? raceVehicleId)
        {
            var raceVehicle = await _context.RaceVehicles
                .Include(r => r.Race)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == raceVehicleId);

            return raceVehicle;
        }


        /// <summary>
        /// Adds the record to the database
        /// </summary>
        /// <param name="raceVehicle">A Race Vehicle model</param>
        public async Task AddAsync(RaceVehicle raceVehicle)
        {
            try
            {
                await ValidateVehicle(raceVehicle);
                await _context.AddAsync(raceVehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        /// <summary>
        /// Updates a record from the database
        /// </summary>
        /// <param name="raceVehicle">A Race Vehicle model to be modified</param>
        public async Task UpdateAsync(RaceVehicle raceVehicle)
        {
            try
            {
                await ValidateVehicle(raceVehicle, "update");
                var e = _context.Update(raceVehicle);
                e.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="raceVehicleId">The Id of the Race Vehicle to be deleted</param>
        public async Task DeleteAsync(int raceVehicleId)
        {
            try
            {
                var raceVehicleInfo = await _context.RaceVehicles.FindAsync(raceVehicleId);
                _context.RaceVehicles.Remove(raceVehicleInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        /// <summary>
        /// Processes custom business rules for adding a vehicle to a race
        /// </summary>
        /// <exception cref="Exception ex">Custom exception message that is used for validation feedback</exception>
        /// <param name="raceVehicle">The model of the record being handled</param>
        /// <param name="action">The action being made on the record to decide what to validate</param>
        internal async Task ValidateVehicle(RaceVehicle raceVehicle, string action = "add")
        {
            if(action == "add")
            {
                // Check if car is not already in race
                var duplicateRecord = await _context.RaceVehicles.Where(r => r.VehicleId == raceVehicle.VehicleId && r.RaceId == raceVehicle.RaceId).FirstOrDefaultAsync();

                if (duplicateRecord != null)
                {
                    throw new Exception("This vehicle is already present on this race");
                }
            }
            
            // Get all vehicles currently in the race
            var vehiclesInRace = await _context.RaceVehicles.Where(r => r.RaceId == raceVehicle.RaceId).ToListAsync();

            // Check for the count of vehicles, if we already have 5 for that race do not add the new one

            if (vehiclesInRace.Count == 5)
            {
                throw new Exception("Can't add more than 5 vehicles to a race");
            }

            // Check inspection of vehicle with following criteria:
            // Truck Inspections:
            // Tow strap on the vehicle
            // Not lifted more than 5 inches

            // Car Inspections:
            // Tow strap on the vehicle
            // Less than 85 % tire wear

            var vehicleInfo = await _context.Vehicles.Include(v => v.VehicleType).Where(x => x.Id == raceVehicle.VehicleId).FirstOrDefaultAsync();
            var vehicleType = vehicleInfo.VehicleType.Description;

            if (vehicleType == "Truck")
            {
                if (!raceVehicle.HasTowStrap || !raceVehicle.AcceptableLift)
                {
                    throw new Exception("A truck needs to have a tow strap and cannot be lifted more than 5 inches to participate in the race");
                }
            }
            else
            {
                if (!raceVehicle.HasTowStrap || !raceVehicle.AcceptableTireWear)
                {
                    throw new Exception("A car needs to have a tow strap and cannot have less than 85% of tire wear to participate in the race");
                }
            }
        }
    }
}
