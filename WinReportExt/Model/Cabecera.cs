using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinReportExt.Model
{
    public class Cabecera
    {
        public string Titulo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin  { get; set; }

        public List<MMovlog> Detalle = new List<MMovlog>();
    }
}
