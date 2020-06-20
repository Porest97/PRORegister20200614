using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRORegister.Data;
using PRORegister.PORLifeLog.Models.ViewModels;
using PRORegister.PROLifeLog.Models.DataModels;
using PRORegister.PRONBS.Models.DataModels;

namespace PRORegister.PROLifeLog.Controllers
{
    public class PhysicalLogsController : Controller
    {
        private readonly PRORegisterContext _context;

        public PhysicalLogsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: PhysicalLogs
        public async Task<IActionResult> Index()
        {
            var pRORegisterApplicationContext = _context.PhysicalLog
                .Include(p => p.Person);
            return View(await pRORegisterApplicationContext.ToListAsync());
        }

        // GET: PhysicalLogs with User - search
        public async Task<IActionResult> IndexPhysicalLogs(string searchString)
        {
            var physicalLogs = from p in _context.PhysicalLog
                .Include(p => p.Person)

                               select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                physicalLogs = physicalLogs
               .Include(p => p.Person)
               .Where(p => p.Person.LastName.Contains(searchString));

            }
            return View(await physicalLogs.ToListAsync());
        }

        // GET: ListPhysicalLogs
        public IActionResult ListPhysicalLogs()
        {
            var dataViewModel = new DataViewModel()
            {
                PhysicalLogs = _context.PhysicalLog
                .Include(p => p.Person)
                .ToList()
            };
            return View(dataViewModel);
        }


        // GET: PhysicalLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalLog = await _context.PhysicalLog
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalLog == null)
            {
                return NotFound();
            }

            return View(physicalLog);
        }

        // GET: PhysicalLogs/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            return View();
        }

        // POST: PhysicalLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,PersonId,BodyWeight,Waist,BodyFat")] PhysicalLog physicalLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(physicalLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListPhysicalLogs));
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", physicalLog.PersonId);
            return View(physicalLog);
        }

        // GET: PhysicalLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalLog = await _context.PhysicalLog.FindAsync(id);
            if (physicalLog == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", physicalLog.PersonId);
            return View(physicalLog);
        }

        // POST: PhysicalLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,PersonId,BodyWeight,Waist,BodyFat")] PhysicalLog physicalLog)
        {
            if (id != physicalLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physicalLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicalLogExists(physicalLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListPhysicalLogs));
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", physicalLog.PersonId);
            return View(physicalLog);
        }

        // GET: PhysicalLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalLog = await _context.PhysicalLog
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalLog == null)
            {
                return NotFound();
            }

            return View(physicalLog);
        }

        // POST: PhysicalLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var physicalLog = await _context.PhysicalLog.FindAsync(id);
            _context.PhysicalLog.Remove(physicalLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListPhysicalLogs));
        }

        private bool PhysicalLogExists(int id)
        {
            return _context.PhysicalLog.Any(e => e.Id == id);
        }
    }
}
