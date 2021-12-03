using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAmpliacionPagos
{
    static class Program
    {
        public static string _StringDataSource;
        public static string _StringUser;
        public static string _StringPass;
        public static string _StringDb;
        public static string _IdEmpresa;
        public static string _IdUser;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            string IdEmpresa;
            string IdUser;
            string StringDataSource;
            string StringUser;
            string StringPass;
            string StringDb;
            string StringConexion;
            char[] delimit = new char[] { '|' };
            char[] delimit2 = new char[] { ';' };

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {

                string Parametro = args[0]; ;

                IdEmpresa = Parametro.Split(delimit).ElementAt(0);      //IdEmpresa
                IdUser = Parametro.Split(delimit).ElementAt(1);      //IdUser
                StringConexion = Parametro.Split(delimit).ElementAt(2);     //String de Conexion


                StringDataSource = StringConexion.Split(delimit2).ElementAt(1);
                StringUser = StringConexion.Split(delimit2).ElementAt(2);
                StringPass = StringConexion.Split(delimit2).ElementAt(3);
                StringDb = StringConexion.Split(delimit2).ElementAt(5);
            }
            else
            {
                string Parametro = "3|1|Provider=SQLOLEDB.1;Data Source =192.168.17.120; User ID=sa; Password=TICd3v3l0p3r;Persist Security Info=True;DataBase=Saljuper|0|RETAIL";


                IdEmpresa = Parametro.Split(delimit).ElementAt(0);      //IdEmpresa
                IdUser = Parametro.Split(delimit).ElementAt(1);      //IdUser
                StringConexion = Parametro.Split(delimit).ElementAt(2);     //String de Conexion


                StringDataSource = StringConexion.Split(delimit2).ElementAt(1);
                StringUser = StringConexion.Split(delimit2).ElementAt(2);
                StringPass = StringConexion.Split(delimit2).ElementAt(3);
                StringDb = StringConexion.Split(delimit2).ElementAt(5);

            }

            _StringDataSource = StringDataSource;
            _StringUser = StringUser;
            _StringPass = StringPass;
            _StringDb = StringDb;
            _IdEmpresa = IdEmpresa;      //IdEmpresa
            _IdUser = IdUser;      //IdUser

            Application.Run(new AmpliarFecha());
        }
    }
}
