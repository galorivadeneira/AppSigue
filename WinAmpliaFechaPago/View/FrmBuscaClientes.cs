using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAmpliaFechaPago.Controller;
using WinAmpliaFechaPago.Librerias;

namespace WinAmpliaFechaPago.View
{
    public partial class FrmBuscaClientes : Form
    {
        string CriterioNombre;
        string CodeId;
        string Name;
        string Criterio_sp;
        int Compania = Convert.ToInt32(Program._IdEmpresa);
        private Form FormPadre;

        AmpliacionFechaPago FrmPadre = new AmpliacionFechaPago();

        public FrmBuscaClientes(AmpliacionFechaPago FrmPadre)
        {
            this.FormPadre = FrmPadre;
            InitializeComponent();
        }

        public FrmBuscaClientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CaptureData();
            //this.Close();
        }

        private void FrmBuscaClientes_Load(object sender, EventArgs e)
        {
            MostrarContactos();
            MostrarCeldas();
        }
        
        public void  MostrarContactos()
        {
            
            CContacto CContacto = new CContacto();
            DgFacturas.DataSource = CContacto.MostrarContactos(this.Compania);
        }
        public void MostrarCeldas()
        {
            DgFacturas.Columns["cx_cia"].Visible = false;
            DgFacturas.Columns["cx_cia"].DisplayIndex = 0;

            DgFacturas.Columns["IdContacto"].Visible = true;
            DgFacturas.Columns["IdContacto"].DisplayIndex = 2;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.CriterioNombre = this.txtBusqueda.Text.Trim();
            CContacto CContacto = new CContacto();
            DgFacturas.DataSource = CContacto.BusqContactos(this.CriterioNombre, this.Compania);
        }

        private void btnSelecciona_Click(object sender, EventArgs e)
        {
            CaptureData();
            //FrmPadre.MostrarFacturas(this.CodeId);
            this.Close();
        }

        private void CaptureData()
        {
            this.CodeId = DgFacturas.CurrentRow.Cells["IdContacto"].Value.ToString();
            this.Name = DgFacturas.CurrentRow.Cells["NombreContacto"].Value.ToString();
            EjecutaInterfaz();
        }

        private void EjecutaInterfaz()
        {
            Interface1 miInterfaz = FormPadre as Interface1;
            
            if (miInterfaz != null)
            {
                miInterfaz.cambiarTexto(this.Name, this.Criterio_sp, this.CodeId);
                this.Dispose();
            }

        }

        private void DgFacturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CaptureData();
            //this.Close();
        }

        private void DgFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CaptureData();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
