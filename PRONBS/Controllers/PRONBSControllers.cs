using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PRORegister.PRONBS.Controllers
{
    //PRONBS MainController !
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
    //AssetsControllers !
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
    [Authorize]
    public class AssetBrandsController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public AssetBrandsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: AssetBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetBrand.ToListAsync());
        }

        // GET: AssetBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetBrand == null)
            {
                return NotFound();
            }

            return View(assetBrand);
        }

        // GET: AssetBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetBrandName")] AssetBrand assetBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetBrand);
        }

        // GET: AssetBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand.FindAsync(id);
            if (assetBrand == null)
            {
                return NotFound();
            }
            return View(assetBrand);
        }

        // POST: AssetBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetBrandName")] AssetBrand assetBrand)
        {
            if (id != assetBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetBrandExists(assetBrand.Id))
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
            return View(assetBrand);
        }

        // GET: AssetBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetBrand == null)
            {
                return NotFound();
            }

            return View(assetBrand);
        }

        // POST: AssetBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetBrand = await _context.AssetBrand.FindAsync(id);
            _context.AssetBrand.Remove(assetBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetBrandExists(int id)
        {
            return _context.AssetBrand.Any(e => e.Id == id);
        }
    }
    [Authorize]
    public class AssetStatusController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public AssetStatusController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: AssetStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetStatus.ToListAsync());
        }

        // GET: AssetStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetStatus == null)
            {
                return NotFound();
            }

            return View(assetStatus);
        }

        // GET: AssetStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetStatusName")] AssetStatus assetStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetStatus);
        }

        // GET: AssetStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus.FindAsync(id);
            if (assetStatus == null)
            {
                return NotFound();
            }
            return View(assetStatus);
        }

        // POST: AssetStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetStatusName")] AssetStatus assetStatus)
        {
            if (id != assetStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetStatusExists(assetStatus.Id))
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
            return View(assetStatus);
        }

        // GET: AssetStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetStatus == null)
            {
                return NotFound();
            }

            return View(assetStatus);
        }

        // POST: AssetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetStatus = await _context.AssetStatus.FindAsync(id);
            _context.AssetStatus.Remove(assetStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetStatusExists(int id)
        {
            return _context.AssetStatus.Any(e => e.Id == id);
        }
    }
    [Authorize]
    public class AssetTypesController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public AssetTypesController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: AssetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetType.ToListAsync());
        }

        // GET: AssetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        // GET: AssetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetTypeName")] AssetType assetType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetType);
        }

        // GET: AssetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }
            return View(assetType);
        }

        // POST: AssetTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetTypeName")] AssetType assetType)
        {
            if (id != assetType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTypeExists(assetType.Id))
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
            return View(assetType);
        }

        // GET: AssetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        // POST: AssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetType = await _context.AssetType.FindAsync(id);
            _context.AssetType.Remove(assetType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetTypeExists(int id)
        {
            return _context.AssetType.Any(e => e.Id == id);
        }
    }
    [Authorize]
    //BillsControllers !
    public class BillsController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public BillsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListBillsCreated
        public IActionResult ListBillsCreated()
        {
            var dataViewModel = new DataViewModel()
            {
                Bills = _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5).Where(b => b.BillStatusId == 1)

                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog1.WLog)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName");
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,CompanyId1,BillingDate,DueDate,NABLogId,NABLogId1,NABLogId2,NABLogId3,NABLogId4,BillingTerms,Hours,PriceHour,MtrCost,TotalCost,BillStatusId")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListBillsCreated));
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,CompanyId1,BillingDate,DueDate,NABLogId,NABLogId1,NABLogId2,NABLogId3,NABLogId4,BillingTerms,Hours,PriceHour,MtrCost,TotalCost,BillStatusId")] Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListBillsCreated));
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog1.WLog)
                .Include(b => b.NABLog1.WLog.WLNumber)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListBillsCreated));
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.Id == id);
        }
    }
    [Authorize]
    public class BillStatusController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public BillStatusController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: BillStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillStatus.ToListAsync());
        }

        // GET: BillStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billStatus == null)
            {
                return NotFound();
            }

            return View(billStatus);
        }

        // GET: BillStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BillStatusName")] BillStatus billStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billStatus);
        }

        // GET: BillStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus.FindAsync(id);
            if (billStatus == null)
            {
                return NotFound();
            }
            return View(billStatus);
        }

        // POST: BillStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BillStatusName")] BillStatus billStatus)
        {
            if (id != billStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillStatusExists(billStatus.Id))
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
            return View(billStatus);
        }

        // GET: BillStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billStatus == null)
            {
                return NotFound();
            }

            return View(billStatus);
        }

        // POST: BillStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billStatus = await _context.BillStatus.FindAsync(id);
            _context.BillStatus.Remove(billStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillStatusExists(int id)
        {
            return _context.BillStatus.Any(e => e.Id == id);
        }
    }
    //CompaniesControllers !
    [Authorize]
    public class CompaniesController : Controller
        {
            private readonly PRORegister.Data.PRORegisterContext _context;

            public CompaniesController(PRORegisterContext context)
            {
                _context = context;
            }

            // GET: Companies
            public async Task<IActionResult> Index()
            {
                var applicationDbContext = _context.Company
                    .Include(c => c.CompanyRole)
                    .Include(c => c.CompanyStatus)
                    .Include(c => c.CompanyType);
                return View(await applicationDbContext.ToListAsync());
            }

            public IActionResult ListCompanies()
            {


                var dataViewModel = new DataViewModel()
                {
                    Companies = _context.Company
                    .Include(c => c.CompanyRole)
                    .Include(c => c.CompanyStatus)
                    .Include(c => c.CompanyType)
                    .ToList()
                };
                return View(dataViewModel);
            }

            // GET: Companies/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var company = await _context.Company
                    .Include(c => c.CompanyRole)
                    .Include(c => c.CompanyStatus)
                    .Include(c => c.CompanyType)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (company == null)
                {
                    return NotFound();
                }

                return View(company);
            }

            // GET: Companies/Create
            public IActionResult Create()
            {
                ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName");
                ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName");
                ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName");
                return View();
            }

            // POST: Companies/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,CompanyNumber,CompanyName,StreetAddress,ZipCode,City,Country,CompanyRoleId,CompanyStatusId,CompanyTypeId")] Company company)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListCompanies));
                }
                ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
                ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
                ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
                return View(company);
            }

            // GET: Companies/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var company = await _context.Company.FindAsync(id);
                if (company == null)
                {
                    return NotFound();
                }
                ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
                ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
                ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
                return View(company);
            }

            // POST: Companies/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyNumber,CompanyName,StreetAddress,ZipCode,City,Country,CompanyRoleId,CompanyStatusId,CompanyTypeId")] Company company)
            {
                if (id != company.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(company);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CompanyExists(company.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ListCompanies));
                }
                ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
                ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
                ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
                return View(company);
            }

            // GET: Companies/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var company = await _context.Company
                    .Include(c => c.CompanyRole)
                    .Include(c => c.CompanyStatus)
                    .Include(c => c.CompanyType)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (company == null)
                {
                    return NotFound();
                }

                return View(company);
            }

            // POST: Companies/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var company = await _context.Company.FindAsync(id);
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListCompanies));
            }

            private bool CompanyExists(int id)
            {
                return _context.Company.Any(e => e.Id == id);
            }
        }
    [Authorize]
    public class CompanyRolesController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public CompanyRolesController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: CompanyRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyRole.ToListAsync());
        }

        // GET: CompanyRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // GET: CompanyRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyRoleName")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyRole);
        }

        // GET: CompanyRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }
            return View(companyRole);
        }

        // POST: CompanyRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyRoleName")] CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyRoleExists(companyRole.Id))
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
            return View(companyRole);
        }

        // GET: CompanyRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // POST: CompanyRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyRole = await _context.CompanyRole.FindAsync(id);
            _context.CompanyRole.Remove(companyRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyRoleExists(int id)
        {
            return _context.CompanyRole.Any(e => e.Id == id);
        }
    }
    //IncidentsControllers !
    [Authorize]
    public class IncidentsController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public IncidentsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site).Include(i => i.MtrlList);
            return View(await applicationDbContext.ToListAsync());
        }

        //ListIncidents - All
        public IActionResult ListIncidents()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .Include(i => i.PurchaseOrder).Where(i => i.IncidentStatusId < 3)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListIncidentsP1
        public IActionResult ListIncidentsP1()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .Include(i => i.Site).Where(i => i.IncidentPriorityId == 1).Where(i => i.IncidentStatusId < 3)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListIncidentsP2
        public IActionResult ListIncidentsP2()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .Include(i => i.Site).Where(i => i.IncidentPriorityId == 2).Where(i => i.IncidentStatusId < 3)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListIncidentsP3
        public IActionResult ListIncidentsP3()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .Include(i => i.Site).Where(i => i.IncidentPriorityId == 3).Where(i => i.IncidentStatusId < 3)
                .ToList()
            };
            return View(dataViewModel);
        }
        // GET: ListIncidentsP3
        public IActionResult ListIncidentsSolved()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .Include(i => i.Site).Where(i => i.IncidentStatusId == 3)
                .ToList()
            };
            return View(dataViewModel);
        }


        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/DetailsPrint/5
        public async Task<IActionResult> DetailsPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description");
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName");
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName");
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName");
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber");
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId.MtrlListId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListIncidents));
            }
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId,MtrlListId")] Incident incident)
        {
            if (id != incident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListIncidents));
            }
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incident.FindAsync(id);
            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListIncidents));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.Id == id);
        }
    }
    //ImageController !
    [Authorize]
    public class ImageController : Controller
    {
        private readonly PRORegisterContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(PRORegisterContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwwroot/Image !
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record !
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Title,ImageName")] ImageModel imageModel)
        {
            if (id != imageModel.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.ImageId))
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
            return View(imageModel);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.Images.FindAsync(id);

            //Delete image from wwwwroot/Image/ !

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //Deletes the reccourd !
            _context.Images.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
    [Authorize]
    public class MtrlListsController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public MtrlListsController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: MtrlLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.MtrlList.ToListAsync());
        }

        // GET: ListMtrlLists
        public IActionResult ListMtrlLists()
        {
            var dataViewModel = new DataViewModel()
            {
                MtrlLists = _context.MtrlList
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: MtrlLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mtrlList == null)
            {
                return NotFound();
            }

            return View(mtrlList);
        }

        // GET: MtrlLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MtrlLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10")] MtrlList mtrlList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mtrlList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListMtrlLists));
            }
            return View(mtrlList);
        }

        // GET: MtrlLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList.FindAsync(id);
            if (mtrlList == null)
            {
                return NotFound();
            }
            return View(mtrlList);
        }

        // POST: MtrlLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10")] MtrlList mtrlList)
        {
            if (id != mtrlList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mtrlList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MtrlListExists(mtrlList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListMtrlLists));
            }
            return View(mtrlList);
        }

        // GET: MtrlLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mtrlList == null)
            {
                return NotFound();
            }

            return View(mtrlList);
        }

        // POST: MtrlLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mtrlList = await _context.MtrlList.FindAsync(id);
            _context.MtrlList.Remove(mtrlList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListMtrlLists));
        }

        private bool MtrlListExists(int id)
        {
            return _context.MtrlList.Any(e => e.Id == id);
        }
    }
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public PeopleController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Person
                .Include(p => p.Company)
                .Include(p => p.PersonAccounts)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListPeople()
        {
            var dataViewModel = new DataViewModel()
            {
                People = _context.Person
                .Include(p => p.Company)
                .Include(p => p.PersonAccounts)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Company)
                .Include(p => p.PersonAccounts)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["PersonAccountsId"] = new SelectList(_context.Set<PersonAccounts>(), "Id", "PaymentDetails");
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName");
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName");
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonRoleId,PersonStatusId,PersonTypeId,CompanyId,FirstName,LastName,StreetAddress,ZipCode,City,Country,Ssn,PhoneNumber1,PhoneNumber2,Email,PersonAccountsId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListPeople));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", person.CompanyId);
            ViewData["PersonAccountsId"] = new SelectList(_context.Set<PersonAccounts>(), "Id", "PaymentDetails", person.PersonAccountsId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", person.CompanyId);
            ViewData["PersonAccountsId"] = new SelectList(_context.Set<PersonAccounts>(), "Id", "PaymentDetails", person.PersonAccountsId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonRoleId,PersonStatusId,PersonTypeId,CompanyId,FirstName,LastName,StreetAddress,ZipCode,City,Country,Ssn,PhoneNumber1,PhoneNumber2,Email,PersonAccountsId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListPeople));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", person.CompanyId);
            ViewData["PersonAccountsId"] = new SelectList(_context.Set<PersonAccounts>(), "Id", "PaymentDetails", person.PersonAccountsId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Company)
                .Include(p => p.PersonAccounts)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListPeople));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
    [Authorize]
    public class SitesController : Controller
    {
        private readonly PRORegister.Data.PRORegisterContext _context;

        public SitesController(PRORegisterContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Site
                .Include(s => s.Company)
                .Include(s => s.Contact1)
                .Include(s => s.Contact2)
                .Include(s => s.SiteRole)
                .Include(s => s.SiteStatus)
                .Include(s => s.SiteType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListSites
        public IActionResult ListSites()
        {
            var dataViewModel = new DataViewModel()
            {
                Sites = _context.Site
                .Include(s => s.Company)
                .Include(s => s.Contact1)
                .Include(s => s.Contact2)
                .Include(s => s.SiteRole)
                .Include(s => s.SiteStatus)
                .Include(s => s.SiteType)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.Company)
                .Include(s => s.Contact1)
                .Include(s => s.Contact2)
                .Include(s => s.SiteRole)
                .Include(s => s.SiteStatus)
                .Include(s => s.SiteType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SiteRoleId"] = new SelectList(_context.Set<SiteRole>(), "Id", "SiteRoleName");
            ViewData["SiteStatusId"] = new SelectList(_context.Set<SiteStatus>(), "Id", "SiteStatusName");
            ViewData["SiteTypeId"] = new SelectList(_context.Set<SiteType>(), "Id", "SiteTypeName");
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteNumber,SiteName,StreetAddress,ZipCode,City,Country,NumberOfFloors,SiteNotes,SiteRoleId,SiteStatusId,SiteTypeId,PersonId,PersonId1,CompanyId")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSites));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", site.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId1);
            ViewData["SiteRoleId"] = new SelectList(_context.Set<SiteRole>(), "Id", "SiteRoleName", site.SiteRoleId);
            ViewData["SiteStatusId"] = new SelectList(_context.Set<SiteStatus>(), "Id", "SiteStatusName", site.SiteStatusId);
            ViewData["SiteTypeId"] = new SelectList(_context.Set<SiteType>(), "Id", "SiteTypeName", site.SiteTypeId);
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", site.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId1);
            ViewData["SiteRoleId"] = new SelectList(_context.Set<SiteRole>(), "Id", "SiteRoleName", site.SiteRoleId);
            ViewData["SiteStatusId"] = new SelectList(_context.Set<SiteStatus>(), "Id", "SiteStatusName", site.SiteStatusId);
            ViewData["SiteTypeId"] = new SelectList(_context.Set<SiteType>(), "Id", "SiteTypeName", site.SiteTypeId);
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteNumber,SiteName,StreetAddress,ZipCode,City,Country,NumberOfFloors,SiteNotes,SiteRoleId,SiteStatusId,SiteTypeId,PersonId,PersonId1,CompanyId")] Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSites));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", site.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", site.PersonId1);
            ViewData["SiteRoleId"] = new SelectList(_context.Set<SiteRole>(), "Id", "SiteRoleName", site.SiteRoleId);
            ViewData["SiteStatusId"] = new SelectList(_context.Set<SiteStatus>(), "Id", "SiteStatusName", site.SiteStatusId);
            ViewData["SiteTypeId"] = new SelectList(_context.Set<SiteType>(), "Id", "SiteTypeName", site.SiteTypeId);
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.Company)
                .Include(s => s.Contact1)
                .Include(s => s.Contact2)
                .Include(s => s.SiteRole)
                .Include(s => s.SiteStatus)
                .Include(s => s.SiteType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.FindAsync(id);
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSites));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.Id == id);
        }
    }

}

