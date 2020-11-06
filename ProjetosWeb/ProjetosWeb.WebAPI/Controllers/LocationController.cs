using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetosWeb.WebAPI.Controllers
{
    public class LocationController : ApiController
    {

        // POST: api/Location
        public HttpResponseMessage Post([FromBody] string value)
        {
            try
            {
                //Realizar o cadastro da posição do usuário no banco de dados

                Guid id = Guid.NewGuid();
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
