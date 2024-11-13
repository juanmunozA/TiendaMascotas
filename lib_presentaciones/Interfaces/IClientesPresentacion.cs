using lib_entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesPresentacion
    {
        Task<List<Clientes>> Listar();
        Task<List<Clientes>> Buscar(Clientes entidad, string tipo);
        Task<Clientes> Guardar(Clientes entidad);
        Task<Clientes> Modificar(Clientes entidad);
        Task<Clientes> Borrar(Clientes entidad);
    }
}