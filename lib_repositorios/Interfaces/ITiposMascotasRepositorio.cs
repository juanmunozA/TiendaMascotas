using lib_entidades;
    using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ITiposMascotasRepositorio
    {
        void Configurar(string string_conexion);
        List<TiposMascotas> Listar();
        List<TiposMascotas> Buscar(Expression<Func<TiposMascotas, bool>> condiciones);
        TiposMascotas Guardar(TiposMascotas entidad);
        TiposMascotas Modificar(TiposMascotas entidad);
        TiposMascotas Borrar(TiposMascotas entidad);
    }
}