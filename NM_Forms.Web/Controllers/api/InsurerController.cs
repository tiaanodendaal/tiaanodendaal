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
    public class InsurerController : ApiController
    {
        [HttpGet]
        public IEnumerable<Insurer> GetPerQuoteRequest()
        {
            return Insurer.GetAll().AsEnumerable();
        }








        [HttpPost]
        public HttpResponseMessage Create(Insurer Ins)
        {
            if (ModelState.IsValid)
            {
                Ins.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Ins);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Ins.Insurer_ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }





        [HttpPut]
        public HttpResponseMessage Edit(int QRID, Insurer Ins)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Ins.Save();
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
