using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class MetodosPagosRepositorio : IMetodosPagosRepositorio
    {
        private Conexion? conexion = null;

        public MetodosPagosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<MetodosPagos> Listar()
        {
            return conexion!.Listar<MetodosPagos>();
        }

        public List<MetodosPagos> Buscar(Expression<Func<MetodosPagos, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public MetodosPagos Guardar(MetodosPagos entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public MetodosPagos Modificar(MetodosPagos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}