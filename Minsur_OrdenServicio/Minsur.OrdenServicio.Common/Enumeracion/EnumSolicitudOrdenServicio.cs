using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Common.Enumeracion
{
    public class EnumSolicitudOrdenServicio
    {
        public enum EmailParametro
        {
            ValidacionSolicitud = 1,
            RecomedacionSolicitud  = 2,
            AutorizacionSolicitud = 3,
            AprobacionSolicitud = 4,
            RechazoSolicitud = 5
        }

        public enum EstadoSolicitud
        {
            EnProceso = 3,
            Aprobado = 4,
            Rechazado = 5
        }

        public enum EstadoRecomendacion
        {
            Recomienda = 6,
            NoRecomienda = 7
        }

        public enum EstadoValidacion
        {
            Validado = 8,
            NoValidado = 9
        }

        public enum GrupoEstado
        {
            Generales = 1,
            Solicitud = 2
        }

        public enum RolUsuario
        {
            Solicitante = 36,
            EncargadoAreaControlProyecto = 37,
            EncargadoAreaContrato = 38,
            GerenteArea = 39,
            GerenteProyecto = 40,
            GerenteCorporativo = 41
        }

        public enum FuenteContrato
        {
            Sole_Source = 3
        }

        public enum Gobernanza
        {
            GerenteArea = 1,
            GerenteProyecto = 2,
            GerenteCorporativo = 3
        }
    }
}
