using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class TiposServiciosAplicacion : ITiposServiciosAplicacion
    {
        private ITiposServiciosRepositorio? iRepositorio = null;

        public TiposServiciosAplicacion(ITiposServiciosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public TiposServicios Borrar(TiposServicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDTipoServicio == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public TiposServicios Guardar(TiposServicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDTipoServicio != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<TiposServicios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<TiposServicios> Buscar(TiposServicios entidad, string tipo)
        {
            Expression<Func<TiposServicios, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "IDTIPOSERVICIO":
                    condiciones = x => x.IDTipoServicio == entidad.IDTipoServicio;
                    break;
                case "TIPOSERVICIO":
                    condiciones = x => x.TipoServicio!.Contains(entidad.TipoServicio!);
                    break;
                case "COMPLEJA":
                    condiciones = x => x.IDTipoServicio == entidad.IDTipoServicio ||
                                        x.TipoServicio!.Contains(entidad.TipoServicio!);
                    break;
                default:
                    condiciones = x => x.IDTipoServicio == entidad.IDTipoServicio;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public TiposServicios Modificar(TiposServicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.IDTipoServicio == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
