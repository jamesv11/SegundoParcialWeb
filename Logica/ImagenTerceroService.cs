using System.Collections.Generic;
using System;
using Datos;
using Entidad;
using System.Linq;

namespace Logica
{
    public class ImagenTerceroService
    {

        private readonly TercerosContext _context;

        public ImagenTerceroService(TercerosContext context)
        {
            _context = context;
        }

        public GuardarImagenResponse Guardar(ImagenTercero imagenTercero)
        {
            try
            {
                _context.ImagenTercero.Add(imagenTercero);
                _context.SaveChanges();
                return new GuardarImagenResponse(imagenTercero.ImagenTerceroID);
            }
            catch (Exception e)
            {
                return new GuardarImagenResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public ConsultarImagenResponse Consultar()
        {
            try
            {
             var imagenTerceros =  _context.ImagenTercero.ToList();
             return new ConsultarImagenResponse(imagenTerceros);
            }
            catch (Exception e)
            {
                
                return new ConsultarImagenResponse($"error de aplicacion: {e.Message}");
            }

        }

        
    }
    public class GuardarImagenResponse
    {
        public GuardarImagenResponse(int id )
        {
            Error = false;
            ID  = id;
        }
        public GuardarImagenResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int ID { get; set; }
    }

    public class ConsultarImagenResponse
    {
        public ConsultarImagenResponse(List<ImagenTercero> imagenTerceros )
        {
            Error = false;
            ImagenTerceros  = imagenTerceros;
        }
        public ConsultarImagenResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<ImagenTercero> ImagenTerceros { get; set; }
    }
}