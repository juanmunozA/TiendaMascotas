using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class TiposMascotasAplicacion : ITiposMascotasAplicacion
    {
        private ITiposMascotasRepositorio? iRepositorio = null;

        public TiposMascotasAplicacion(ITiposMascotasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public TiposMascotas Borrar(TiposMascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota == 0)  // Cambié 'IdCliente' por 'Mascota'
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public TiposMascotas Guardar(TiposMascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota != 0)  // Cambié 'IdCliente' por 'Mascota'
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<TiposMascotas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<TiposMascotas> Buscar(TiposMascotas entidad, string tipo)
        {
            Expression<Func<TiposMascotas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "TIPODEMASCOTA":
                    condiciones = x => x.TipoDeMascota!.Contains(entidad.TipoDeMascota!);
                    break;
                case "MASCOTA":
                    condiciones = x => x.Mascota == entidad.Mascota;
                    break;
                case "COMPLEJA":
                    condiciones = x => x.TipoDeMascota!.Contains(entidad.TipoDeMascota!) ||
                                        x.Mascota == entidad.Mascota;
                    break;
                default:
                    condiciones = x => x.Mascota == entidad.Mascota;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public TiposMascotas Modificar(TiposMascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota == 0)  // Cambié 'IdCliente' por 'Mascota'
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
