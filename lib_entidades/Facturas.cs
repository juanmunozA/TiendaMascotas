using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Facturas
    {
        [Key] public int IDFactura { get; set; }
        public string? CodigoFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal IVA { get; set; }
        public decimal TOTAL { get; set; }
        public int Cliente { get; set; }
        public int Mascota { get; set; }
        public int Servicio { get; set; }
        public int Pago { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(CodigoFactura))
                return false;
            if (Fecha == default(DateTime))
                return false;
            if (IVA < 0)
                return false;
            if (TOTAL < 0)
                return false;
            if (Cliente <= 0)
                return false;
            if (Mascota <= 0)
                return false;
            if (Servicio <= 0)
                return false;
            if (Pago <= 0)
                return false;

            return true;
        }

    }
}
