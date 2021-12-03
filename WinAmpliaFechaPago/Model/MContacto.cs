using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAmpliaFechaPago.Model
{
    class MContacto
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader ReadData;
        DataTable tabla = new DataTable();

        public DataTable MostrarContactos(int Compania) //se muestra de manera masiva los responsables para el mantenimiento 
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OPCION", "SELECTCONTACTO");
            comando.Parameters.AddWithValue("@COMPANIA", Compania);
            
            ReadData = comando.ExecuteReader();
            comando.Parameters.Clear();

            tabla.Load(ReadData);
            conexion.CerrarConexion();

            return tabla;

        }

        public DataTable BusqContactos(string CriterioNombre, int Compania) //se muestra de manera masiva los responsables para el mantenimiento 
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OPCION", "SELECTCONTACTO");
            comando.Parameters.AddWithValue("@CRITERIONOMBRE", CriterioNombre);
            comando.Parameters.AddWithValue("@COMPANIA", Compania);

            ReadData = comando.ExecuteReader();
            comando.Parameters.Clear();

            tabla.Load(ReadData);
            conexion.CerrarConexion();

            return tabla;

        }

    }
}
