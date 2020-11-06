using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetosWeb.WebAPI.Controllers
{
    public class SignUpController : ApiController
    {
        // POST: api/SignUp
        public HttpResponseMessage Post([FromBody]string value)
        {
            try
            {
                //Realizar o cadastro do usuário se o username e email forem únicos na base de dados
                //Validar senhas iguais e requisitos minimos
                //Adicionar verificação de e-mail existente

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
