using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NM_Forms.Web.Models
{
    public class Product : Controller
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }

        public ActionResult Index()
        {
            return View();
        }

    }
}
