using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.ViewModels
{
    public class DetallesTipoNominaModel
    {
        public string Nombre { get; set; }
        public bool TieneRetencion { get; set; }
        public bool EsPorUnidad { get; set; }
        public double Precio { get; set; }
    }
}
