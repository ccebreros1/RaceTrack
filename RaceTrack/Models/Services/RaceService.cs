using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    public class RaceService
    {
        private readonly RaceTrackContext _context;
        public RaceService(RaceTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Race>> GetAllAsync()
        {
            var raceTrackContext = _context.Races.Include(r => r.RaceTrack);
            return await raceTrackContext.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int? raceId)
        {
            var race = await _context.Races
                .Include(r => r.RaceTrack)
                .FirstOrDefaultAsync(m => m.Id == raceId);
            return race;
        }

        public async Task AddAsync(Race race)
        {
            try
            {
                _context.Add(race);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        public async Task UpdateAsync(Race race)
        {
            try
            {
                _context.Update(race);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

        public async Task DeleteAsync(int raceId)
        {
            try
            {
                var race = await _context.Races.FindAsync(raceId);
                _context.Races.Remove(race);
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
