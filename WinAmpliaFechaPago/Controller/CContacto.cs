using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAmpliaFechaPago.Model;

namespace WinAmpliaFechaPago.Controller
{
    class CContacto
    {
        MContacto MContacto = new MContacto();
        public DataTable MostrarContactos(int Compania)
        {
            DataTable tabla = new DataTable();
            tabla = MContacto.MostrarContactos(Compania);
            return tabla;
        }

        public DataTable BusqContactos(string CriterioNombre, int Compania)
        {
            DataTable tabla = new DataTable();
            tabla = MContacto.BusqContactos(CriterioNombre,Compania);
            return tabla;
        }
        
    }
}
