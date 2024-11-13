using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IFacturasRepositorio? iRepositorio = null;

        public FacturasAplicacion(IFacturasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDFactura == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDFactura != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Facturas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Facturas> Buscar(Facturas entidad, string tipo)
        {
            Expression<Func<Facturas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "IDFACTURA":
                    condiciones = x => x.IDFactura == entidad.IDFactura;
                    break;
                case "CODIGOFACTURA":
                    condiciones = x => x.CodigoFactura!.Contains(entidad.CodigoFactura!);
                    break;
                case "COMPLEJA":
                    condiciones = x => x.CodigoFactura!.Contains(entidad.CodigoFactura!) ||
                                        x.IDFactura == entidad.IDFactura;
                    break;
                default:
                    condiciones = x => x.IDFactura == entidad.IDFactura;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Facturas Modificar(Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDFactura == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}





















