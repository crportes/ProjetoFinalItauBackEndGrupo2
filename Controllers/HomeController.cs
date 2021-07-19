using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoFinalItauBackEndGrupo2.models;

namespace ProjetoFinalItauBackEndGrupo2.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase
    {
       
        [Route("/")]
        [HttpGet]
        public ActionResult Index()
        {    
            //return Redirect("/swagger");
            return StatusCode(200,new{
                mensagem="bem vindo a Api dotnetCore",
                documentacao="https://localhost:5001/swagger/index.html"
            });
        }


    }
}
