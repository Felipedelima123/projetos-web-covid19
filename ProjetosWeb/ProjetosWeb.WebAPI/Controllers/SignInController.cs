using ProjetosWeb.Application;
using ProjetosWeb.Domain.Entities;
using ProjetosWeb.Repository;
using ProjetosWeb.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetosWeb.WebAPI.Controllers
{
    /// <summary>
    /// API Responsável pelo login do usuário
    /// </summary>
    
    public class SignInController : ApiController
    {

        /// <summary>
        /// Este método realiza o login do usuário
        /// </summary>
        /// <param name="email">Email do usuário cadastrado na plataforma</param>
        /// <param name="password">Senha do usuário cadastrado na plataforma</param>
        /// <returns>Retorna o Id do usuário logado</returns>


        public HttpResponseMessage Post([FromBody]string email, [FromBody] string password)
        {
            try
            {
                //Realizar o login do usuário se os dados estiverem corretos
                //Validar se o usuário está ativo (possui e-mail verificado)

                UserRepository userRepository = new UserRepository();
                UserApplication userApplication = new UserApplication(userRepository);

                Guid id = userApplication.Inserir(new ProjetosWeb.Domain.Entities.User());

                return Request.CreateResponse(HttpStatusCode.OK, id);
            } catch (ApplicationException ap) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ap);
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
