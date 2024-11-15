﻿using lib_entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Servicios
    {
        [Key] public int ID_Servicio { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public int Mascota { get; set; }

        [NotMapped] public Mascotas? _Especie { get; set; }



        public bool Validar()
        {   
            if (Precio < 0)
                return false;
            if (Mascota <= 0)
                return false; 

            return true;
        }
    }
}