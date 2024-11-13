using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class TiposMascotasRepositorio : ITiposMascotasRepositorio
    {
        private Conexion? conexion = null;

        public TiposMascotasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<TiposMascotas> Listar()
        {
            return conexion!.Listar<TiposMascotas>();
        }

        public List<TiposMascotas> Buscar(Expression<Func<TiposMascotas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public TiposMascotas Guardar(TiposMascotas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public TiposMascotas Modificar(TiposMascotas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public TiposMascotas Borrar(TiposMascotas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}