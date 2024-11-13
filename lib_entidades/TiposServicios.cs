using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class TiposServicios

    {
        [Key] public int IDTipoServicio { get; set; }
        public string? TipoServicio { get; set; }
        public int Servicio { get; set; }

        [NotMapped] public Servicios? _Servicio { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(TipoServicio))
                return false;

            if (Servicio <= 0)
                return false; 

            return true;
        }
    }

}
