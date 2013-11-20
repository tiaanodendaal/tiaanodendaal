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
    public class QuoteFeedbackController : ApiController
    {
       


        
        [HttpGet]
        public IEnumerable<QuoteFeedback> GetPerQuoteRequest(int QuoteRequest)
        {
            return QuoteFeedback.getPerClientQuote(QuoteRequest).AsEnumerable();
        }







       
        [HttpPost]
        public HttpResponseMessage Create(QuoteFeedback qFeedback)
        {
            if (ModelState.IsValid)
            {
                qFeedback.save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, qFeedback);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = qFeedback.QuoteFeedback_ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }




       
        [HttpPut]
        public HttpResponseMessage Edit(int QRID, QuoteFeedback qFeedback)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    qFeedback.save();
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
