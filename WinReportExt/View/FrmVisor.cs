using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinReportExt.Model;

namespace WinReportExt.View
{
    public partial class FrmVisor : Form
    {
        string Titulo = "Reporte de Extension de Fechas Vencimiento a Documentos";
        public List<Cabecera> Encabezado = new List<Cabecera>();
        public List<MMovlog> Detail = new List<MMovlog>();
        public FrmVisor()
        {
            InitializeComponent();
        }

        
        private void FrmVisor_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("ParamTitulo", Titulo);
            parameters[1] = new ReportParameter("ParamDesde", Program._Desde);
            parameters[2] = new ReportParameter("ParamHasta", Program._Hasta);
            parameters[3] = new ReportParameter("ParamFechEmision", Program._FechaEmision);
            parameters[4] = new ReportParameter("ParamUserCurrent", "Usuario: " + Program._UserCurrent);
            parameters[5] = new ReportParameter("ParamPcCurrent", "Estacion de Trabajo: " + Program._PcCurrent);
            parameters[6] = new ReportParameter("ParamDateCurrent", "Fecha: " + Program._CurrentDate);

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Cabecera", Encabezado));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detail));
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
             
        }
    }
}
