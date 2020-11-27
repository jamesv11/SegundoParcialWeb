using Entidad;
using System;

namespace segundoparcial.Models
{

    public class TerceroInputModel
    {
        public int TerceroID { get; set; }

        public string TerceroIdentificacion { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreTercero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string NombreFoto { get; set; }
    }

    public class TerceroViewModel : TerceroInputModel
    {
        public TerceroViewModel()
        {

        }
        public TerceroViewModel(Tercero tercero)
        {   
            TerceroIdentificacion = tercero.TerceroIdentificacion;
            TipoDocumento = tercero.TipoDocumento;
            NombreTercero =  tercero.NombreTercero;
            Direccion =  tercero.Direccion;
            Telefono = tercero.Telefono;
            Pais = tercero.Pais;
            Departamento = tercero.Departamento;
            Ciudad = tercero.Ciudad;
            NombreFoto =  tercero.NombreFoto;
        }
    }

}