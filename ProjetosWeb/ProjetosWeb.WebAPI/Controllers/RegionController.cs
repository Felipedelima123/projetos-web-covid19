using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetosWeb.WebAPI.Controllers
{
    public class RegionController : ApiController
    {
        // GET: api/Region/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                //Realizar consulta no banco de dados com o trajeto percorrido pelo usuário

                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
