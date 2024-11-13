﻿using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class MascotasAplicacion : IMascotasAplicacion
    {
        private IMascotasRepositorio? iRepositorio = null;

        public MascotasAplicacion(IMascotasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Mascotas Borrar(Mascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Mascota == 0)  // Corregido a ID_Mascota
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Mascotas Guardar(Mascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Mascota != 0)  // Corregido a ID_Mascota
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Mascotas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Mascotas> Buscar(Mascotas entidad, string tipo)
        {
            Expression<Func<Mascotas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE":
                    condiciones = x => x.Nombre!.Contains(entidad.Nombre!);
                    break;

                case "GENERO":
                    condiciones = x => x.Genero!.Contains(entidad.Genero!);
                    break;

                case "COMPLEJA":
                    condiciones = x =>
                        x.Nombre!.Contains(entidad.Nombre!) ||
                        x.Genero!.Contains(entidad.Genero!);
                    break;

                default:
                    condiciones = x => x.Dueño == entidad.Dueño;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Mascotas Modificar(Mascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID_Mascota == 0)  // Corregido a ID_Mascota
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
