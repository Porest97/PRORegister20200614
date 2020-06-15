using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRORegister.DAIF2020.Models.DataModels;
using PRORegister.DAIF2020.Models.ViewModels;
using PRORegister.Data;

namespace PRORegister.DAIF2020.Controllers
{
    [Authorize]
    public class DAIF2020Controller : Controller
    {
        // GET: DAIF2020Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: DAIF2020Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DAIF2020Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DAIF2020Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DAIF2020Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DAIF2020Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DAIF2020Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DAIF2020Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}



    public class ArenasController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public ArenasController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: Arenas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Arena
                .Include(a => a.ArenaStatus)
                .Include(a => a.District);
            return View(await applicationDbContext.ToListAsync());
        }

    // GET: Arenas with ArenaName search !
    public async Task<IActionResult> IndexSearch(string searchString)
    {
        var arenas = from a in _context.Arena
             .Include(a => a.ArenaStatus)
                .Include(a => a.District)

                     select a;

        if (!String.IsNullOrEmpty(searchString))
        {
            arenas = arenas
             .Include(a => a.ArenaStatus)
             .Include(a => a.District)
            .Where(a => a.ArenaName.Contains(searchString));

        }
        return View(await arenas.ToListAsync());
    }


    public IActionResult ListArenas()
        {


            var dataViewModel = new DataViewModel()
            {
                Arenas = _context.Arena
                       .Include(a => a.District)
                       .Include(a => a.ArenaStatus).ToList()
            };
            return View(dataViewModel);
        }

        // GET: Arenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .Include(a => a.ArenaStatus)
                .Include(a => a.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // GET: Arenas/Create
        public IActionResult Create()
        {
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "StatusName");
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName");
            return View();
        }

        // POST: Arenas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArenaNumber,ArenaName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaStatusId")] Arena arena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListArenas));
            }
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "StatusName", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", arena.DistrictId);
            return View(arena);
        }

        // GET: Arenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena.FindAsync(id);
            if (arena == null)
            {
                return NotFound();
            }
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "StatusName", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", arena.DistrictId);
            return View(arena);
        }

        // POST: Arenas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArenaNumber,ArenaName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaStatusId")] Arena arena)
        {
            if (id != arena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArenaExists(arena.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListArenas));
            }
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "StatusName", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", arena.DistrictId);
            return View(arena);
        }

        // GET: Arenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .Include(a => a.ArenaStatus)
                .Include(a => a.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // POST: Arenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arena = await _context.Arena.FindAsync(id);
            _context.Arena.Remove(arena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListArenas));
        }

        private bool ArenaExists(int id)
        {
            return _context.Arena.Any(e => e.Id == id);
        }
    }

