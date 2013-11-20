using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NM_Forms.BL;

namespace NM_Forms.Web.Controllers
{
    public class Limit_PerClaimController : Controller
    {
        public ActionResult Index()
        {
            List<Limit_PerClaim> xClientMaster = Limit_PerClaim.GetAll().ToList();
            return View(xClientMaster);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Limit_PerClaim Limitmaster)
        {
            if (ModelState.IsValid)
            {

                Limitmaster.Save();
                return RedirectToAction("Index");
            }
            return View(Limitmaster);
        }

    }
}
