﻿using System;

namespace Entidad
{
    public class Tercero
    {
        public int TerceroID { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreTercero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }

        public List<pago> ListaPagos { get; set; }
    }
}