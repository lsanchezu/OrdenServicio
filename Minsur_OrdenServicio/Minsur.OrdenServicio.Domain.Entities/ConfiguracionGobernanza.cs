using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class ConfiguracionGobernanza
    {
        public int IdConfiguracionGobernanza { get; set; }
        public int IdEstado { get; set; }
        public bool FlagApruebaSolicitud { get; set; }
        public Gobernanza Gobernanza { get; set; }

        public void SetearFlagApruebaSolicitud(int maximoOrden)
        {
            FlagApruebaSolicitud = Gobernanza.Orden == maximoOrden;
        }


    }
    public class ListaConfiguracionGobernanza: List<ConfiguracionGobernanza> { }
}
