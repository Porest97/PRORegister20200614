using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRORegister.DAIF2020.Models.DataModels;
using PRORegister.Data;
using PRORegister.PROLifeLog.Models.DataModels;
using PRORegister.PRONBS.Models.DataModels;

namespace PRORegister.PROLifeLog.Controllers
{
    public class LifeLogsController : Controller
    {
        private readonly PRORegisterContext _context;

        public LifeLogsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: LifeLogs
        public async Task<IActionResult> Index()
        {
            var pRORegisterInterrimesContext = _context.LifeLog
                .Include(l => l.Game)
                .Include(l => l.Person);
            return View(await pRORegisterInterrimesContext.ToListAsync());
        }

        // GET: LifeLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeLog = await _context.LifeLog
                .Include(l => l.Game)
                .Include(l => l.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeLog == null)
            {
                return NotFound();
            }

            return View(lifeLog);
        }

        // GET: LifeLogs/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "GameNumber");
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            return View();
        }

        // POST: LifeLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,PersonId,ImageId,LifeLogStatusId,GameId")] LifeLog lifeLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lifeLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "GameNumber", lifeLog.GameId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", lifeLog.PersonId);
            return View(lifeLog);
        }

        // GET: LifeLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeLog = await _context.LifeLog.FindAsync(id);
            if (lifeLog == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "GameNumber", lifeLog.GameId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", lifeLog.PersonId);
            return View(lifeLog);
        }

        // POST: LifeLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,PersonId,ImageId,LifeLogStatusId,GameId")] LifeLog lifeLog)
        {
            if (id != lifeLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lifeLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LifeLogExists(lifeLog.Id))
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
            ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "GameNumber", lifeLog.GameId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", lifeLog.PersonId);
            return View(lifeLog);
        }

        // GET: LifeLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeLog = await _context.LifeLog
                .Include(l => l.Game)
                .Include(l => l.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeLog == null)
            {
                return NotFound();
            }

            return View(lifeLog);
        }

        // POST: LifeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lifeLog = await _context.LifeLog.FindAsync(id);
            _context.LifeLog.Remove(lifeLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LifeLogExists(int id)
        {
            return _context.LifeLog.Any(e => e.Id == id);
        }
    }
}
