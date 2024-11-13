using lib_entidades;
    using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ITiposServiciosRepositorio
    {
        void Configurar(string string_conexion);
        List<TiposServicios> Listar();
        List<TiposServicios> Buscar(Expression<Func<TiposServicios, bool>> condiciones);
        TiposServicios Guardar(TiposServicios entidad);
        TiposServicios Modificar(TiposServicios entidad);
        TiposServicios Borrar(TiposServicios entidad);
    }
}