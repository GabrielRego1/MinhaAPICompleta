using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

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
            return "Sou a V2";
        }

    }
}
