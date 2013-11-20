using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NM_Forms.BL;

namespace NM_Forms.Web.Controllers
{
    public class TitlesController : Controller
    {
       

        public ActionResult Index()
        {
            List<Titles> xClientMaster = Titles.GetAll().ToList();
            return View(xClientMaster);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Titles titlemaster)
        {
            if (ModelState.IsValid)
            {

                titlemaster.Save();
                return RedirectToAction("Index");
            }
            return View(titlemaster);
        }


    }
}
