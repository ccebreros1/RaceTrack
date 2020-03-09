using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    /// <summary>
    /// this is the main service for the vehicle module
    /// </summary>
    /// <remarks>
    /// Thew service serves as a business logic layer for the application. Business rules, and db operations are handled here.
    /// </remarks>
    public class VehicleService
    {
        private readonly RaceTrackContext _context;
        public VehicleService(RaceTrackContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all of the vehicles from the database
        /// </summary>
        /// <returns>
        /// A list of vehicles
        /// </returns>
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var raceTrackContext = _context.Vehicles.Include(v => v.VehicleType);
            return await raceTrackContext.ToListAsync();
        }


        /// <summary>
        /// Gets a Vehicle by Id
        /// </summary>
        /// <returns>
        /// A specific Vehicle
        /// </returns>
        /// <param name="vehicleId">The Id of the vehicle we want to find</param>
        public async Task<Vehicle> GetByIdAsync(int? vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == vehicleId);
        }

        /// <summary>
        /// Adds the record to the database
        /// </summary>
        /// <param name="vehicle">A Vehicle model</param>
        public async Task AddAsync(Vehicle vehicle)
        {
            try
            {
                if(string.IsNullOrEmpty(vehicle.VehicleAlias))
                {
                    vehicle.VehicleAlias = vehicle.OwnerName + "'s " + vehicle.Make + " " + vehicle.Model;
                }
                await _context.AddAsync(vehicle);
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
        /// <param name="vehicle">A Vehicle model to be modified</param>
        public async Task UpdateAsync(Vehicle vehicle)
        {
            try
            {
                if (string.IsNullOrEmpty(vehicle.VehicleAlias))
                {
                    vehicle.VehicleAlias = vehicle.OwnerName + "'s " + vehicle.Make + " " + vehicle.Model;
                }
                var e = _context.Update(vehicle);
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
        /// <param name="vehicleId">The Id of the vehicle to be deleted</param>
        public async Task DeleteAsync(int vehicleId)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(vehicleId);
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }
    }
}
