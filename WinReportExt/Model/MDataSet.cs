using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinReportExt.Model
{
    class MDataSet
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader ReadData;

        public SqlDataReader MostrarHistorial(string FechaIni,string FechaFin) 
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@opcion", "SELECCIONAHISTORIAL");
            comando.Parameters.AddWithValue("@FechaIni", FechaIni);
            comando.Parameters.AddWithValue("@FechaFin", FechaFin);

            ReadData = comando.ExecuteReader();
            comando.Parameters.Clear();

            return ReadData;

        }

        public SqlDataReader MostrarDatosGenerales()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@opcion", "OBTIENEDATOSGEN");
            comando.Parameters.AddWithValue("@cx_usr", Program._IdUser);
            

            ReadData = comando.ExecuteReader();
            comando.Parameters.Clear();

            return ReadData;

        }


    }
}
