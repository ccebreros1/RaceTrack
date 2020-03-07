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
    public class RaceVehiclesController : Controller
    {
        private readonly RaceTrackContext _context;

        public RaceVehiclesController(RaceTrackContext context)
        {
            _context = context;
        }

        // GET: RaceVehicles
        public async Task<IActionResult> Index()
        {
            var raceTrackContext = _context.RaceVehicles.Include(r => r.Race).Include(r => r.Vehicle);
            return View(await raceTrackContext.ToListAsync());
        }

        // GET: RaceVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceVehicle = await _context.RaceVehicles
                .Include(r => r.Race)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceVehicle == null)
            {
                return NotFound();
            }

            return View(raceVehicle);
        }

        // GET: RaceVehicles/Create
        public IActionResult Create()
        {
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Name", "Select Race");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "VehicleAlias", "Select Vehicle");
            return View();
        }

        // POST: RaceVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RaceId,VehicleId,HasTowStrap,AcceptableTireWear,AcceptableLift")] RaceVehicle raceVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Name", raceVehicle.RaceId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "VehicleAlias", raceVehicle.VehicleId);
            return View(raceVehicle);
        }

        // GET: RaceVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceVehicle = await _context.RaceVehicles.FindAsync(id);
            if (raceVehicle == null)
            {
                return NotFound();
            }
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Name", raceVehicle.RaceId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "VehicleAlias", raceVehicle.VehicleId);
            return View(raceVehicle);
        }

        // POST: RaceVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RaceId,VehicleId,HasTowStrap,AcceptableTireWear,AcceptableLift")] RaceVehicle raceVehicle)
        {
            if (id != raceVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceVehicleExists(raceVehicle.Id))
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
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Name", raceVehicle.RaceId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "VehicleAlias", raceVehicle.VehicleId);
            return View(raceVehicle);
        }

        // GET: RaceVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceVehicle = await _context.RaceVehicles
                .Include(r => r.Race)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceVehicle == null)
            {
                return NotFound();
            }

            return View(raceVehicle);
        }

        // POST: RaceVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceVehicle = await _context.RaceVehicles.FindAsync(id);
            _context.RaceVehicles.Remove(raceVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetTable(int? raceId = null)
        {
            var raceTrackContext = _context.RaceVehicles.Include(r => r.Race).Include(r => r.Vehicle);
            var raceVehicles = await raceTrackContext.ToListAsync();
            if(raceId != null)
            {
                raceVehicles = raceVehicles.Where(x => x.RaceId == raceId).ToList();
            }
            return PartialView("_RaceInfoTable", raceVehicles);
        }

        private bool RaceVehicleExists(int id)
        {
            return _context.RaceVehicles.Any(e => e.Id == id);
        }
    }
}
