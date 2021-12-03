using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAmpliaFechaPago.Librerias;
using WinAmpliaFechaPago.View;
using WinAmpliaFechaPago.Controller;

namespace WinAmpliaFechaPago
{
    public partial class AmpliacionFechaPago : Form,Interface1
    {
        int Compania = Convert.ToInt32(Program._IdEmpresa);

        public AmpliacionFechaPago()
        {
            InitializeComponent();
        }

        public interface Interfase1
        {
            void ChangeTextBoxText(string text);
            void cambiarTexto(string name, string criterio);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBuscaClientes FrmBuscaClientes = new FrmBuscaClientes(this);
            FrmBuscaClientes.ShowDialog();
        }

        private void grpContacto_Enter(object sender, EventArgs e)
        {
            
        }

        public void cambiarTexto(string Descripcion, string criterio, string CodeId = null)
        {
            this.txtCodigo.Text = CodeId;
            this.txtNombre.Text = Descripcion;
            MostrarFacturas(this.txtCodigo.Text);
            habilitar_controles_one();
            this.txtObservaciones.Text = "AMPLIACION AUTORIZADA X CLIENTE";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AmpliacionFechaPago_Load(object sender, EventArgs e)
        {
            this.label4.Text = Program._Parametro;
            string MesAnterior = DateTime.Now.AddMonths(-1).ToString("MM");

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //BuscaClienteCodAux();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MostrarFacturas(string CriterioContacto)
        {
            CFacturas CFacturas = new CFacturas();
            DgFacturas.DataSource = CFacturas.BusqFacturas(CriterioContacto, this.Compania);
            MostrarColumnas();

        }
        public void MostrarColumnas()
        {
            DgFacturas.ReadOnly = false;
            DgFacturas.Columns["ColSelecciona"].Visible = true;
            DgFacturas.Columns["ColResultado"].Visible = true;
            DgFacturas.Columns["ColSelecciona"].ReadOnly = false;
            DgFacturas.Columns["Establecimiento"].ReadOnly = true;
            DgFacturas.Columns["Documento"].ReadOnly = true;
            DgFacturas.Columns["Observacion"].ReadOnly = true;
            DgFacturas.Columns["Valor"].ReadOnly = true;
            DgFacturas.Columns["Cobros"].ReadOnly = true;
            DgFacturas.Columns["Saldo"].ReadOnly = true;
            DgFacturas.Columns["FechaEmision"].ReadOnly = true;
            DgFacturas.Columns["FechaVencimiento"].ReadOnly = true;
            DgFacturas.Columns["ColResultado"].ReadOnly = true;

            
            DgFacturas.Columns["ColSelecciona"].DisplayIndex = 0;
            DgFacturas.Columns["Establecimiento"].DisplayIndex = 1;
            DgFacturas.Columns["Documento"].DisplayIndex = 2;
            DgFacturas.Columns["Observacion"].DisplayIndex = 3;
            DgFacturas.Columns["Valor"].DisplayIndex = 4;
            DgFacturas.Columns["Cobros"].DisplayIndex = 5;
            DgFacturas.Columns["Saldo"].DisplayIndex = 6;
            DgFacturas.Columns["FechaEmision"].DisplayIndex = 7;
            DgFacturas.Columns["FechaVencimiento"].DisplayIndex = 8;
            DgFacturas.Columns["ColResultado"].DisplayIndex = 9;

            

        }

        

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            AplicarDias();
        }
        public void SeleccionaGrid(string Action)
        {
            foreach (DataGridViewRow row in DgFacturas.Rows)
            {
                if (Action=="SELECCIONATODO")
                {
                    row.Cells["ColSelecciona"].Value = true;
                }

                if (Action == "DESSELECCIONA")
                {
                    row.Cells["ColSelecciona"].Value = false;
                }

            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            AplicarDias();
        }

        private void AplicarDias()
        {
            int DiasExtendidos = Convert.ToInt32(this.numericUpDown1.Value);
            int Diaseleccionados = 0;
            string Observaciones = this.txtObservaciones.Text.Trim();
            //Valida los dias de extension

            if (DiasExtendidos > 0) {
                foreach (DataGridViewRow row in DgFacturas.Rows)
                {
                
                         var usCulture = new System.Globalization.CultureInfo("en-US");
                         string Error = row.Cells["ColSelecciona"].ErrorText;

                
                        string Seleccion = row.Cells["ColSelecciona"].Value?.ToString();

                         if (string.IsNullOrEmpty(Seleccion))
                         {
                              Seleccion = "FALSE";
                         }
                        

                         if  (Seleccion =="TRUE")
                            {
                                Diaseleccionados = Diaseleccionados + 1;
                               //DateTime fechaAsig = DateTime.Parse(row.Cells["FechaVencimiento"].Value.ToString(), usCulture.DateTimeFormat);
                               DateTime fechaAsig = Convert.ToDateTime(row.Cells["FechaVencimiento"].Value.ToString());
                               fechaAsig = fechaAsig.AddDays(DiasExtendidos);
                               string FechaString = fechaAsig.ToString("dd/MM/yyyy");
                               row.Cells["ColResultado"].Value = FechaString;
                            }
                     
                }
            }
            else
            {
                this.btnGrabar.Enabled = false;
                MessageBox.Show("Error: " + "El numero dias de Extension debe ser mayor a Cero",
                             "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Diaseleccionados > 0)
            {
                //this.btnGrabar.Enabled = true;
            }else
            {
                this.btnGrabar.Enabled = false;
                MessageBox.Show("Error: " + "Debe seleccionar por lo menos una Factura para poder aplicar los dias de extension!!!!",
                             "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Observaciones.Length < 10 || string.IsNullOrEmpty(Observaciones)){
                this.btnGrabar.Enabled = false;
                MessageBox.Show("Error: " + "Debe Registrar una Observacion para poder aplicar las extensiones de los dias!!!!",
                             "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.btnGrabar.Enabled = true;
            this.DgFacturas.ReadOnly = true;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SaveFechas();
            //limpiarControles();
        }

        private void limpiarControles()
        {
            this.txtCodigo.Text = null;
            this.txtNombre.Text = null;
            this.DgFacturas.DataSource = null;
            this.txtObservaciones.Text = null;
            this.numericUpDown1.Value = 0;
            DgFacturas.Columns["ColResultado"].Visible = false;
            DgFacturas.Columns["ColSelecciona"].Visible = false;

        }

        private void SaveFechas()
        {
            string QnDoc;
            string CriterioContacto;
            string Seleccion;
            string FechaAnterior;
            string NuevaFecha;
            string Establecimiento;
            string Observacion = this.txtObservaciones.Text;
            int Compania   = Convert.ToInt32(Program._IdEmpresa);
            int IdUsuario = Convert.ToInt32(Program._IdUser);
            int DiasExtendidos = Convert.ToInt32(this.numericUpDown1.Value);
            ////////////////////////////////////////////

            if (DiasExtendidos <= 0)
            {
                MessageBox.Show("Error: " + "El numero dias de Extension debe ser mayor a Cero",
                             "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Observacion.Length < 10 || string.IsNullOrEmpty(Observacion))
            {
                //this.btnGrabar.Enabled = false;
                MessageBox.Show("Error: " + "Debe Registrar una Observacion para poder aplicar las extensiones de los dias!!!!",
                             "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            ////////////////////////////////////////////
            CFacturas CFacturas = new CFacturas();
            try
            {
                foreach (DataGridViewRow row in DgFacturas.Rows)
                    {
                        Seleccion = row.Cells["ColSelecciona"].Value?.ToString();
                        if (Seleccion == "TRUE")
                        {
                            QnDoc = row.Cells["Documento"].Value.ToString();
                            FechaAnterior = row.Cells["FechaVencimiento"].Value.ToString();
                            NuevaFecha = row.Cells["ColResultado"].Value.ToString();
                            Establecimiento = row.Cells["Establecimiento"].Value.ToString();
                            CriterioContacto = this.txtCodigo.Text;
                            Observacion = Observacion.Trim();
                            CFacturas.ActualizarExtFechas(QnDoc, CriterioContacto, DiasExtendidos, FechaAnterior, NuevaFecha, Establecimiento, Observacion, IdUsuario, Compania);
                        }
                    }
                        MessageBox.Show("!Fechas del documento Actualizada con exito¡",
                                                       "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarControles();
                        disableControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                          "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void habilitar_controles_one()
        {
            this.txtObservaciones.Enabled = true;
            this.btnAplicar.Enabled = true;
            this.numericUpDown1.Enabled = true;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
        }
        private void disableControles()
        {
            this.txtObservaciones.Enabled = false;
            this.btnAplicar.Enabled = false;
            this.numericUpDown1.Enabled = false;
            this.DgFacturas.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
        }

        private void SeleccionaTodo()
        {
            foreach (DataGridViewRow row in DgFacturas.Rows)
            {
                 row.Cells["ColSelecciona"].Value = "TRUE";

            }
        }
        private void DeseleccionaTodo()
        {
            foreach (DataGridViewRow row in DgFacturas.Rows)
            {
                row.Cells["ColSelecciona"].Value = "FALSE";

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionaTodo();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DeseleccionaTodo();
        }
        
    }
}
