using Entidad;
using System;

namespace segundoparcial.Models
{

    public class PagoInputModel
    {

        public int TerceroID { get; set; }
        public String TipoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorPago { get; set; }
        public decimal IVA { get; set; }
    }

    public class PagoViewModel : PagoInputModel
    {

        public int PagoId { get; set; }
        public PagoViewModel()
        {

        }
        public PagoViewModel(Pago pago)
        {

           TerceroID = pago.TerceroID;
           TipoPago = pago.TipoPago;
           FechaPago = pago.FechaPago;
           ValorPago = pago.ValorPago;
           IVA = pago.IVA;
           PagoId = pago.PagoID;
        }
    }

}