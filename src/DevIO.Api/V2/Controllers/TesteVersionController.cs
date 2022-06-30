using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteVersionController : MainController
    {
        public TesteVersionController(INotificador notificador,
                                      IUser appUser) : base(notificador, appUser)
        {
        }

        [HttpGet]
        public string Valor()
        {
            throw new Exception("Eu sou um teste de loggin no Elmah.io! :)");

            return "Sou a V2";
        }

    }
}
