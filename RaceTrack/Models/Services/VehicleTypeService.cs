using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    public class VehicleTypeService
    {
        private readonly RaceTrackContext _context;
        public VehicleTypeService(RaceTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleType>> GetAllAsync()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        public async Task<VehicleType> GetByIdAsync(int? vehicleTypeId)
        {
            return await _context.VehicleTypes
                .FirstOrDefaultAsync(m => m.Id == vehicleTypeId);
        }

        public async Task AddAsync(VehicleType vehicleType)
        {
            try
            {
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        public async Task UpdateAsync(VehicleType vehicleType)
        {
            try
            {
                _context.Update(vehicleType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

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
