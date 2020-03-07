using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaceTrack.Data;
using RaceTrack.Models;

namespace RaceTrack.Controllers
{
    public class RaceTracksInfoController : Controller
    {
        private readonly RaceTrackContext _context;

        public RaceTracksInfoController(RaceTrackContext context)
        {
            _context = context;
        }

        // GET: RaceTrackInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceTracksInfo.ToListAsync());
        }

        // GET: RaceTrackInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTrackInfo = await _context.RaceTracksInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceTrackInfo == null)
            {
                return NotFound();
            }

            return View(raceTrackInfo);
        }

        // GET: RaceTrackInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceTrackInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RaceTrackInfo raceTrackInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceTrackInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceTrackInfo);
        }

        // GET: RaceTrackInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTrackInfo = await _context.RaceTracksInfo.FindAsync(id);
            if (raceTrackInfo == null)
            {
                return NotFound();
            }
            return View(raceTrackInfo);
        }

        // POST: RaceTrackInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RaceTrackInfo raceTrackInfo)
        {
            if (id != raceTrackInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceTrackInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceTrackInfoExists(raceTrackInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(raceTrackInfo);
        }

        // GET: RaceTrackInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceTrackInfo = await _context.RaceTracksInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceTrackInfo == null)
            {
                return NotFound();
            }

            return View(raceTrackInfo);
        }

        // POST: RaceTrackInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceTrackInfo = await _context.RaceTracksInfo.FindAsync(id);
            _context.RaceTracksInfo.Remove(raceTrackInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceTrackInfoExists(int id)
        {
            return _context.RaceTracksInfo.Any(e => e.Id == id);
        }
    }
}
