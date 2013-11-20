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
    public class QuoteRequestController : ApiController
    {
        
        [HttpGet]
        public QuoteRequest GetByClientUniqueID(Guid ClientMasterID)
        {
            return QuoteRequest.getByClient(ClientMasterID);
        }




        
        [HttpGet]
        public QuoteRequest Get(int id)
        {
            return QuoteRequest.get(id);
        }





        
        [HttpPost]
        public HttpResponseMessage Create(QuoteRequest qRequest)
        {
            if (ModelState.IsValid)
            {
                qRequest.save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, qRequest);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = qRequest.QuoteRequest_ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }




      
        [HttpPut]
        public HttpResponseMessage Edit(int QRID, QuoteRequest qRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    qRequest.save();
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
