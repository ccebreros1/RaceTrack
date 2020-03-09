using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    /// <summary>
    /// this is the main service for the race track module
    /// </summary>
    /// <remarks>
    /// Thew service serves as a business logic layer for the application. Business rules, and db operations are handled here.
    /// </remarks>
    public class RaceTrackInfoService
    {
        private readonly RaceTrackContext _context;
        public RaceTrackInfoService(RaceTrackContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all of the Race Tracks from the database
        /// </summary>
        /// <returns>
        /// A list of Race Tracks
        /// </returns>
        public async Task<IEnumerable<RaceTrackInfo>> GetAllAsync()
        {
            return await _context.RaceTracksInfo.ToListAsync();
        }

        /// <summary>
        /// Gets a Race Track by Id
        /// </summary>
        /// <returns>
        /// A specific Race Track
        /// </returns>
        /// <param name="raceTrackInfoId">The Id of the Race Track we want to find</param>
        public async Task<RaceTrackInfo> GetByIdAsync(int? raceTrackInfoId)
        {
            var raceTrackInfo = await _context.RaceTracksInfo
                .FirstOrDefaultAsync(m => m.Id == raceTrackInfoId);
            return raceTrackInfo;
        }

        /// <summary>
        /// Adds the record to the database
        /// </summary>
        /// <param name="raceTrackInfo">A Race Track model</param>
        public async Task AddAsync(RaceTrackInfo raceTrackInfo)
        {
            try
            {
                await _context.AddAsync(raceTrackInfo);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }            
        }

        /// <summary>
        /// Updates a record from the database
        /// </summary>
        /// <param name="raceTrackInfo">A Race Track model to be modified</param>
        public async Task UpdateAsync(RaceTrackInfo raceTrackInfo)
        {
            try
            {
                var e = _context.Update(raceTrackInfo);
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
        /// <param name="raceTrackInfoId">The Id of the Race Track to be deleted</param>
        public async Task DeleteAsync(int raceTrackInfoId)
        {
            try
            {
                var raceTrackInfo = await _context.RaceTracksInfo.FindAsync(raceTrackInfoId);
                _context.RaceTracksInfo.Remove(raceTrackInfo);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }
    }
}
