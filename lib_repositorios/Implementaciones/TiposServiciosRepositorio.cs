using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class TiposServiciosRepositorio : ITiposServiciosRepositorio
    {
        private Conexion? conexion = null;

        public TiposServiciosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<TiposServicios> Listar()
        {
            return conexion!.Listar<TiposServicios>();
        }

        public List<TiposServicios> Buscar(Expression<Func<TiposServicios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public TiposServicios Guardar(TiposServicios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public TiposServicios Modificar(TiposServicios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public TiposServicios Borrar(TiposServicios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}