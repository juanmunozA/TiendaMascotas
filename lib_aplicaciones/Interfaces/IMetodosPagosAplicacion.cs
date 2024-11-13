using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodosPagosAplicacion
    {
        void Configurar(string string_conexion);
        List<MetodosPagos> Buscar(MetodosPagos entidad, string tipo);
        List<MetodosPagos> Listar();
        MetodosPagos Guardar(MetodosPagos entidad);
        MetodosPagos Modificar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad);
    }
}