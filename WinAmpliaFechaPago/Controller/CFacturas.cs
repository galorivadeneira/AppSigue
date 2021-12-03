using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WinAmpliaFechaPago.Model;

namespace WinAmpliaFechaPago.Controller
{
    class CFacturas
    {
        Mfacturas Mfacturas = new Mfacturas();
        public DataTable BusqFacturas(string CriterioContacto,int Compania)
        {
            DataTable tabla = new DataTable();
            tabla = Mfacturas.BusqFacturas(CriterioContacto, Compania);
            return tabla;
        }

        public void ActualizarExtFechas(string QnDoc, string CriterioContacto, int DiasExtension, string FechaAnterior, string FechaNueva, string Establecimiento, string Observacion,int IdUsuario,int Compania)
        {
            Mfacturas.ActualizarExtFechas(QnDoc,CriterioContacto,DiasExtension,FechaAnterior,FechaNueva,Establecimiento, Observacion, IdUsuario, Compania);
        }
    }
}
