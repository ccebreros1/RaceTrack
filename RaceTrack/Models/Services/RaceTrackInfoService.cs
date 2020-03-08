using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceTrack.Service
{
    public class RaceTrackInfoService
    {
        private readonly RaceTrackContext _context;
        public RaceTrackInfoService(RaceTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceTrackInfo>> GetAllAsync()
        {
            return await _context.RaceTracksInfo.ToListAsync();
        }

        public async Task<RaceTrackInfo> GetByIdAsync(int? raceTrackInfoId)
        {
            var raceTrackInfo = await _context.RaceTracksInfo
                .FirstOrDefaultAsync(m => m.Id == raceTrackInfoId);
            return raceTrackInfo;
        }

        public async Task AddAsync(RaceTrackInfo raceTrackInfo)
        {
            try
            {
                _context.Add(raceTrackInfo);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }            
        }

        public async Task UpdateAsync(RaceTrackInfo raceTrackInfo)
        {
            try
            {
                _context.Update(raceTrackInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                // In here we would log the exception and return an error message to the user
            }
        }

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
