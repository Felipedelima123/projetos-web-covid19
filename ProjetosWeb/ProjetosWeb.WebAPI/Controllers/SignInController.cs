using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetosWeb.WebAPI.Controllers
{
    public class SignInController : ApiController
    {
        // POST: api/SignIn
        public HttpResponseMessage Post([FromBody]string value)
        {
            try
            {
                //Realizar o login do usuário se os dados estiverem corretos
                //Validar se o usuário está ativo (possui e-mail verificado)

                Guid id = Guid.NewGuid();
                return Request.CreateResponse(HttpStatusCode.OK, id);
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
