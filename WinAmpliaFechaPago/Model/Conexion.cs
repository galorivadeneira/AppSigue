using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAmpliaFechaPago.Model
{
    class Conexion
    {
        SqlConnection conexion = null;

        public Conexion(string Conexion)
        {
            string connectionstring = Conexion;
            this.conexion = new SqlConnection(connectionstring);
        }

        public Conexion()
        {
            string connectionstring = GetConnectionString();
            this.conexion = new SqlConnection(connectionstring);
        }


        static private string GetConnectionString()
        {
            string StringConexion = Program._StringDataSource + ";" + Program._StringDb + ";" + Program._StringUser + ";" + Program._StringPass;
            StringConexion = StringConexion.Replace("DataBase", "Initial Catalog");
            return StringConexion;
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }


    }
}
