using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ITipos_MascotasAplicacion
    {
        void Configurar(string string_conexion);
        List<Clientes> Buscar(Clientes entidad, string tipo);
        List<Clientes> Listar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}