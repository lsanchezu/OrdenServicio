using Microsoft.AspNetCore.Http;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.Mvc.Helpers
{
    public static class SolicitudHelper
    {
        public static SolicitudOrdenServicioDto ObtenerDatosSolicitudOrdenServicio(SolicitudOrdenServicioViewModel oSolicitudOrdenServicioViewModel)
        {
            SolicitudOrdenServicioDto oSolicitudOrdenServicioDto = oSolicitudOrdenServicioViewModel.SolicitudOrdenServicio;

            oSolicitudOrdenServicioDto.ListaSolicitudDocumentoDto.ForEach(x =>
            {
                if (x.TipoDocumentoDto.IdTipoDocumento == 1)
                {
                    x.ListaSolicitudArchivoAdjuntoDto = ObtenerDatosArchivo(oSolicitudOrdenServicioViewModel.ListaArchivo_TipoDocumento_1, x.TipoDocumentoDto.Descripcion);
                }
                else if (x.TipoDocumentoDto.IdTipoDocumento == 2)
                {
                    x.ListaSolicitudArchivoAdjuntoDto = ObtenerDatosArchivo(oSolicitudOrdenServicioViewModel.ListaArchivo_TipoDocumento_2, x.TipoDocumentoDto.Descripcion);
                }
                else if (x.TipoDocumentoDto.IdTipoDocumento == 3)
                {
                    x.ListaSolicitudArchivoAdjuntoDto = ObtenerDatosArchivo(oSolicitudOrdenServicioViewModel.ListaArchivo_TipoDocumento_3, x.TipoDocumentoDto.Descripcion);
                }
                else if (x.TipoDocumentoDto.IdTipoDocumento == 4)
                {
                    x.ListaSolicitudArchivoAdjuntoDto = ObtenerDatosArchivo(oSolicitudOrdenServicioViewModel.ListaArchivo_TipoDocumento_4, x.TipoDocumentoDto.Descripcion);
                }
                else
                {
                    x.ListaSolicitudArchivoAdjuntoDto = new ListaSolicitudArchivoAdjuntoDto();
                }
            });

            return oSolicitudOrdenServicioDto;
        }

        private static ListaSolicitudArchivoAdjuntoDto ObtenerDatosArchivo(List<IFormFile> listaArchivo, string tipoDocumento)
        {
            ListaSolicitudArchivoAdjuntoDto oListaSolicitudArchivoAdjuntoDto = new ListaSolicitudArchivoAdjuntoDto();

            if (listaArchivo != null)
            {
                listaArchivo.ForEach(x =>
                {
                    oListaSolicitudArchivoAdjuntoDto.Add(ObtenerDatosArchivo(x, tipoDocumento));
                });
            }
            
            return oListaSolicitudArchivoAdjuntoDto;
        }

        private static SolicitudArchivoAdjuntoDto ObtenerDatosArchivo(IFormFile oIFormFile, string tipoDocumento)
        {
            SolicitudArchivoAdjuntoDto oSolicitudArchivoAdjuntoDto = new SolicitudArchivoAdjuntoDto();

            using (var binaryReader = new BinaryReader(oIFormFile.OpenReadStream()))
            {
                oSolicitudArchivoAdjuntoDto.Contenido = binaryReader.ReadBytes((int)oIFormFile.Length);
                oSolicitudArchivoAdjuntoDto.TipoContenido = oIFormFile.ContentType;
                oSolicitudArchivoAdjuntoDto.Tamanio = (int)oIFormFile.Length;
                oSolicitudArchivoAdjuntoDto.NombreArchivo = oIFormFile.FileName;
                oSolicitudArchivoAdjuntoDto.Directorio = $"{Constantes.Ruta_Adjunto}/{tipoDocumento}";
                oSolicitudArchivoAdjuntoDto.Extension = oSolicitudArchivoAdjuntoDto.NombreArchivo.Substring(oSolicitudArchivoAdjuntoDto.NombreArchivo.LastIndexOf('.')).ToLower();
            }

            return oSolicitudArchivoAdjuntoDto;
        }

        public static  List<string> ObtenerColumnaExportarPorSolicitud()
        {
            List<string> listaColumna = new List<string>
            {
                SolicitudExport.NumeroSolicitud,
                SolicitudExport.Compania,
                SolicitudExport.FuenteContrato,
                SolicitudExport.Proyecto,
                SolicitudExport.Solicitante,
                SolicitudExport.FaseProyecto,
                SolicitudExport.AreaFuncional,
                SolicitudExport.FechaSolicitud,
                SolicitudExport.Categoria,
                SolicitudExport.TipoSolicitud,
                SolicitudExport.Moneda,
                SolicitudExport.MontoEstimado,
                SolicitudExport.FechaInicio,
                SolicitudExport.FechaTermino,
                SolicitudExport.DiasCalendario,
                SolicitudExport.DenominacionServicio,
                SolicitudExport.UbicacionServicio,
                SolicitudExport.DenominacionSocial,
                SolicitudExport.UsuarioValidacion,
                SolicitudExport.Grafo,
                SolicitudExport.EstadoValidacion,
                SolicitudExport.FechaValidacion,
                SolicitudExport.UsuarioRecomendacion,
                SolicitudExport.EstadoRecomendacion,
                SolicitudExport.FechaRecomendacion,
                SolicitudExport.UsuarioAutorizacionAreaFuncional,
                SolicitudExport.EstadoAutorizacionAreaFuncional,
                SolicitudExport.FechaAutorizacionAreaFuncional,
                SolicitudExport.UsuarioAutorizacionGerenteProyecto,
                SolicitudExport.EstadoAutorizacionGerenteProyecto,
                SolicitudExport.FechaAutorizacionGerenteProyecto,
                SolicitudExport.UsuarioAutorizacionGerenteCorporativo,
                SolicitudExport.EstadoAutorizacionGerenteCorporativo,
                SolicitudExport.FechaAutorizacionGerenteCorporativo,
                SolicitudExport.EstadoSolicitud
            };

            return listaColumna;
        }


        public static List<string> ObtenerColumnaExportarPorProveedor()
        {
            List<string> listaColumna = new List<string>
            {
                
                SolicitudExport.Ruc,
                SolicitudExport.DenominacionSocial,
                SolicitudExport.NumeroSolicitud,
                SolicitudExport.Compania,
                SolicitudExport.FuenteContrato,
                SolicitudExport.Proyecto,
                SolicitudExport.Solicitante,
                SolicitudExport.FaseProyecto,
                SolicitudExport.AreaFuncional,
                SolicitudExport.FechaSolicitud,
                SolicitudExport.Categoria,
                SolicitudExport.TipoSolicitud,
                SolicitudExport.UsuarioValidacion,
                SolicitudExport.EstadoValidacion,
                SolicitudExport.UsuarioRecomendacion,
                SolicitudExport.EstadoRecomendacion,
                SolicitudExport.UsuarioAutorizacionAreaFuncional,
                SolicitudExport.EstadoAutorizacionAreaFuncional,
                SolicitudExport.UsuarioAutorizacionGerenteProyecto,
                SolicitudExport.EstadoAutorizacionGerenteProyecto,
                SolicitudExport.UsuarioAutorizacionGerenteCorporativo,
                SolicitudExport.EstadoAutorizacionGerenteCorporativo,
                SolicitudExport.EstadoSolicitud
            };

            return listaColumna;
        }
    }
}
