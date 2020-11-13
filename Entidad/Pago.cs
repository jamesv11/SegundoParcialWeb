using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Pago
    {
        //relacion

        public int PagoID { get; set; }
        public int TerceroID { get; set; }
        public String TipoPago { get; set; }
        public DateTime FechaPago { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorPago { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal IVA { get; set; }

        
        public virtual Tercero Tercero { get; set; }

    }
}