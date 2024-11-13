using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ITiposMascotasAplicacion
    {
        void Configurar(string string_conexion);
        List<TiposMascotas> Buscar(TiposMascotas entidad, string tipo);
        List<TiposMascotas> Listar();
        TiposMascotas Guardar(TiposMascotas entidad);
        TiposMascotas Modificar(TiposMascotas entidad);
        TiposMascotas Borrar(TiposMascotas entidad);
    }
}