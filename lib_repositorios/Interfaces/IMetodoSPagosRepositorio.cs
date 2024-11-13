using lib_entidades;
    using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IMetodosPagosRepositorio
    {
        void Configurar(string string_conexion);
        List<MetodosPagos> Listar();
        List<MetodosPagos> Buscar(Expression<Func<MetodosPagos, bool>> condiciones);
        MetodosPagos Guardar(MetodosPagos entidad);
        MetodosPagos Modificar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad);
    }
}