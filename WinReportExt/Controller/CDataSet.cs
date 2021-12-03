using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinReportExt.Model;

namespace WinReportExt.Controller
{
    class CDataSet
    {
        MDataSet MDataSet = new MDataSet();
        public SqlDataReader MostrarHistorial(string FechaIni, string FechaFin) //se muestra de manera masiva las Marcas de los activos 
        {
            SqlDataReader ReadData;
            ReadData = MDataSet.MostrarHistorial(FechaIni, FechaFin);
            return ReadData;
        }

        public SqlDataReader MostrarDatosGenerales() //se muestra de manera masiva las Marcas de los activos 
        {
            SqlDataReader ReadData;
            ReadData = MDataSet.MostrarDatosGenerales();
            return ReadData;
        }

       
    }
}
