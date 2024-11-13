using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodo_pagoAplicacion
    {
        void Configurar(string string_conexion);
        List<Metodo_pago> Buscar(Metodo_pago entidad, string tipo);
        List<Metodo_pago> Listar();
        Metodo_pago Guardar(Metodo_pago entidad);
        Metodo_pago Modificar(Metodo_pago entidad);
        Metodo_pago Borrar(Metodo_pago entidad);
    }
}