using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NM_Forms.BL;

namespace NM_Forms.Web.Controllers
{
    public class InsurerController : Controller
    {
        
        public ActionResult Index()
        {
            List<Insurer> xItems = Insurer.GetAll().ToList();
            return View(xItems);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Insurer xIns)
        {
            if (ModelState.IsValid)
            {
                xIns.ActiveYN = true;
                xIns.Save();
                return RedirectToAction("Index");
            }
            return View(xIns);
        }

        public ActionResult Edit(int id)
        {
            Insurer xItem = Insurer.get(id);
            return View(xItem);
        }
        [HttpPost]
        public ActionResult Edit(Insurer xIns)
        {
            if (ModelState.IsValid)
            {
                xIns.Save();
                return RedirectToAction("Index");
            }
            return View(xIns);
        }

    }
}
