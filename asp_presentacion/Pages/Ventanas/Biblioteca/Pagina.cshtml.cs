using lib_entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas.Biblioteca
{
    public class BibliotecaModel : PageModel
    {
        public void OnGet()
        {
            //ViewData["Mensaje"] = "Pruebas de datos";

            Lista.Add(new Libros()
            {
                Codigo = "rtr",
                Nombre = "erer",
                CantEstudiantes = "erer",
            });
            
        }

        public Libros Actual { get; set; }
        public void OnPostBtGuardar() { 
          Lista.Add(Actual);
        }
        public List<Libros> Lista { get; set; } = new List<Libros>();
    }

    public class Libros
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
       
        public string? CantEstudiantes { get; set; }

    }
}