using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace segundoparcial.Controllers
{
     [Route("api/[controller]")]
     [ApiController]

    public class TerceroController : ControllerBase
    {
       public readonly TerceroService _terceroService;


       public TerceroController(TercerosContext context)
        {
            _terceroService = new TerceroService(context);
        }

         

    }
}