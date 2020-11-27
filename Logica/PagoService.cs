using System;
using System.Linq;
using Datos;
using Entidad;
using System.Collections.Generic;

namespace Logica
{
    public class PagoService
    {
        private readonly TercerosContext _context;

        public PagoService(TercerosContext context)
        {
            _context = context;
        }

         public GuardarPagoResponse Guardar(Pago pago)
        {
            try
            {
                var pagoBuscado = _context.Pagos.Find(pago.PagoID);
                if(pagoBuscado != null)
                {
                    return new GuardarPagoResponse("Error la persona se encuentra registrada");
                }
                _context.Pagos.Add(pago);
                _context.SaveChanges();
                return new GuardarPagoResponse(pago);
            }
            catch (Exception e)
            {
                return new GuardarPagoResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }    
         public ConsultarPagoResponse ConsultarIndividual(string identificacionTercero)
        {
            try
            {
                var pagos = _context.Pagos.Where(p => p.TerceroIdentificacion == identificacionTercero).ToList();
                return new ConsultarPagoResponse(pagos);

            }
            catch (Exception e)
            {
                return new ConsultarPagoResponse($"error de aplicacion: {e.Message}");
            }

        }  

        public ConsultarPagoResponse ConsultarTodos()
        {
            try
            {
                var pagos = _context.Pagos.ToList();
                return new ConsultarPagoResponse(pagos);

            }
            catch (Exception e)
            {
                return new ConsultarPagoResponse($"error de aplicacion: {e.Message}");
            }

        } 

        public RespuestaTotalizar ValorTotalPagos()
        {
            try{
                var total =  _context.Pagos.Sum(p => p.ValorPago);  
                return new RespuestaTotalizar(total);
            }
            catch(Exception e )
            {
                return new RespuestaTotalizar($"error de aplicacion :  {e.Message} ");
            }
        }
    }

    public class GuardarPagoResponse
    {
        public GuardarPagoResponse(Pago pago)
        {
            Error = false;
            Pago = pago;
        }
        public GuardarPagoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Pago Pago { get; set; }
    }

    public class ConsultarPagoResponse
    {
        public ConsultarPagoResponse(List<Pago> pagos)
        {
            Error = false;
            Pagos = pagos;
        }
        public ConsultarPagoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Pago> Pagos { get; set; }
    }

    public class RespuestaTotalizar
    {
        public RespuestaTotalizar(decimal totalValorPagos)
        {
            Error = false;
            TotalValorPagos = totalValorPagos;
        }
        public RespuestaTotalizar(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public decimal TotalValorPagos { get; set; }
    }
}