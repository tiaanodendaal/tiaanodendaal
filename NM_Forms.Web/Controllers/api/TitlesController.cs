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
    public class TitlesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Titles> GetPerQuoteRequest()
        {
            return Titles.GetAll().AsEnumerable();
        }








        [HttpPost]
        public HttpResponseMessage Create(Titles title)
        {
            if (ModelState.IsValid)
            {
                title.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, title);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = title.TitleID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }





        [HttpPut]
        public HttpResponseMessage Edit(int Title_ID, Titles title)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    title.Save();
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
