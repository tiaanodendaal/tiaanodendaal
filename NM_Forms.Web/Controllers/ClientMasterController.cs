using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NM_Forms.BL;
using WebMatrix.WebData;

namespace NM_Forms.Web.Controllers
{
    public class ClientMasterController : Controller
    {
        public ActionResult Index()
        {
            List<ClientMaster> xClientMaster = ClientMaster.GetAll().ToList();
            return View(xClientMaster);
        }






        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientMaster clientmaster)
        {
            if (ModelState.IsValid)
            {
                //Check if user exists in DB
                if (WebSecurity.UserExists(clientmaster.REF_Identity))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(clientmaster.REF_Identity, "123456");
                    clientmaster.UniqueID = Guid.NewGuid();
                    clientmaster.InitialKey = "123456";
                    clientmaster.RequiresPasswordChange = true;
                    clientmaster.ClientStatusID = 0;

                    clientmaster.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(clientmaster);
        }


       







        public ActionResult Edit(int id)
        {
            ClientMaster xClientMaster = ClientMaster.Get(id);
            if (xClientMaster == null)
            {
                return HttpNotFound();
            }
            return View(xClientMaster);
        }

        [HttpPost]
        public ActionResult Edit(ClientMaster clientmaster)
        {
            if (ModelState.IsValid)
            {
                    clientmaster.Save();
                    return RedirectToAction("Index");
            }
            return View(clientmaster);
        }












        public ActionResult Register()
        {

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "" });
         
