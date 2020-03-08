using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    public class RaceVehicleService
    {
        private readonly RaceTrackContext _context;
        public RaceVehicleService(RaceTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceVehicle>> GetAllAsync()
        {
            var raceTrackContext = _context.RaceVehicles.Include(r => r.Race).Include(r => r.Vehicle);
            return await raceTrackContext.ToListAsync();
        }

        public async Task<RaceVehicle> GetByIdAsync(int? raceVehicleId)
        {
            var raceVehicle = await _context.RaceVehicles
                .Include(r => r.Race)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == raceVehicleId);

            return raceVehicle;
        }

        public async Task AddAsync(RaceVehicle raceVehicle)
        {
            try
            {
               
                _context.Add(raceVehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        public async Task UpdateAsync(RaceVehicle raceVehicle)
        {
            try
            {
                _context.Update(raceVehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

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
    }
}
