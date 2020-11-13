using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class TerceroService
    {
        private readonly TercerosContext _context;

        public TerceroService(TercerosContext context)
        {
            _context = context;
        }

         public GuardarTerceroResponse Guardar(Tercero tercero)
        {
            try
            {
                var personaBuscada = _context.Terceros.Find(tercero.TerceroID);
                if(personaBuscada != null)
                {
                    return new GuardarTerceroResponse("Error la persona se encuentra registrada");
                }
                _context.Terceros.Add(tercero);
                _context.SaveChanges();
                return new GuardarTerceroResponse(tercero);
            }
            catch (Exception e)
            {
                return new GuardarTerceroResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }    
         public ConsultarTerceroResponse ConsultarTodos()
        {
            try
            {
                var terceros = _context.Terceros.Include(t => t.ListaPagos).ToList();
                return new ConsultarTerceroResponse(terceros);

            }
            catch (Exception e)
            {
                return new ConsultarTerceroResponse($"error de aplicacion: {e.Message}");
            }

        }    
    }

    public class GuardarTerceroResponse
    {
        public GuardarTerceroResponse(Tercero tercero)
        {
            Error = false;
            Tercero = tercero;
        }
        public GuardarTerceroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Tercero Tercero { get; set; }
    }

    public class ConsultarTerceroResponse
    {
        public ConsultarTerceroResponse(List<Tercero> terceros)
        {
            Error = false;
            Terceros = terceros;
        }
        public ConsultarTerceroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Tercero> Terceros { get; set; }
    }
}
