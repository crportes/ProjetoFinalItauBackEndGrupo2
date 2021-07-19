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

    public class ClientesController : ControllerBase
    {
        [Route("/clientes")]
        [HttpGet]
        public List<Cliente> Index()
        {    
            return Cliente.Lista();
        }

        [Route("/clientes/{id}")]
        [HttpGet]
        public Cliente Show(int id)
        {
            return Cliente.BuscaPorId(id);
        }






    }
}
