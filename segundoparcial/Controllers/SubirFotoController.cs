using System.Net.Http;
using System.Net;
using System.Text.RegularExpressions;
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
using System.IO;
using segundoparcial.Models;

namespace segundoparcial.Controllers
{   
    [Route("api/[controller]")]
     [ApiController]
    public class SubirFotoController : ControllerBase
    {

        public readonly ImagenTerceroService _subirFotoService;

        public SubirFotoController(TercerosContext context)
        {
            _subirFotoService = new ImagenTerceroService(context);
        }

        [HttpPost]
        public ActionResult Post()
        {
            ImagenTercero imagenTercero =  new ImagenTercero();
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imagenTercero.Imagen  = memoryStream.ToArray();
                    }
                    var response = _subirFotoService.Guardar(imagenTercero);
                    if(response.Error)
                    {
                        return BadRequest(response.Mensaje);
                    }
                    return Ok(response.ID);
                }
                else
                {
                    return BadRequest("Error en el controlador");
                }
              
            }
            catch 
            {
                return StatusCode(500, "Internal server error");
            }         
        }

        [HttpGet]

        public ActionResult Gets()
        {
            var response = _subirFotoService.Consultar();
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            var imagenTerceros = response.ImagenTerceros.Select(i => new ImagenTerceroViewModel(i));
            return Ok(imagenTerceros);
        }
    }
}