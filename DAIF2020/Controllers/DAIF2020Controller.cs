using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
