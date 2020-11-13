using System.ComponentModel.DataAnnotations;
using System;
namespace Entidad
{
    public class Pago
    {
        //relacion

        public int PagoID { get; set; }
        public int TerceroID { get; set; }
        public String TipoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorPago { get; set; }
        public decimal IVA { get; set; }

        
        public virtual Tercero Tercero { get; set; }

    }
}