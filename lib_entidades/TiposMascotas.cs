using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class TiposMascotas
    {
        [Key] public int ID_TipoMascota { get; set; }
        public string? TipoDeMascota { get; set; }
        public int Mascota { get; set; }
        [NotMapped] public Mascotas? _Especie { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(TipoDeMascota))
                return false;

            if (Mascota <= 0)
                return false; 
            return true;
        }
    }
}
