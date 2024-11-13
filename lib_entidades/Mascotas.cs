using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Mascotas
    {
        [Key] public int ID_Mascota { get; set; }
        public string? Cod_Mascota { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? Edad { get; set; }
        public int Dueño { get; set; }
        [NotMapped] public Clientes? _Dueño { get; set; }


        public bool Validar()
        {
            if (string.IsNullOrEmpty(Cod_Mascota))
                return false;
            if (string.IsNullOrEmpty(Nombre))
                return false;
            if (string.IsNullOrEmpty(Genero) || (Genero != "Macho" && Genero != "Hembra"))
                return false; 
            if (string.IsNullOrEmpty(Edad))
                return false;
            if (Dueño <= 0)
                return false; 

            return true;
        }
    }
}