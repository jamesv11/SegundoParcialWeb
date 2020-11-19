using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using segundoparcial.Models;

namespace segundoparcial.Controllers
{
     [Route("api/[controller]")]
     [ApiController]

    public class PagoController : ControllerBase
    {
       public readonly PagoService _PagoService;


       public PagoController(TercerosContext context)
        {
            _PagoService = new PagoService(context);
        }

        // GET: api/Persona/id
        [HttpGet("{terceroIdentificacion}")]
        public ActionResult<IEnumerable<PagoViewModel>> Gets(string terceroIdentificacion)
        {
            var response = _PagoService.ConsultarIndividual(terceroIdentificacion); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
            }
            var terceros = response.Pagos.Select(p => new PagoViewModel(p));
            return Ok(terceros);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PagoViewModel>> Gets()
        {
            var response = _PagoService.ConsultarTodos(); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
            }
            var terceros = response.Pagos.Select(p => new PagoViewModel(p));
            return Ok(terceros);
        }

        [HttpPost]
        public ActionResult<PagoViewModel> Post(PagoInputModel pagoInput)
        {
            Pago pago = MapearPago(pagoInput);
            var response = _PagoService.Guardar(pago);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Pago);
        }
         
         private Pago MapearPago(PagoInputModel pagoInput)
        {
            var pago = new Pago
            {
                    TerceroIdentificacion = pagoInput.TerceroIdentificacion,
                    TipoPago = pagoInput.TipoPago,
                    FechaPago = pagoInput.FechaPago,
                    ValorPago = pagoInput.ValorPago,
                    IVA = pagoInput.IVA,
            };
            return pago;
        }

    }
}