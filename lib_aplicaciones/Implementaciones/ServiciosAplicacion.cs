﻿using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IServiciosRepositorio? iRepositorio = null;

        public ServiciosAplicacion(IServiciosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Servicios Borrar(Servicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota == 0) 
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Servicios Guardar(Servicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota != 0) 
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Servicios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Servicios> Buscar(Servicios entidad, string tipo)
        {
            Expression<Func<Servicios, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "PRECIO": condiciones = x => x.Precio == entidad.Precio; break;
                case "ESTADO": condiciones = x => x.Estado == entidad.Estado; break;
                case "MASCOTA": condiciones = x => x.Mascota == entidad.Mascota; break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Precio == entidad.Precio ||
                             x.Estado == entidad.Estado ||
                             x.Mascota == entidad.Mascota; break;
                default: condiciones = x => x.Mascota == entidad.Mascota; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Servicios Modificar(Servicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Mascota == 0) // Verificar si el atributo Mascota es válido
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
