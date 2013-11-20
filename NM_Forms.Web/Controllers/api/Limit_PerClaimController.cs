using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NM_Forms.BL;

namespace NM_Forms.Web.Controllers.api
{
    public class Limit_PerClaimController : ApiController
    {
        [HttpGet]
        public IEnumerable<Limit_PerClaim> GetPerQuoteRequest()
        {
            return Limit_PerClaim.GetAll().AsEnumerable();
        }








        [HttpPost]
        public HttpResponseMessage Create(Limit_PerClaim Lpc)
        {
            if (ModelState.IsValid)
            {
                Lpc.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Lpc);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Lpc.Limit_PerClaim_ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }





        [HttpPut]
        public HttpResponseMessage Edit(int LimitPerClaimID, Limit_PerClaim Lpc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Lpc.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
