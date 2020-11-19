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
using segundoparcial.Models;

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

        // GET: api/Persona
        [HttpGet]
        public ActionResult<IEnumerable<TerceroViewModel>> Gets()
        {
            var response = _terceroService.ConsultarTodos(); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
            }
            var terceros = response.Terceros.Select(p => new TerceroViewModel(p));
            return Ok(terceros);
        }

        [HttpPost]
        public ActionResult<TerceroViewModel> Post(TerceroViewModel terceroInput)
        {
            Tercero tercero = MapearTercero(terceroInput);
            var response = _terceroService.Guardar(tercero);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Tercero);
        }
         
         private Tercero MapearTercero(TerceroInputModel terceroInput)
        {
            var tercero = new Tercero
            {
                    TerceroID = terceroInput.TerceroID,
                    TerceroIdentificacion = terceroInput.TerceroIdentificacion,
                    TipoDocumento = terceroInput.TipoDocumento,
                    NombreTercero = terceroInput.NombreTercero,
                    Direccion = terceroInput.Direccion,
                    Telefono = terceroInput.Telefono,
                    Pais = terceroInput.Pais,
                    Departamento =  terceroInput.Departamento,
                    Ciudad =  terceroInput.Ciudad
            };
            return tercero;
        }

    }
}