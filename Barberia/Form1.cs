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
    public partial class Form1 : Form
    {

        private Registro reg = new Registro();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarReg();
        }

        public void cargarReg()
        {
            
            this.dgvReg.DataSource = reg.Listar();
                    

        }

        private void dgvReg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            new Form2(Convert.ToInt32(dgvReg.Rows[e.RowIndex].Cells[0].Value),
                this).ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new Form2(0,this).ShowDialog();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var datos = reg.Listar();
            double total=0;
            foreach (var dato in datos)
            {
                total += Convert.ToDouble(dato.precio)*dato.cantidad;
            }
            String unNumero = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(total.ToString()));
            MessageBox.Show("El Total General Facturado es: " +unNumero ,"Total General: ",MessageBoxButtons.OK);
        }
    }
}
