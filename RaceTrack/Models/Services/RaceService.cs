using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    /// <summary>
    /// this is the main service for the race module
    /// </summary>
    /// <remarks>
    /// Thew service serves as a business logic layer for the application. Business rules, and db operations are handled here.
    /// </remarks>
    public class RaceService
    {
        private readonly RaceTrackContext _context;
        public RaceService(RaceTrackContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all of the Races from the database
        /// </summary>
        /// <returns>
        /// A list of Race Tracks
        /// </returns>
        public async Task<IEnumerable<Race>> GetAllAsync()
        {
            var raceTrackContext = _context.Races.Include(r => r.RaceTrack);
            return await raceTrackContext.ToListAsync();
        }

        /// <summary>
        /// Gets a Race by Id
        /// </summary>
        /// <returns>
        /// A specific Race Track
        /// </returns>
        /// <param name="raceId">The Id of the Race we want to find</param>
        public async Task<Race> GetByIdAsync(int? raceId)
        {
            var race = await _context.Races
                .Include(r => r.RaceTrack)
                .FirstOrDefaultAsync(m => m.Id == raceId);
            return race;
        }

        /// <summary>
        /// Adds the record to the database
        /// </summary>
        /// <param name="race">A Race model</param>
        public async Task AddAsync(Race race)
        {
            try
            {
                await _context.AddAsync(race);
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
        /// <param name="race">A Race model to be modified</param>
        public async Task UpdateAsync(Race race)
        {
            try
            {
                var e = _context.Update(race);
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
        /// <param name="raceId">The Id of the Race to be deleted</param>
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
