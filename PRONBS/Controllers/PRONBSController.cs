using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
}
