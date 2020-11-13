namespace Entidad
{
    public class Pago
    {
        //relacion
        public int TerceroID { get; set; }
        public Tercero Tercero { get; set; }


        public String TipoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorPago { get; set; }
        public decimal IVA { get; set; }

    }
}