using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barberia.Model;

namespace Barberia
{
    public partial class Form2 : Form
    {
        private int id = 0;
        private Form1 frm1;
        private Registro reg = new Registro();
        public Form2(int id,Form1 frm1)
        {
            InitializeComponent();
            this.id = id;
            this.frm1 = frm1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            if (this.id > 0)
            {
                this.btnEliminar.Enabled = true;
                var regi = reg.Obtener(this.id);
                this.cboBarbero.SelectedIndex=0;
                this.cboCorte.SelectedIndex = 0;
                this.cboCorte.SelectedIndex = 0;
                this.cboPrecio.SelectedIndex = 0;
                this.numCant.Value = regi.cantidad;

            }
            
        }

        private void llenarCombos()
        {
            this.cboBarbero.Items.Add("Salvador");
            this.cboBarbero.Items.Add("Frank");
            this.cboCorte.Items.Add("Corte Tradicional");
            this.cboCorte.Items.Add("Barba");
            this.cboCorte.Items.Add("Corte y Barba");
            this.cboCorte.Items.Add("Cejas");
            this.cboCorte.Items.Add("Corte, Barba y Cejas");
            this.cboLocal.Items.Add("Kraudy Alajuela");
            this.cboLocal.Items.Add("Kraudy Quepos #1");
            this.cboLocal.Items.Add("Kraudy Quepos #2");
            this.cboPrecio.Items.Add("1000");
            this.cboPrecio.Items.Add("1500");
            this.cboPrecio.Items.Add("2000");
            this.cboPrecio.Items.Add("2500");
            this.cboPrecio.Items.Add("3000");
            this.cboPrecio.Items.Add("4000");
            this.cboPrecio.Items.Add("4500");

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var regi = new Registro
            {
                id = this.id,
                barbero = this.cboBarbero.SelectedItem.ToString(),
                corte = this.cboCorte.SelectedItem.ToString(),
                local = this.cboLocal.SelectedItem.ToString(),
                precio = cboPrecio.SelectedItem.ToString(),
                cantidad = (int)this.numCant.Value,
                fecha= this.dtpFecha.Value
                
            };
            reg.Guardar(regi);
            this.frm1.cargarReg();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar este registro'","Confirmar Eliminar",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                reg.Eliminar(this.id);
                this.frm1.cargarReg();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
