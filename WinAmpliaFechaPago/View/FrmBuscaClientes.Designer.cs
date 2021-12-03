
namespace WinAmpliaFechaPago.View
{
    partial class FrmBuscaClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.grpClientes = new System.Windows.Forms.GroupBox();
            this.DgFacturas = new System.Windows.Forms.DataGridView();
            this.btnSelecciona = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBusqueda.SuspendLayout();
            this.grpClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.label1);
            this.grpBusqueda.Controls.Add(this.txtBusqueda);
            this.grpBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(869, 100);
            this.grpBusqueda.TabIndex = 0;
            this.grpBusqueda.TabStop = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Location = new System.Drawing.Point(172, 41);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(552, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // grpClientes
            // 
            this.grpClientes.Controls.Add(this.DgFacturas);
            this.grpClientes.Location = new System.Drawing.Point(12, 123);
            this.grpClientes.Name = "grpClientes";
            this.grpClientes.Size = new System.Drawing.Size(869, 274);
            this.grpClientes.TabIndex = 1;
            this.grpClientes.TabStop = false;
            // 
            // DgFacturas
            // 
            this.DgFacturas.AllowUserToAddRows = false;
            this.DgFacturas.AllowUserToDeleteRows = false;
            this.DgFacturas.AllowUserToResizeColumns = false;
            this.DgFacturas.AllowUserToResizeRows = false;
            this.DgFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgFacturas.EnableHeadersVisualStyles = false;
            this.DgFacturas.Location = new System.Drawing.Point(6, 19);
            this.DgFacturas.Name = "DgFacturas";
            this.DgFacturas.ReadOnly = true;
            this.DgFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgFacturas.Size = new System.Drawing.Size(857, 249);
            this.DgFacturas.TabIndex = 0;
            this.DgFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.DgFacturas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFacturas_CellContentDoubleClick);
            this.DgFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFacturas_CellDoubleClick);
            // 
            // btnSelecciona
            // 
            this.btnSelecciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecciona.Location = new System.Drawing.Point(399, 409);
            this.btnSelecciona.Name = "btnSelecciona";
            this.btnSelecciona.Size = new System.Drawing.Size(80, 23);
            this.btnSelecciona.TabIndex = 2;
            this.btnSelecciona.Text = "Selecciona";
            this.btnSelecciona.UseVisualStyleBackColor = true;
            this.btnSelecciona.Click += new System.EventHandler(this.btnSelecciona_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Busqueda";
            // 
            // FrmBuscaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 450);
            this.Controls.Add(this.btnSelecciona);
            this.Controls.Add(this.grpClientes);
            this.Controls.Add(this.grpBusqueda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busqueda de Clientes";
            this.Load += new System.EventHandler(this.FrmBuscaClientes_Load);
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.grpClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.GroupBox grpClientes;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView DgFacturas;
        private System.Windows.Forms.Button btnSelecciona;
        private System.Windows.Forms.Label label1;
    }
}