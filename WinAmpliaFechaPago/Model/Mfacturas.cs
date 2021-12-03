using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinAmpliaFechaPago.Model
{
    class Mfacturas
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader ReadData;
        DataTable tabla = new DataTable();

        public DataTable BusqFacturas(string CriterioContacto, int Compania) //se muestra de manera masiva los responsables para el mantenimiento 
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OPCION", "SELECTFACTURAS");
            comando.Parameters.AddWithValue("@CRITERIOCONTACTO", CriterioContacto);
            comando.Parameters.AddWithValue("@COMPANIA", Compania);

            ReadData = comando.ExecuteReader();
            comando.Parameters.Clear();

            tabla.Load(ReadData);
            conexion.CerrarConexion();

            return tabla;

        }

        public void ActualizarExtFechas(string QnDoc,string CriterioContacto,int DiasExtension,string FechaAnterior,string FechaNueva,string Establecimiento,string Observacion,int Idusuario,int Compania)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_GEN_APP_C_SHARED";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OPCION", "UPDATEFACTURAS");
            comando.Parameters.AddWithValue("@QN_DOC", QnDoc);
            comando.Parameters.AddWithValue("@CRITERIOCONTACTO", CriterioContacto);
            comando.Parameters.AddWithValue("@DIASEXTENSION", DiasExtension);
            comando.Parameters.AddWithValue("@FECHANTERIOR", FechaAnterior);
            comando.Parameters.AddWithValue("@FECHANUEVA", FechaNueva);
            comando.Parameters.AddWithValue("@ESTABLECIMIENTO", Establecimiento);
            comando.Parameters.AddWithValue("@OBSERVACION", Observacion);
            comando.Parameters.AddWithValue("@USUARIO", Idusuario);
            comando.Parameters.AddWithValue("@COMPANIA", Compania);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
    }
}
