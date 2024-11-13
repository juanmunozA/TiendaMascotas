using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Clientes
    {
        [Key] public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public DateTime? Fecha { get; set; }

        public string? Telefono { get; set; }




        public bool Activa { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            if (string.IsNullOrEmpty(Direccion))
                return false;
            if (Fecha == null )
                return false;  
            if (string.IsNullOrEmpty(Telefono) )
                return false;

            return true;
        }
    }
}