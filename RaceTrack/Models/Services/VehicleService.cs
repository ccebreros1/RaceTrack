using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    public class VehicleService
    {
        private readonly RaceTrackContext _context;
        public VehicleService(RaceTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var raceTrackContext = _context.Vehicles.Include(v => v.VehicleType);
            return await raceTrackContext.ToListAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int? vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == vehicleId);
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            try
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            try
            {
                _context.Update(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

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