            var cat = Titles.GetAll().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].TitleName,
                    Value = cat[i].TitleName.ToString()
                });
            }
            ViewData["danhsach"] = list;
            return View();

            
        }

        [HttpPost]
        public ActionResult Register(ClientMaster clientmaster)
        {
            if (ModelState.IsValid)
            {
                //Check if user exists in DB
                if (WebSecurity.UserExists(clientmaster.REF_Identity))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ClientMaster xClientMaster = new ClientMaster();
                    WebSecurity.CreateUserAndAccount(clientmaster.REF_Identity, "123456");
                    clientmaster.UniqueID = Guid.NewGuid();
                    //Get a random password
                    clientmaster.InitialKey = "123456";
                    clientmaster.RequiresPasswordChange = true;
                    clientmaster.ClientStatusID = 4;
                    clientmaster.REF_Practice = "";
                    clientmaster.Save();
                    //if all good send sms
                    return Redirect("../Account/InitialLogin");
                }
            }

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });

            var cat = Titles.GetAll().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].TitleName,
                    Value = cat[i].TitleName.ToString()
                });
            }
            ViewData["danhsach"] = list;
            return View(clientmaster);
        }











        public ActionResult CreateQuoteRequest(Guid id)
        {
            QuoteRequest xReq = QuoteRequest.getByClient(id);
            if (xReq == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat = BusinessTypes.GetAll().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].Businesstype_Name.ToString(),
                    Value = cat[i].Businesstype_ID.ToString()
                });
            }
            ViewData["list1"] = list;

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat2 = Business_Disciplines.GetAll().ToArray();
            for (int i = 0; i < cat2.Length; i++)
            {
                list2.Add(new SelectListItem
                {
                    Text = cat2[i].Business_Discipline_Name.ToString(),
                    Value = cat2[i].Business_Discipline_ID.ToString()
                });
            }
            ViewData["list2"] = list2;

            List<SelectListItem> list3 = new List<SelectListItem>();
            list3.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat3 = Limit_PerClaim.GetAll().ToArray();
            for (int i = 0; i < cat3.Length; i++)
            {
                list3.Add(new SelectListItem
                {
                    Text = cat3[i].Limit_PerClaimDetails.ToString(),
                    Value = cat3[i].Limit_PerClaim_ID.ToString()
                });
            }
            ViewData["list3"] = list3;

            List<SelectListItem> list4 = new List<SelectListItem>();
            list4.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            list4.Add(new SelectListItem
            {
                Text = "Monthly",
                Value = "1"
            });
            list4.Add(new SelectListItem
            {
                Text = "Yearly",
                Value = "2"
            });
            ViewData["list4"] = list4;

            return View(xReq);
        }
        [HttpPost]
        public ActionResult CreateQuoteRequest(QuoteRequest qRequest)
        {
            if (ModelState.IsValid)
            {
                qRequest.Acceptance_Quote = DateTime.Now;
                qRequest.QuoteType = 1;
                Business_Disciplines XdISC = Business_Disciplines.get((int)qRequest.Business_Discipline_ID);
                qRequest.Business_Discipline = XdISC.Business_Discipline_Name;
                BusinessTypes XbType = BusinessTypes.get((int)qRequest.Businesstype_ID);
                qRequest.Business_Type = XbType.Businesstype_Name;
                qRequest.save();

                ClientMaster xMaster = ClientMaster.Get(qRequest.ClientMasterID);
                xMaster.ClientStatusID = 12;
                xMaster.Save();

                //SEND EMAIL TO ADMIN

                return Redirect("../QuotationsInfo");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat = BusinessTypes.GetAll().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].Businesstype_Name.ToString(),
                    Value = cat[i].Businesstype_ID.ToString()
                });
            }
            ViewData["list1"] = list;

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat2 = Business_Disciplines.GetAll().ToArray();
            for (int i = 0; i < cat2.Length; i++)
            {
                list2.Add(new SelectListItem
                {
                    Text = cat2[i].Business_Discipline_Name.ToString(),
                    Value = cat2[i].Business_Discipline_ID.ToString()
                });
            }
            ViewData["list2"] = list2;

            List<SelectListItem> list3 = new List<SelectListItem>();
            list3.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat3 = Limit_PerClaim.GetAll().ToArray();
            for (int i = 0; i < cat3.Length; i++)
            {
                list3.Add(new SelectListItem
                {
                    Text = cat3[i].Limit_PerClaimDetails.ToString(),
                    Value = cat3[i].Limit_PerClaim_ID.ToString()
                });
            }
            ViewData["list3"] = list3;

            List<SelectListItem> list4 = new List<SelectListItem>();
            list4.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            list4.Add(new SelectListItem
            {
                Text = "Monthly",
                Value = "1"
            });
            list4.Add(new SelectListItem
            {
                Text = "Yearly",
                Value = "2"
            });
            ViewData["list4"] = list4;
            return View();
        }







        public ActionResult QuotationsInfo()
        {
            return View();
        }




        public ActionResult QuotesPerClients()
        {
            List<INTERFACE_ClientAwaitingQuotes> xQuotes = QuoteFeedback.getClientsAwaitingQuotes();
            if (xQuotes == null)
            {
                return HttpNotFound();
            }
            return View(xQuotes);
        }




        public ActionResult AddQuote(int id)
        {
            QuoteFeedback NewRequest = new QuoteFeedback();
            NewRequest.Active_YN = true;
            NewRequest.QuoteRequest_ID = id;

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cat = Insurer.GetAll().ToArray();
            for (int i = 0; i < cat.Length; i++)
            {
                list.Add(new SelectListItem
                {
                    Text = cat[i].Insurer_Name.ToString(),
                    Value = cat[i].Insurer_ID.ToString()
                });
            }
            ViewData["list1"] = list;


            return View(NewRequest);
        }
        [HttpPost]
        public ActionResult AddQuote(QuoteFeedback xQuote)
        {
            xQuote.save();

            QuoteRequest xReq = QuoteRequest.get(xQuote.QuoteRequest_ID);

            return Redirect("../QuotesPerClients/" + xReq.ClientMasterID.ToString());
        }




        public ActionResult QuotesPerClient(int id)
        {

            QuoteRequest xReq = QuoteRequest.get(id);
            ClientMaster xMaster = ClientMaster.Get(xReq.ClientMasterID);
            ViewBag.Message = "Quotes for the following Client: " + xMaster.Name_Title + " " + xMaster.Name_First + " " + xMaster.Name_Last;
            List<QuoteFeedback> xQuotes = QuoteFeedback.getPerClientQuote(id);
            if (xQuotes == null)
            {
                return HttpNotFound();
            }
            return View(xQuotes);
        }


        public ActionResult Finalise(int id)
        {

            QuoteRequest xReq = QuoteRequest.get(id);
            ClientMaster xMaster = ClientMaster.Get(xReq.ClientMasterID);
            xMaster.ClientStatusID = 16;
            xMaster.Save();
            return Redirect("../QuotesPerClients");
        }


        public ActionResult QuotationsList(Guid id)
        {

            QuoteRequest xReq = QuoteRequest.getByClient(id);
            ClientMaster xMaster = ClientMaster.Get(xReq.ClientMasterID);
            ViewBag.Message = "Quotes for: " + xMaster.Name_Title + " " + xMaster.Name_First + " " + xMaster.Name_Last;
            List<QuoteFeedback> xQuotes = QuoteFeedback.getPerClientQuote(xReq.QuoteRequest_ID);
            if (xQuotes == null)
            {
                return HttpNotFound();
            }
            return View(xQuotes);
        }

    }
}