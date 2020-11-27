using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Entidad
{
    public class Tercero
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
        public virtual List<Pago> ListaPagos { get; set; }
    }
}
