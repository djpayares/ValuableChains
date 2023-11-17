using Datos;
using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentacionGUI.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentacionGUI
{
    public partial class INVENTARIO : Form
    {
        public INVENTARIO()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                groupBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                groupBox2.Visible = false;
            }
        }

        

        void AbrirForm(Form form)
        {
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForm(new ADMINISTRAR());
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button1.Visible = false;
        }
    }
}
