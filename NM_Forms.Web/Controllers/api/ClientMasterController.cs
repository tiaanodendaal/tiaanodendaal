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
    public class ClientMasterController : ApiController
    {
        

        
        [HttpGet]
        public IEnumerable<ClientMaster> Get()
        {
            return ClientMaster.GetAll().AsEnumerable();
        }




        
        [HttpGet]
        public ClientMaster Get(int id)
        {
            return ClientMaster.Get(id);
        }





       
        [HttpPost]
        public HttpResponseMessage Create(ClientMaster clientmaster)
        {
            if (ModelState.IsValid)
            {
                clientmaster.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, clientmaster);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = clientmaster.ClientMaster_ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }




       
        [HttpPut]
        public HttpResponseMessage Edit(int ClientID, ClientMaster clientmaster)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    clientmaster.Save();
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
