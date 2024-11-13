using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace lib_aplicaciones.Implementaciones
{
    public class MetodosPagosAplicacion : IMetodosPagosAplicacion
    {
        private IMetodosPagosRepositorio? iRepositorio = null;

        public MetodosPagosAplicacion(IMetodosPagosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Pago == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public MetodosPagos Guardar(MetodosPagos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Pago != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<MetodosPagos> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<MetodosPagos> Buscar(MetodosPagos entidad, string tipo)
        {
            Expression<Func<MetodosPagos, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "TIPO_PAGO": condiciones = x => x.Tipo_Pago!.Contains(entidad.Tipo_Pago!); break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Tipo_Pago!.Contains(entidad.Tipo_Pago!); break;
                default: condiciones = x => x.ID_Pago == entidad.ID_Pago; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public MetodosPagos Modificar(MetodosPagos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Pago == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
    