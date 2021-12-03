using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinReportExt.Model;
using WinReportExt.Controller;
using WinReportExt.View;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.Globalization;

namespace WinReportExt
{
    public partial class Form1 : Form
    {

        public List<Cabecera> Cabecera = new List<Cabecera>();
        public List<MMovlog>  Detail   = new List<MMovlog>();
        //List<MMovlog> Mmovlog = new List<MMovlog>();

        private string Cliente;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CultureInfo Culture = new CultureInfo("en-US");

            string FechaInicio  = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string FechaFin     = dateTimePicker2.Value.ToString("dd/MM/yyyy");

            Program._Desde = " Desde: " + this.dateTimePicker1.Text;
            Program._Hasta = " Hasta: " + this.dateTimePicker2.Text;
            Program._FechaEmision = DateTime.Now.ToLongDateString() + " "+ DateTime.Now.ToLongTimeString();

            //DateTime DateFechaInicio = DateTime.ParseExact(FechaInicio, "dd/mm/yyyy",null);
            //DateTime DateFechaFinal = DateTime.ParseExact(FechaFin, "dd/mm/yyyy", null);


            //   .ToLongDateString();
            //.ToLongString();//DateTime.Now.Date.ToString();
            DataeGenerate();
            //FrmVisor frmVisor = new FrmVisor();
            //frmVisor.ShowDialog();
           /* 
            SqlDataReader Rd;
            CDataSet CDataSet = new CDataSet();
            Rd = CDataSet.MostrarHistorial();
            while (Rd.Read())
            {
                
                MMovlog itemMov = new MMovlog
                {
                    CodCia          = Rd["CodCia"].ToString(),
                    Compania        = Rd["Compania"].ToString(),
                    Establecimiento = Rd["Establecimiento"].ToString(),
                    Documento       = Rd["Documento"].ToString(),
                    FechaOriginal   = Rd["FechaOriginal"].ToString(),
                    FechaExtendida  = Rd["FechaExtendida"].ToString(),
                    DiasExtendidos  = Rd["DiasExtendidos"].ToString(),
                    CodContacto     = Rd["CodContacto"].ToString(),
                    Cliente         = Rd["Cliente"].ToString(),
                    UsuarioEjecuto  = Rd["UsuarioEjecuto"].ToString(),
                    Observacion     = Rd["Observacion"].ToString(),
                    Workstation     = Rd["Workstation"].ToString()
                };
                   Detail.Add(itemMov);
                   this.Cliente = Rd["Cliente"].ToString();
            }
                  Rd.Close();
                  FrmVisor FrmVisor = new FrmVisor();
                  FrmVisor.ShowDialog();

            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label3.Text = Program._Parametro;
            //DateTimerPicker.CustomFormat = "dd/MMM/yyyy";
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void DataeGenerate()
        {
            Cabecera Encabezado = new Cabecera();
            Encabezado.Titulo = "Prueba de Titulo";
            Encabezado.FechaInicio = "Fecha1";
            Encabezado.FechaFin = "Fecha2";
            SqlDataReader Rd;
            CDataSet CDataSet = new CDataSet();
            string fechaInicio = this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string fechaFinal =  this.dateTimePicker2.Value.ToString("dd/MM/yyyy");
            Rd = CDataSet.MostrarHistorial(fechaInicio, fechaFinal);
            while (Rd.Read())
            {

                MMovlog itemMov = new MMovlog
                {
                    CodCia = Rd["CodCia"].ToString(),
                    Compania = Rd["Compania"].ToString(),
                    Establecimiento = Rd["Establecimiento"].ToString(),
                    Documento = Rd["Documento"].ToString(),
                    FechaOriginal = Rd["FechaOriginal"].ToString(),
                    FechaExtendida = Rd["FechaExtendida"].ToString(),
                    DiasExtendidos = Rd["DiasExtendidos"].ToString(),
                    CodContacto = Rd["CodContacto"].ToString(),
                    Cliente = Rd["Cliente"].ToString(),
                    UsuarioEjecuto = Rd["UsuarioEjecuto"].ToString(),
                    Observacion = Rd["Observacion"].ToString(),
                    FechaExtension = Rd["FechaExtension"].ToString(),
                    Workstation = Rd["Workstation"].ToString()
                };

                Encabezado.Detalle.Add(itemMov);
            }
            Rd.Close();
            
            Rd = CDataSet.MostrarDatosGenerales();
            while (Rd.Read())
            {
               Program._UserCurrent = Rd["nom_usuario"].ToString();
               Program._PcCurrent   = Rd["PcActual"].ToString();
               Program._CurrentDate = Rd["FechaActual"].ToString();
            }

            Rd.Close();

            FrmVisor frmVisor = new FrmVisor();
            frmVisor.Encabezado.Add(Encabezado);
            frmVisor.Detail = Encabezado.Detalle;
            frmVisor.Show();
        }

        /*
        public static List<MMovlog> FillDgv()
        {
            List<MMovlog> Detalle = new List<MMovlog>();
            SqlDataReader Rd;
            CDataSet CDataSet = new CDataSet();
            string fechaInicio = dateTimePicker1.Text;
            string fechaFinal = dateTimePicker2.Text;
            Rd = CDataSet.MostrarHistorial(fechaInicio, fechaFinal);
            while (Rd.Read())
            {

                MMovlog itemMov = new MMovlog
                {
                    CodCia = Rd["CodCia"].ToString(),
                    Compania = Rd["Compania"].ToString(),
                    Establecimiento = Rd["Establecimiento"].ToString(),
                    Documento = Rd["Documento"].ToString(),
                    FechaOriginal = Rd["FechaOriginal"].ToString(),
                    FechaExtendida = Rd["FechaExtendida"].ToString(),
                    DiasExtendidos = Rd["DiasExtendidos"].ToString(),
                    CodContacto = Rd["CodContacto"].ToString(),
                    Cliente = Rd["Cliente"].ToString(),
                    UsuarioEjecuto = Rd["UsuarioEjecuto"].ToString(),
                    Observacion = Rd["Observacion"].ToString(),
                    Workstation = Rd["Workstation"].ToString()
                };
                
                Detalle.Add(itemMov);
                //Detail.Add(itemMov);
                //this.Cliente = Rd["Cliente"].ToString();
            }
              Rd.Close();

            return Detalle;
        }*/


    }
            
}
