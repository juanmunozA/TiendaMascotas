using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Tipos_ServiciosRepositorio : ITipos_ServiciosRepositorio
    {
        private Conexion? conexion = null;

        public Tipos_ServiciosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Tipos_Servicios> Listar()
        {
            return conexion!.Listar<Tipos_Servicios>();
        }

        public List<Tipos_Servicios> Buscar(Expression<Func<Tipos_Servicios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Tipos_Servicios Guardar(Tipos_Servicios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Tipos_Servicios Modificar(Tipos_Servicios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Tipos_Servicios Borrar(Tipos_Servicios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}