using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    /// <summary>
    /// this is the main service for the vehicle type module
    /// </summary>
    /// <remarks>
    /// Thew service serves as a business logic layer for the application. Business rules, and db operations are handled here.
    /// </remarks>
    public class VehicleTypeService
    {
        private readonly RaceTrackContext _context;
        public VehicleTypeService(RaceTrackContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all of the vehicle types from the database
        /// </summary>
        /// <returns>
        /// A list of vehicle types
        /// </returns>
        public async Task<IEnumerable<VehicleType>> GetAllAsync()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        /// <summary>
        /// Gets a Vehicle Type by Id
        /// </summary>
        /// <returns>
        /// A specific Vehicle Type
        /// </returns>
        /// <param name="vehicleTypeId">The Id of the vehicle type we want to find</param>
        public async Task<VehicleType> GetByIdAsync(int? vehicleTypeId)
        {
            return await _context.VehicleTypes
                .FirstOrDefaultAsync(m => m.Id == vehicleTypeId);
        }

        /// <summary>
        /// Adds the record to the database
        /// </summary>
        /// <param name="vehicleType">A Vehicle Type model</param>
        public async Task AddAsync(VehicleType vehicleType)
        {
            try
            {
                await _context.AddAsync(vehicleType);
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
        /// <param name="vehicleType">A Vehicle Type model to be modified</param>
        public async Task UpdateAsync(VehicleType vehicleType)
        {
            try
            {
                var e = _context.Update(vehicleType);
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
        /// <param name="vehicleTypeId">The Id of the vehicle type to be deleted</param>
        public async Task DeleteAsync(int vehicleTypeId)
        {
            try
            {
                var vehicleType = await _context.VehicleTypes.FindAsync(vehicleTypeId);
                _context.VehicleTypes.Remove(vehicleType);
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
