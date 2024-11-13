using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ITiposServiciosAplicacion
    {
        void Configurar(string string_conexion);
        List<TiposServicios> Buscar(TiposServicios entidad, string tipo);
        List<TiposServicios> Listar();
        TiposServicios Guardar(TiposServicios entidad);
        TiposServicios Modificar(TiposServicios entidad);
        TiposServicios Borrar(TiposServicios entidad);
    }
}