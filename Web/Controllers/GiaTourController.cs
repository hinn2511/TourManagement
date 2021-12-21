using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagement.BUS;

namespace Web.Controllers
{
    public class GiaTourController : Controller
    {
        Bus_GiaTour bus = new Bus_GiaTour();
        // GET: GiaTour
        public ActionResult Index(int id)
        {
            var dsGia = bus.LayDanhSachGiaTour(id);
            return View(dsGia);
        }

        // GET: GiaTour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GiaTour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaTour/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GiaTour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GiaTour/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GiaTour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GiaTour/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
