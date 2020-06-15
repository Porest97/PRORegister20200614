﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRORegister.PRONBS.Models.ViewModels;
using PRORegister.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRORegister.PRONBS.Models.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace PRORegister.PRONBS.Controllers
{
    [Authorize]
    public class PRONBSController : Controller
    {
        // GET: PRONBSController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PRONBSController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PRONBSController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRONBSController/Create
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

        // GET: PRONBSController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PRONBSController/Edit/5
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

        // GET: PRONBSController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PRONBSController/Delete/5
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
    [Authorize]
    public class AssetsController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public AssetsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets with Site - search
        public async Task<IActionResult> IndexSite(string searchString)
        {
            var assets = from a in _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site)

                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                 assets = assets
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .Where(s => s.Site.SiteNumber.Contains(searchString));

            }
            return View(await assets.ToListAsync());
        }

        // GET: ListAssets
        public IActionResult ListAssets()
        {
            var dataViewModel = new DataViewModel()
            {
                 Assets = _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName");
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName");
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteId,AssetStatusId,AssetTypeId,AssetBrandId,Name,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAssets));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", asset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", asset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteId,AssetStatusId,AssetTypeId,AssetBrandId,Name,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListAssets));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", asset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetStatus)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListAssets));
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.Id == id);
        }
    }
}
